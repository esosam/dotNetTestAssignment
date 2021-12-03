using CodersLinkProjectWebApp.Models;
using CodersLinkProjectWebApp.Paths;
using CodersLinkProjectWebApp.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CodersLinkProjectWebApp.Controllers
{
    public class UsrDataController : Controller
    {
        private readonly IUsrDataRepo _usrDataRepo;

        public UsrDataController(IUsrDataRepo usrDataRepo)
        {
            _usrDataRepo = usrDataRepo;
        }

        public IActionResult Index()
        {
            return View(new UsrDataModel() { });
        }

        public async Task<IActionResult> Upsert(int? Id)
        {
            UsrDataModel obj = new();
            if (Id == null)
            {
                return View(obj);
            }

            obj = await _usrDataRepo.GetAsync(UrlPath.UsrBaseUrl, Id.GetValueOrDefault());
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        public async Task<IActionResult> GetAllUsrData()
        {
            return Json(new { data = await _usrDataRepo.GetAllAsync(UrlPath.UsrBaseUrl) });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            var status = await _usrDataRepo.DeleteAsync(UrlPath.UsrBaseUrl, Id);
            if (status)
            {
                return Json(new { success = true, message = "Delete Successful" });
            }
            return Json(new { success = false, message = "Delete Not Successful" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(UsrDataModel obj)
        {
            if (ModelState.IsValid)
            {
                bool requestResult = false;     
                
                if (obj.Id == 0)
                {
                    requestResult = await _usrDataRepo.CreateAsync(UrlPath.UsrBaseUrl, obj);
                }
                else
                {
                    requestResult = await _usrDataRepo.UpdateAsync(UrlPath.UsrBaseUrl + obj.Id, obj);
                }

                if (requestResult)
                {
                    TempData["okmsg"] = "Process successfully, data was received!";
                }
                else
                {
                    TempData["errmsg"] = "Error, data was not process base on internal validation, usually duplicate records exists!";
                }

                return RedirectToAction(nameof(Index), "UsrData");
            }
            else
            {
                TempData["errmsg"] = "Error, data was not process!";
                return View(obj);
            }
        }

    }
}
