using System.Data.Entity;

namespace DataLayer
{
    public class GeneralContext : DbContext, IVisitaDbContext, IUbicacionesDBContext, IUsuarioDBContext, IDispositivoDBContext
    {
        public GeneralContext(string ConnectionString) : base(ConnectionString)
        {
        }
        public virtual DbSet<STipoVisita> TiposVisita { get; set; }
        public virtual DbSet<SVisita> Visitas { get; set; }
        public virtual DbSet<SEvento> Eventos { get; set; }
        public virtual DbSet<STipoUbicacion> TiposUbicacion { get; set; }
        public virtual DbSet<SUbicacion> Ubicaciones { get; set; }
        public virtual DbSet<SUsuario> Usuarios { get; set; }
        public virtual DbSet<SIngresoSalidaVisita> IngresoSalidaVisitas { get; set; }
        public virtual DbSet<SDispositivo> Dispositivos { get ; set; }
    }
}
