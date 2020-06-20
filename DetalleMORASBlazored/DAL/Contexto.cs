using DetalleMORASBlazored.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DetalleMORASBlazored.DAL
{
    public class Contexto : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=DATA\prestamoSDB.db");
        }

        public DbSet<Prestamos> Prestamos { get; set; }
        public DbSet<Mora> Moras { get; set; }
        public DbSet<Personas> Personas { get; set; }
    }
}
