using ApiRest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Context
{
    public class DefaultContext : DbContext
    {
        public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
        {

        }

        public DbSet<Viaje> Viajes { get; set; }
        public DbSet<Viajero> Viajeros { get; set; }
        public DbSet<R_Viaje_Viajero> Viajes_Viajeros { get; set; }
    }
}
