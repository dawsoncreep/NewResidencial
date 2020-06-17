using DataInterfaces;
using SecureGateTypes;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace DataLayer
{
    public class TipoVisitaRepositorio : ITipoVisitaRepositorio
    {
        public string ConnString { get; set; }
        public TipoVisitaRepositorio()
        {
            ConnString = ConfigurationManager.ConnectionStrings["SecureGateEntities"].ConnectionString;
        }
        public IEnumerable<TipoVisita> GetTiposVisita()
        {
            IEnumerable<TipoVisita> tiposVisita;
            using (IVisitaDbContext context = new GeneralContext(ConnString))
            {
                tiposVisita = context.TiposVisita.Where(w => w.Activo == true).Select(s => new TipoVisita()
                {
                    Activo = s.Activo,
                    ID = s.IdTipoVisita,
                    Nombre = s.Nombre
                }).ToList();
            }
            return tiposVisita;
        }
    }
}
