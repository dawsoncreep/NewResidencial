using System;
using System.Data.Entity;

namespace DataLayer
{
    public interface IUsuarioDBContext : IDisposable
    {
        DbSet<SUsuario> Usuarios { get; set; }
    }
}
