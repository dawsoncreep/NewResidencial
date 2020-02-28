using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ConectarDatos;

namespace ServicesClient.Controllers
{
    public class EventoController : ApiController
    {
        private ResidencialEntities db = new ResidencialEntities();

        // GET: api/Evento
        public IQueryable<Evento> GetEvento()
        {
            return db.Evento;
        }

        // GET: api/Evento/5
        [ResponseType(typeof(Evento))]
        public IHttpActionResult GetEvento(int id)
        {
            Evento evento = db.Evento.Find(id);
            if (evento == null)
            {
                return NotFound();
            }

            return Ok(evento);
        }

        // PUT: api/Evento/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEvento(int id, Evento evento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != evento.idEvento)
            {
                return BadRequest();
            }

            db.Entry(evento).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Evento
        [ResponseType(typeof(Evento))]
        public IHttpActionResult PostEvento(Evento evento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Evento.Add(evento);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EventoExists(evento.idEvento))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = evento.idEvento }, evento);
        }

        // DELETE: api/Evento/5
        [ResponseType(typeof(Evento))]
        public IHttpActionResult DeleteEvento(int id)
        {
            Evento evento = db.Evento.Find(id);
            if (evento == null)
            {
                return NotFound();
            }

            db.Evento.Remove(evento);
            db.SaveChanges();

            return Ok(evento);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventoExists(int id)
        {
            return db.Evento.Count(e => e.idEvento == id) > 0;
        }
    }
}