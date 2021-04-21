using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Data
{
    public class ConexionBD : DbContext
    {
        public ConexionBD(DbContextOptions<ConexionBD> options) : base (options)
        {

        }

        public DbSet<Libro> Libro { get; set; }
    }
}
