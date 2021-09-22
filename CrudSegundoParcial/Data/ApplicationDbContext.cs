using CrudSegundoParcial.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudSegundoParcial.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
                    
        }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Marcas> Marcas { get; set; }
        public DbSet<Estados> Estados { get; set; }
    }
}
