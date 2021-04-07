using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trabajo_Final_Desarro_Web.Models;

namespace Trabajo_Final_Desarro_Web
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options): base(options)
        {
        }
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Alquiler> alquilers { get; set; }             
        public DbSet<Sancion> sancions { get; set; }
        public DbSet<CD> CDs{ get; set; }
        public DbSet<Detalle_Alquiler> detalle_Alquilers{ get; set; }
       
    }
}
