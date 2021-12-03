using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodersLinkProjectWebApi.Models;
using CodersLinkProjectWebApi.Models.Dtos;

namespace CodersLinkProjectWebApi.Mapper
{
    public class UsrDataMappings : Profile
    {
        public UsrDataMappings()
        {
            CreateMap<UsrData, UsrDataCreateDto>().ReverseMap();
            CreateMap<UsrData, UsrDataUpdateDto>().ReverseMap();
        }
    }
}
