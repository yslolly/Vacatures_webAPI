using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacatures_webAPI.DTO;
using Vacatures_webAPI.Models;

namespace Vacatures_webAPI.Profiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CreateCompanyDTO>().ReverseMap();
            CreateMap<Company, GetCompanyDTO>().ReverseMap();
            CreateMap<Company, GetCompanyWithVacanciesDTO>().ReverseMap();
        }
    }
}
