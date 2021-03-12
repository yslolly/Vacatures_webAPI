using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vacatures_webAPI.DTO
{
    public class CreateVacancyDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int CompanyId { get; set; }
    }
}
