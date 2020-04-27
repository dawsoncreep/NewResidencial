using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IUsuarioDBContext : IDisposable
    {
        DbSet<SUsuario> Usuarios { get; set; }
    }
}
