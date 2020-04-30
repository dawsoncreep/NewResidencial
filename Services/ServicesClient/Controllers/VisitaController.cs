using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using ConectarDatos;

namespace ServicesClient.Controllers
{
    public class VisitaController : ApiController
    {
        private ResidencialEntities contexto = new ResidencialEntities();

        [HttpGet]
        public IEnumerable<Visita> Get()
        {
            using (ResidencialEntities residencialEntities = new ResidencialEntities())
            {
                residencialEntities.Configuration.LazyLoadingEnabled = false;
                List<Visita> lista = residencialEntities.Visita.ToList<Visita>();

                return lista;
            }
        }

        [HttpGet]
        public IEnumerable<Visita> GetVisitaByUbication(int idUbicacion)
        {
            using (ResidencialEntities residencialEntities = new ResidencialEntities())
            {
                residencialEntities.Configuration.LazyLoadingEnabled = false;
                var Visitas = residencialEntities.Visita.ToList().Where(x => x.idUbicacion == idUbicacion);
                return Visitas;

            }
        }

        [HttpGet]
        public Visita GetVisita(int idVisita)
        {
            using (ResidencialEntities residencialEntities = new ResidencialEntities())
            {
                residencialEntities.Configuration.LazyLoadingEnabled = false;
                var Visita = residencialEntities.Visita.FirstOrDefault(x => x.idVisita == idVisita);
                return Visita;

            }
        }

        [HttpPost]
        public IHttpActionResult Agregar([FromBody]Visita visita)
        {

            using (ResidencialEntities residencialEntities = new ResidencialEntities())
            {
                if (ModelState.IsValid)
                {

                    contexto.Visita
.Add(visita);
                    contexto.SaveChanges();
                    return Ok(visita);
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        [HttpPut]
        public IHttpActionResult Actualizar([FromBody]Visita visita)
        {

            if (ModelState.IsValid)
            {
                using (ResidencialEntities residencialEntities = new ResidencialEntities())
                {
                    int visitaExiste;
                    visitaExiste = contexto.Visita.Count(s => s.idVisita == visita.idVisita);
                    if (visitaExiste == 0)
                    {
                        return NotFound();
                    }
                    else
                    {
                        contexto.Entry(visita).State = System.Data.Entity.EntityState.Modified;
                        contexto.SaveChanges();
                        return Ok();
                    }
                }
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpDelete]
        public IHttpActionResult Eliminar(int id)
        {

            if (ModelState.IsValid)
            {
                using (ResidencialEntities residencialEntities = new ResidencialEntities())
                {
                    int eventoExiste;
                    eventoExiste = contexto.Visita.Count(s => s.idVisita == id);
                    if (eventoExiste == 0)
                    {
                        return NotFound();
                    }
                    else
                    {
                        Visita visita = contexto.Visita.FirstOrDefault(s => s.idVisita == id);
                        contexto.Visita.Remove(visita);
                        contexto.SaveChanges();
                        return Ok();
                    }
                }
            }
            else
            {
                return BadRequest();
            }

        }
    }
}