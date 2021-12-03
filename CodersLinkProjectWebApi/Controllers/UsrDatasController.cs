using AutoMapper;
using CodersLinkProjectWebApi.Models;
using CodersLinkProjectWebApi.Models.Dtos;
using CodersLinkProjectWebApi.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodersLinkProjectWebApi.Controllers
{
    [Route("api/v{version:apiVersion}/user")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class UsrDatasController : ControllerBase
    {
        private IUsrDataRepo _usrDataRepo;
        private readonly IMapper _mapper;

        public UsrDatasController(IUsrDataRepo usrDataRepo, IMapper mapper)
        {
            _usrDataRepo = usrDataRepo;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetUsrDatas")]
        [ProducesResponseType(StatusCodes.Status200OK, Type=typeof(List<UsrData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public IActionResult GetUsrDatas()
        {
            var objList = _usrDataRepo.GetUsrDatas();
            if (objList == null)
            {
                NotFound();
            }

            return Ok(objList);
        }

        [HttpGet("{usrId:int}", Name = "GetUsrData")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UsrData))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public IActionResult GetUsrData(int usrId)
        {
            var obj = _usrDataRepo.GetUsrData(usrId);
            if (obj == null)
            {
                return NotFound();
            }

            return Ok(obj);
        }

        [HttpGet("filter", Name = "GetUsrFilterDatas")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UsrData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public IActionResult GetUsrFilterDatas([FromQuery] string ln, [FromQuery] int? sf)
        {
            string tmpLName = string.Empty;
            if (!string.IsNullOrWhiteSpace(ln))
            {
                tmpLName = ln;
            }

            //true = DESC
            bool sortby = true;
            if (sf == null || sf.Equals(0))
            {
                //false = ASC
                sortby = false;
            }

            var obj = _usrDataRepo.GetUsrFilterDatas(tmpLName, sortby);
            if (obj == null)
            {
                return NotFound();
            }

            return Ok(obj);
        }

        [HttpPost(Name = "CreateUsrData")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UsrData))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public IActionResult CreateUsrData([FromBody] UsrDataCreateDto usrDataDto)
        {
            if (usrDataDto == null)
            {
                return BadRequest(ModelState);
            }

            if (_usrDataRepo.UsrDataExists(usrDataDto.UsrEmail))
            {
                ModelState.AddModelError("", "User Exists!");
                return StatusCode(404, ModelState);
            }

            var UsrObj = _mapper.Map<UsrData>(usrDataDto);

            if (!_usrDataRepo.CreateUsrData(UsrObj))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record {UsrObj.UsrEmail}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetUsrData",
                new
                {
                    version = HttpContext.GetRequestedApiVersion().ToString(),
                    usrId = UsrObj.Id
                }, UsrObj);
        }

        [HttpPatch("{usrId:int}", Name = "UpdateUsrData")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public IActionResult UpdateUsrData(int usrId, [FromBody] UsrDataUpdateDto usrDataDto)
        {
            if (usrDataDto == null)
            {
                return BadRequest(ModelState);
            }

            if (!_usrDataRepo.UsrDataExists(usrId))
            {
                ModelState.AddModelError("", "User Is not Found!");
                return StatusCode(404, ModelState);
            }

            if (usrId != usrDataDto.Id)
            {
                return BadRequest(ModelState);
            }

            var UsrObj = _mapper.Map<UsrData>(usrDataDto);

            if (!_usrDataRepo.UpdateUsrData(UsrObj))
            {
                ModelState.AddModelError("", $"Something went wrong when updating the record {UsrObj.UsrEmail}");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }

        [HttpDelete("{usrId:int}", Name = "DeleteUsrData")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public IActionResult DeleteUsrData(int usrId)
        {
            if (!_usrDataRepo.UsrDataExists(usrId))
            {
                return NotFound();
            }

            var usrDataObj = _usrDataRepo.GetUsrData(usrId);

            if (!_usrDataRepo.DeleteUsrData(usrDataObj))
            {
                ModelState.AddModelError("", $"Something went wrong when deleting the record {usrDataObj.UsrEmail}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
