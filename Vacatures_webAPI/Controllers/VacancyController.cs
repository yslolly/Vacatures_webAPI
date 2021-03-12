using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacatures_webAPI.DTO;
using Vacatures_webAPI.Models;
using Vacatures_webAPI.Services;

namespace Vacatures_webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacancyController : ControllerBase
    {
        private readonly IVacancyService _vacancyService;
        private readonly IMapper _mapper;

        public VacancyController(IVacancyService vacancyService, IMapper mapper)
        {
            _vacancyService = vacancyService;
            _mapper = mapper;
        }

        [HttpPost("create vacancy")] // CREATE
        public ActionResult CreateVacancy(CreateVacancyDTO newVacancy)
        {
            var vacancyToAdd = _mapper.Map<Vacancy>(newVacancy);
            _vacancyService.CreateVacancy(vacancyToAdd);
            return Ok();
        }

        [HttpGet("get vacancy by id")] // READ
        public ActionResult<GetVacancyDTO> GetVacancyById(int vacancyId)
        {
            try
            {
                var vacancyToFind = _vacancyService.GetVacancyById(vacancyId);
                var vacancyToFindDTO = _mapper.Map<GetVacancyDTO>(vacancyToFind);
                return Ok(vacancyToFindDTO);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        [HttpGet("get vacancies by company id")] // READ
        public ActionResult<List<GetVacancyWithoutCompanyId>> GetVacanciesByCompanyId(int companyId)
        {
            var listOfAllVacanciesByCompanyId = _vacancyService.GetVacanciesByCompanyId(companyId);
            var listOfAllVacanciesByCompanyIdDTO = _mapper.Map<List<GetVacancyWithoutCompanyId>>(listOfAllVacanciesByCompanyId);
            return Ok(listOfAllVacanciesByCompanyIdDTO);
        }

        [HttpPut("update vacancy by id")] // UPDATE
        public ActionResult UpdateVacancyById(int vacancyId, CreateVacancyDTO vacancyEditValues)
        {
            try
            {
                var vacancyToUpdate = _mapper.Map<Vacancy>(vacancyEditValues);
                _vacancyService.UpdateVacancyById(vacancyId, vacancyToUpdate);
                return Ok();
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }

        [HttpDelete("delete vacancy by id")] // DELETE
        public ActionResult DeleteVacancyById(int vacancyId)
        {
            try
            {
                _vacancyService.DeleteVacancyById(vacancyId);
                return Ok();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        [HttpGet("get all vacancies by city")] // READ
        public ActionResult<List<GetVacancyDTO>> GetAllVacanciesByCity(string city)
        {
            var listOfAllVacanciesByCity = _vacancyService.GetAllVacanciesByCity(city);
            var listOfAllVacanciesByCityDTO = _mapper.Map<List<GetVacancyDTO>>(listOfAllVacanciesByCity);
            return Ok(listOfAllVacanciesByCityDTO);
        }

        [HttpGet("get three most recent vacancies")] // READ
        public ActionResult<List<GetVacancyDTO>> GetThreeMostRecentVacancies()
        {
            var listOfThreeMostRecentVacancies = _vacancyService.GetLastThreeVacancies();
            var listOfThreeMostRecentVacanciesDTO = _mapper.Map<List<GetVacancyDTO>>(listOfThreeMostRecentVacancies);
            return Ok(listOfThreeMostRecentVacanciesDTO);
        }
    }
}
