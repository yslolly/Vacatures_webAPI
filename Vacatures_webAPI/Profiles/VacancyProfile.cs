using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacatures_webAPI.DTO;
using Vacatures_webAPI.Models;

namespace Vacatures_webAPI.Profiles
{
    public class VacancyProfile : Profile
    {
        public VacancyProfile()
        {
            CreateMap<Vacancy, GetVacancyDTO>().ReverseMap();
            CreateMap<Vacancy, CreateVacancyDTO>().ReverseMap();
            CreateMap<Vacancy, GetVacancyWithoutCompanyId>().ReverseMap();
        }
    }
}
