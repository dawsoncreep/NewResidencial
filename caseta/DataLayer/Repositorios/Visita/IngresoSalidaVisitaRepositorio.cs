using DataInterfaces;
using SecureGateTypes;
using System;
using System.Configuration;
using System.Linq;

namespace DataLayer
{
    public class IngresoSalidaVisitaRepositorio : IIngresoSalidaVisitaRepositorio
    {
        public string ConnString { get; set; }
        public IngresoSalidaVisitaRepositorio()
        {
            ConnString = ConfigurationManager.ConnectionStrings["SecureGateEntities"].ConnectionString;
        }
        public int SetIngreso(int id, string placaDelantera, string placaTrasera, string cabina, string identificacion)
        {
            using (var context = new GeneralContext(ConnString))
            {
                var ingreso = new SIngresoSalidaVisita()
                {
                    idVisita = id,
                    fechaIngreso = DateTime.Now,
                    fechaSalida = null,
                    fotoCabina = cabina,
                    fotoIdentificacion = identificacion,
                    fotoPlacaDelantera = placaDelantera,
                    fotoPlacaTrasera = placaDelantera
                };
                context.IngresoSalidaVisitas.Add(ingreso);
                return context.SaveChanges();
            }
        }

        public int SetSalida(int idVisita, string fotoSalida)
        {
            using (var context = new GeneralContext(ConnString))
            {
                var ingreso = context.IngresoSalidaVisitas.Where(w => w.fechaSalida == null && w.idVisita == idVisita).FirstOrDefault();
                ingreso.fotoSalidaUrl = fotoSalida;
                ingreso.fechaSalida = DateTime.Now;
                return context.SaveChanges();
            }
        }

        /// <summary>
        /// Obtiene la ultima salida registrada en base de datos
        /// </summary>
        /// <returns></returns>
        public IngresoSalidaVisita GetUltimaSalida()
        {
            IngresoSalidaVisita ISVisita;
            using (IVisitaDbContext context = new GeneralContext(ConnString))
            {
                var last = context.IngresoSalidaVisitas.OrderByDescending(o => o.fechaSalida).FirstOrDefault();
                ISVisita = new IngresoSalidaVisita()
                {
                    FechaIngreso = last.fechaIngreso,
                    FechaSalida = (DateTime)last.fechaSalida,
                    FotoCabina = last.fotoCabina,
                    FotoIdentificacion = last.fotoCabina,
                    FotoPlacaDelantera = last.fotoPlacaDelantera,
                    FotoPlacaTrasera = last.fotoPlacaTrasera,
                    FotoSalidaUrl = last.fotoSalidaUrl,
                    Visita = new Visita() { ID = last.idVisita }
                };
            }
            return ISVisita;
        }
    }
}
