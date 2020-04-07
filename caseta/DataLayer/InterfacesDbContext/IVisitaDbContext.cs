using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    internal interface IVisitaDbContext : IDisposable
    {
        DbSet<SVisita> Visitas { get; set; }
        DbSet<STipoVisita> TiposVisita { get; set; }
        DbSet<SIngresoSalidaVisita> IngresoSalidaVisitas { get; set; }
    }
}
