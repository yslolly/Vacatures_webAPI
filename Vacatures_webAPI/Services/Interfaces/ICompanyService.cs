using System.Collections.Generic;
using Vacatures_webAPI.Models;

namespace Vacatures_webAPI.Services.Interfaces
{
    public interface ICompanyService
    {
        void CreateCompany(Company newCompany);
        List<Company> GetAllCompanies();
        Company GetCompanyById(int companyId);
        void UpdateCompanyById(int companyId, Company companyEditValues);
        void DeleteCompanyById(int companyId);
    }
}