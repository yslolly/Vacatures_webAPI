using System.Collections.Generic;
using Vacatures_webAPI.Models;

namespace Vacatures_webAPI.Services
{
    public interface IVacancyService
    {
        void CreateVacancy(Vacancy newVacancy);
        List<Vacancy> GetAllVacanciesByCity(string city);
        List<Vacancy> GetLastThreeVacancies();
        List<Vacancy> GetVacanciesByCompanyId(int companyId);
        Vacancy GetVacancyById(int vacancyId);
        void UpdateVacancyById(int vacancyId, Vacancy vacancyEditValues);
        void DeleteVacancyById(int vacancyId);
    }
}