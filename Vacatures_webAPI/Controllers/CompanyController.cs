using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacatures_webAPI.DTO;
using Vacatures_webAPI.Models;
using Vacatures_webAPI.Services.Interfaces;

namespace Vacatures_webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        [HttpPost("create company")] // CREATE
        public ActionResult CreateCompany(CreateCompanyDTO newCompany)
        {
            var companyToAdd = _mapper.Map<Company>(newCompany);
            _companyService.CreateCompany(companyToAdd);
            return Ok();
        }

        [HttpGet("get company by id")] // READ
        public ActionResult<GetCompanyWithVacanciesDTO> GetCompanyById(int companyId)
        {
            try
            {
                var companyToFind = _companyService.GetCompanyById(companyId);
                var companyToFindDTO = _mapper.Map<GetCompanyWithVacanciesDTO>(companyToFind);
                return companyToFindDTO;
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        [HttpGet("get all companies")] // READ
        public List<GetCompanyDTO> GetAllCompanies()
        {
            var listOfAllCompanies = _companyService.GetAllCompanies();
            var listOfAllCompaniesDTO = _mapper.Map<List<GetCompanyDTO>>(listOfAllCompanies);
            return listOfAllCompaniesDTO;
        }

        [HttpPut("update company by id")] // UPDATE
        public ActionResult UpdateCompanyById(int companyId, CreateCompanyDTO companyEditValues)
        {
            try
            {
                var companyToUpdate = _mapper.Map<Company>(companyEditValues);
                _companyService.UpdateCompanyById(companyId, companyToUpdate);
                return Ok();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        [HttpDelete("delete company by id")] // DELETE
        public ActionResult DeleteCompanyById(int companyId)
        {
            try
            {
                _companyService.DeleteCompanyById(companyId);
                return Ok();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }
    }

    
}
