using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacatures_webAPI.Db;
using Vacatures_webAPI.Models;
using Vacatures_webAPI.Services.Interfaces;

namespace Vacatures_webAPI.Services
{
    public class CompanyService : ICompanyService
    {
        public void CreateCompany(Company newCompany) // CREATE
        {
            using var db = new VacancyDbContext();
            db.companies.Add(newCompany);
            db.SaveChanges();
        }

        public Company GetCompanyById(int companyId) // READ
        {
            using var db = new VacancyDbContext();
            var companyToFind = db.companies.Include(x => x.Vacancies).First(x => x.CompanyId == companyId);
            return companyToFind;
        }

        public List<Company> GetAllCompanies() // READ
        {
            using var db = new VacancyDbContext();
            var listOfAllCompanies = db.companies.Include(x => x.Vacancies).ToList();
            return listOfAllCompanies;
        }

        public void UpdateCompanyById(int companyId, Company companyEditValues) // UPDATE
        {
            using var db = new VacancyDbContext();
            var companyToUpdate = db.companies.First(x => x.CompanyId == companyId); // InvalidOperatorException if null
            companyToUpdate.Name = companyEditValues.Name;
            companyToUpdate.Street = companyEditValues.Street;
            companyToUpdate.HouseNumber = companyEditValues.HouseNumber;
            companyToUpdate.Postal = companyEditValues.Postal;
            companyToUpdate.City = companyEditValues.City;
            db.companies.Update(companyToUpdate);
            db.SaveChanges();
        }

        public void DeleteCompanyById(int companyId) // DELETE
        {
            using var db = new VacancyDbContext();
            var companyToDelete = db.companies.First(x => x.CompanyId == companyId);
            db.Remove(companyToDelete);
            db.SaveChanges();
        }
    }
}
