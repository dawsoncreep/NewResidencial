using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDBContext
{
    public interface IUsuarioDBContext
    {
        DbSet<SUsuario> Usuarios { get; set; }
    }
}
