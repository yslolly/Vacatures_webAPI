using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vacatures_webAPI.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Postal { get; set; }
        public string City { get; set; }
        public List<Vacancy> Vacancies { get; set; }
    }
}
