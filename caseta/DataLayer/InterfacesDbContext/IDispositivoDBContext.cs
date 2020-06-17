using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IDispositivoDBContext : IDisposable
    {
        DbSet<SDispositivo> Dispositivos { get; set; }
    }
}
