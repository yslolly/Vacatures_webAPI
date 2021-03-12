using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacatures_webAPI.Models;

namespace Vacatures_webAPI.Db
{
    public class VacancyDbContext : DbContext
    {
        public DbSet<Vacancy> vacancies { get; set; }
        public DbSet<Company> companies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data source=vacancies.db");
    }
}
