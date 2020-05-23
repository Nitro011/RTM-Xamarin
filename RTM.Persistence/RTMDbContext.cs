using Microsoft.EntityFrameworkCore;
using RTM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Persistence
{
    public class RTMDbContext:DbContext
    {

        string cn = "server=179.52.197.100;database=RegistroDePersonas;uid=Arquimedes;password=123456;";



        public RTMDbContext():
            base()
        {   
        }

       
        public DbSet<Example> examples { get; set; }
        public DbSet<Almacen> almacens { get; set; }
        public DbSet<Suplidor> suplidors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(cn);
            optionsBuilder.EnableSensitiveDataLogging(true);
        }

    }
}
