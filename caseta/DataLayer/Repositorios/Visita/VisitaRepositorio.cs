using DataInterfaces;
using SecureGateTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class VisitaRepositorio : IVisitaRepositorio 
    {
        public string ConnString { get; set; }
        public VisitaRepositorio()
        {
            ConnString = ConfigurationManager.ConnectionStrings["SecureGateEntities"].ConnectionString;
        }
        public void DesactivarVisita(int id)
        {
            throw new NotImplementedException();
        }

        public Visita GetVisitaByID(int id)
        {
            throw new NotImplementedException();
        }

        public int SetVisita(Visita v)
        {
            var visita = new SVisita()
            {
                Activo = v.Activo,
                Apellidos = v.Apellidos,
                idTipoVisita = v.TipoVisita.ID,
                idUbicacion = v.Ubicacion.ID,
                Nombre = v.Nombre,
                Placas = v.Placas
            };
            using (GeneralContext context = new GeneralContext(ConnString))
            {
                context.Visitas.Add(visita);
                context.SaveChanges();
                return visita.IdVisita;
            }
        }

        public void UpdateFotoVisita(string urlfoto, int id)
        {
            using (var context = new GeneralContext(ConnString))
            {
                var visita = context.Visitas.Where(w => w.IdVisita == id).First();
                visita.FotoUrl = urlfoto;
                context.SaveChanges();
            }
        }
    }
}
