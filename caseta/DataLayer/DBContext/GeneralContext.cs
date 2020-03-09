using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{

    public class GeneralContext : DbContext, IVisitaDbContext
    {
        public DbSet<Visita> Visita { get; set; }
        public DbSet<TipoVisita> TipoVisita { get ; set ; }
    }
}
