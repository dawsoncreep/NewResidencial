using DataLayer;
using SecureGateTypes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDBContext
{
    public interface IUbicacionesDBContext : IDisposable
    {
        DbSet<STipoUbicacion> TiposUbicacion { get; set; }
        DbSet<SUbicacion> Ubicaciones { get; set; }
    }
}
