using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vacatures_webAPI.DTO
{
    public class GetCompanyWithVacanciesDTO
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Postal { get; set; }
        public string City { get; set; }
        public List<CreateVacancyDTO> Vacancies { get; set; }
    }
}
