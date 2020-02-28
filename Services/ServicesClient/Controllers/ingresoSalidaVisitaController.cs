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
    public class ingresoSalidaVisitaController : ApiController
    {
        private ResidencialEntities db = new ResidencialEntities();

        // GET: api/ingresoSalidaVisita
        public IQueryable<ingresoSalidaVisita> GetingresoSalidaVisita()
        {
            return db.ingresoSalidaVisita;
        }

        // GET: api/ingresoSalidaVisita/5
        [ResponseType(typeof(ingresoSalidaVisita))]
        public IHttpActionResult GetingresoSalidaVisita(int id)
        {
            ingresoSalidaVisita ingresoSalidaVisita = db.ingresoSalidaVisita.Find(id);
            if (ingresoSalidaVisita == null)
            {
                return NotFound();
            }

            return Ok(ingresoSalidaVisita);
        }

        // PUT: api/ingresoSalidaVisita/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutingresoSalidaVisita(int id, ingresoSalidaVisita ingresoSalidaVisita)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ingresoSalidaVisita.idVisita)
            {
                return BadRequest();
            }

            db.Entry(ingresoSalidaVisita).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ingresoSalidaVisitaExists(id))
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

        // POST: api/ingresoSalidaVisita
        [ResponseType(typeof(ingresoSalidaVisita))]
        public IHttpActionResult PostingresoSalidaVisita(ingresoSalidaVisita ingresoSalidaVisita)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ingresoSalidaVisita.Add(ingresoSalidaVisita);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ingresoSalidaVisitaExists(ingresoSalidaVisita.idVisita))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ingresoSalidaVisita.idVisita }, ingresoSalidaVisita);
        }

        // DELETE: api/ingresoSalidaVisita/5
        [ResponseType(typeof(ingresoSalidaVisita))]
        public IHttpActionResult DeleteingresoSalidaVisita(int id)
        {
            ingresoSalidaVisita ingresoSalidaVisita = db.ingresoSalidaVisita.Find(id);
            if (ingresoSalidaVisita == null)
            {
                return NotFound();
            }

            db.ingresoSalidaVisita.Remove(ingresoSalidaVisita);
            db.SaveChanges();

            return Ok(ingresoSalidaVisita);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ingresoSalidaVisitaExists(int id)
        {
            return db.ingresoSalidaVisita.Count(e => e.idVisita == id) > 0;
        }
    }
}