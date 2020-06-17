using System;
using System.Data.Entity;

namespace DataLayer
{
    public interface IUbicacionesDBContext : IDisposable
    {
        DbSet<STipoUbicacion> TiposUbicacion { get; set; }
        DbSet<SUbicacion> Ubicaciones { get; set; }
    }
}
