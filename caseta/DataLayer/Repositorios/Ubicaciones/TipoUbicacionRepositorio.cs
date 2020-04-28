using DataInterfaces;
using SecureGateTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class TipoUbicacionRepositorio : ITipoUbicacionRepositorio
    {
        public string ConnString { get; set; }
        public TipoUbicacionRepositorio()
        {
            ConnString = ConfigurationManager.ConnectionStrings["SecureGateEntities"].ConnectionString;
        }
        public IEnumerable<TipoUbicacion> GetTipoUbicaciones()
        {
            IEnumerable<TipoUbicacion> tipoUbicaciones;
            using (IUbicacionesDBContext context = new GeneralContext(ConnString))
            {
                tipoUbicaciones = context.TiposUbicacion.Select(s => new TipoUbicacion()
                {
                    IdTipoUbicacion = s.IdTipoUbicacion,
                    Nombre = s.Nombre
                }).ToList();
            }
            return tipoUbicaciones;
        }
    }
}
