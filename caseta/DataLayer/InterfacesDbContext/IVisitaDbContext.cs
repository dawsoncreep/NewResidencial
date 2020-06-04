using System;
using System.Data.Entity;

namespace DataLayer
{
    internal interface IVisitaDbContext : IDisposable
    {
        DbSet<SVisita> Visitas { get; set; }
        DbSet<STipoVisita> TiposVisita { get; set; }
        DbSet<SIngresoSalidaVisita> IngresoSalidaVisitas { get; set; }
        DbSet<SUbicacion> Ubicaciones { get; set; }
    }
}
