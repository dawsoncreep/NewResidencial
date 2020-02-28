using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ConectarDatos;

namespace ServicesClient.Controllers
{
    public class VisitaController : ApiController
    {
        private ResidencialEntities db = new ResidencialEntities();

        // GET: api/Visita
        public IQueryable<Visita> GetVisita()
        {
            return db.Visita;
        }

        // GET: api/Visita/5
        [ResponseType(typeof(Visita))]
        public async Task<IHttpActionResult> GetVisita(int id)
        {
            Visita visita = await db.Visita.FindAsync(id);
            if (visita == null)
            {
                return NotFound();
            }

            return Ok(visita);
        }

        // PUT: api/Visita/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVisita(int id, Visita visita)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != visita.idVisita)
            {
                return BadRequest();
            }

            db.Entry(visita).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitaExists(id))
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

        // POST: api/Visita
        [ResponseType(typeof(Visita))]
        public async Task<IHttpActionResult> PostVisita(Visita visita)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Visita.Add(visita);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VisitaExists(visita.idVisita))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = visita.idVisita }, visita);
        }

        // DELETE: api/Visita/5
        [ResponseType(typeof(Visita))]
        public async Task<IHttpActionResult> DeleteVisita(int id)
        {
            Visita visita = await db.Visita.FindAsync(id);
            if (visita == null)
            {
                return NotFound();
            }

            db.Visita.Remove(visita);
            await db.SaveChangesAsync();

            return Ok(visita);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VisitaExists(int id)
        {
            return db.Visita.Count(e => e.idVisita == id) > 0;
        }
    }
}