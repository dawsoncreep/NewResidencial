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

        public IEnumerable<DGVVisitaActual> GetDGVVisitasActuales()
        {
            IEnumerable<DGVVisitaActual> dGVVisitas;
            using (IVisitaDbContext context = new GeneralContext(ConnString))
            {
                dGVVisitas = context.IngresoSalidaVisitas.Where(w => w.fechaSalida == null).Select(s => new DGVVisitaActual()
                {
                    Domicilio = context.Ubicaciones.FirstOrDefault(f => f.idUbicacion == context.Visitas.FirstOrDefault(x => x.IdVisita == s.idVisita).idUbicacion).Nombre,
                    FechaIngreso = s.fechaIngreso,
                    IdVisita = s.idVisita,
                    NombreCompleto = context.Visitas.Where(x => x.IdVisita == s.idVisita).Select(y => y.Nombre + " " + y.Apellidos).FirstOrDefault(),
                    Placas = context.Visitas.FirstOrDefault(x => x.IdVisita == s.idVisita).Placas,
                    FotoRostro = s.fotoCabina
                }).ToList();
            }
            return dGVVisitas;
        }
    }
}
