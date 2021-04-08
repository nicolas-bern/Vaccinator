using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vaccinator.Models;

namespace Vaccinator.Models
{
    public class ContexteBDD : DbContext
    {
        public DbSet<Personne> Personnes { get; set; }

        public DbSet<Vaccin> Vaccin { get; set; }

        public DbSet<Injection> Injection { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = vaccinatorDB");
        }

    }
}
