using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ConectarDatos;

namespace ServicesClient.Controllers
{
    public class EventoController : ApiController
    {
        private ResidencialEntities contexto = new ResidencialEntities();

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            using (ResidencialEntities residencialEntities = new ResidencialEntities())
            {
                residencialEntities.Configuration.LazyLoadingEnabled = false;
                List<Evento> lista = residencialEntities.Evento.ToList<Evento>();

                return lista;
            }
        }

        [HttpGet]
        public IEnumerable<Evento> GetEventoByUser(int idUser)
        {
            using (ResidencialEntities residencialEntities = new ResidencialEntities())
            {
                residencialEntities.Configuration.LazyLoadingEnabled = false;
                var Eventos = residencialEntities.Evento.ToList().Where(x => x.idUsuario == idUser);
                return Eventos;

            }
        }

        [HttpGet]
        public Evento GetEvento(int idEvento)
        {
            using (ResidencialEntities residencialEntities = new ResidencialEntities())
            {
                residencialEntities.Configuration.LazyLoadingEnabled = false;
                var Eventos = residencialEntities.Evento.FirstOrDefault(x => x.idEvento == idEvento);
                return Eventos;

            }
        }

        [HttpPost]
        public IHttpActionResult Agregar([FromBody]Evento evento)
        {

            using (ResidencialEntities residencialEntities = new ResidencialEntities())
            {
                if (ModelState.IsValid)
                {

                    contexto.Evento.Add(evento);
                    contexto.SaveChanges();
                    return Ok(evento);
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        [HttpPut]
        public IHttpActionResult Actualizar([FromBody]Evento evento)
        {


            if (ModelState.IsValid)
            {
                using (ResidencialEntities residencialEntities = new ResidencialEntities())
                {
                    int eventoExiste;
                    eventoExiste = contexto.Evento.Count(s => s.idEvento == evento.idEvento);
                    if (eventoExiste == 0)
                    {
                        return NotFound();
                    }
                    else
                    {
                        contexto.Entry(evento).State = System.Data.Entity.EntityState.Modified;
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
                    eventoExiste = contexto.Evento.Count(s => s.idEvento == id);
                    if (eventoExiste == 0)
                    {
                        return NotFound();
                    }
                    else
                    {
                        Evento evento = contexto.Evento.FirstOrDefault(s => s.idEvento == id);
                        contexto.Evento.Remove(evento);
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