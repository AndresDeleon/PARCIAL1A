using System;
using System.Collections.Generic;
using PARCIAL1A.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace PARCIAL1A
{
    public class ordenContext : DbContext
    {
        public ordenContext(DbContextOptions<ordenContext> options) : base(options)
        {

        }

        //public DbSet<CompraElementos> CompraElementos { get; set; }
        public DbSet<ElementosPorPlato> ElementosPorPlato { get; set; }
        //public DbSet<PlatosPorCombo> PlatosPorCombo { get; set; }
        public DbSet<Platos> Platos { get; set; }
        public DbSet<Elementos> Elementos { get; set; }
    }
}
