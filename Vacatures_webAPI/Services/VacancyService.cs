using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacatures_webAPI.Db;
using Vacatures_webAPI.Models;

namespace Vacatures_webAPI.Services
{
    public class VacancyService : IVacancyService
    {
        public void CreateVacancy(Vacancy newVacancy) // CREATE
        {
            using var db = new VacancyDbContext();
            db.vacancies.Add(newVacancy);
            db.SaveChanges();
        }

        public Vacancy GetVacancyById(int vacancyId) // READ
        {
            using var db = new VacancyDbContext();
            var vacancyToFind = db.vacancies.Include(x => x.Company).First(x => x.VacancyId == vacancyId);
            return vacancyToFind;
        }

        public List<Vacancy> GetVacanciesByCompanyId(int companyId) // READ
        {
            using var db = new VacancyDbContext();
            var listOfVacanciesByCompany = db.vacancies.Where(x => x.CompanyId == companyId).ToList();
            return listOfVacanciesByCompany;
        }

        public List<Vacancy> GetAllVacanciesByCity(string city) // READ
        {
            using var db = new VacancyDbContext();
            var listOfAllVacanciesByCity = db.vacancies.Include(x => x.Company).Where(x => x.Company.City == city).ToList();
            return listOfAllVacanciesByCity;
        }

        public List<Vacancy> GetLastThreeVacancies() // READ
        {
            using var db = new VacancyDbContext();
            var listOfAllVacancies = db.vacancies.Include(x => x.Company).OrderByDescending(x => x.DateOfCreation).Take(3).ToList(); // wordt IOrderEnumerable door OrderBy
            return listOfAllVacancies;
        }

        public void UpdateVacancyById(int vacancyId, Vacancy vacancyEditValues) // UPDATE
        {
            using var db = new VacancyDbContext();
            var vacancyToUpdate = db.vacancies.Include(x => x.Company).First(x => x.VacancyId == vacancyId); // bij null geeft dit een InvalidOperationException (opvangen in controller)
            vacancyToUpdate.Description = vacancyEditValues.Description;
            vacancyToUpdate.DateOfCreation = vacancyEditValues.DateOfCreation;
            vacancyToUpdate.CompanyId = vacancyEditValues.CompanyId;
            db.vacancies.Update(vacancyToUpdate);
            db.SaveChanges();
        }

        public void DeleteVacancyById(int vacancyId) // DELETE
        {
            using var db = new VacancyDbContext();
            var vacancyToDelete = db.vacancies.First(x => x.VacancyId == vacancyId);
            db.vacancies.Remove(vacancyToDelete);
            db.SaveChanges();
        }

        

        
    }
}
