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
    public class UbicacionController : ApiController
    {
        private ResidencialEntities db = new ResidencialEntities();

        // GET: api/Ubicacion
        public IQueryable<Ubicacion> GetUbicacion()
        {
            return db.Ubicacion;
        }

        // GET: api/Ubicacion/5
        [ResponseType(typeof(Ubicacion))]
        public IHttpActionResult GetUbicacion(int id)
        {
            Ubicacion ubicacion = db.Ubicacion.Find(id);
            if (ubicacion == null)
            {
                return NotFound();
            }

            return Ok(ubicacion);
        }

        // PUT: api/Ubicacion/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUbicacion(int id, Ubicacion ubicacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ubicacion.idUbicacion)
            {
                return BadRequest();
            }

            db.Entry(ubicacion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UbicacionExists(id))
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

        // POST: api/Ubicacion
        [ResponseType(typeof(Ubicacion))]
        public IHttpActionResult PostUbicacion(Ubicacion ubicacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ubicacion.Add(ubicacion);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UbicacionExists(ubicacion.idUbicacion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ubicacion.idUbicacion }, ubicacion);
        }

        // DELETE: api/Ubicacion/5
        [ResponseType(typeof(Ubicacion))]
        public IHttpActionResult DeleteUbicacion(int id)
        {
            Ubicacion ubicacion = db.Ubicacion.Find(id);
            if (ubicacion == null)
            {
                return NotFound();
            }

            db.Ubicacion.Remove(ubicacion);
            db.SaveChanges();

            return Ok(ubicacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UbicacionExists(int id)
        {
            return db.Ubicacion.Count(e => e.idUbicacion == id) > 0;
        }
    }
}