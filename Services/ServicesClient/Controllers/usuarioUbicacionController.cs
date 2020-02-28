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
    public class usuarioUbicacionController : ApiController
    {
        private ResidencialEntities db = new ResidencialEntities();

        // GET: api/usuarioUbicacion
        public IQueryable<usuarioUbicacion> GetusuarioUbicacion()
        {
            return db.usuarioUbicacion;
        }

        // GET: api/usuarioUbicacion/5
        [ResponseType(typeof(usuarioUbicacion))]
        public IHttpActionResult GetusuarioUbicacion(int id)
        {
            usuarioUbicacion usuarioUbicacion = db.usuarioUbicacion.Find(id);
            if (usuarioUbicacion == null)
            {
                return NotFound();
            }

            return Ok(usuarioUbicacion);
        }

        // PUT: api/usuarioUbicacion/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutusuarioUbicacion(int id, usuarioUbicacion usuarioUbicacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuarioUbicacion.idUbicacion)
            {
                return BadRequest();
            }

            db.Entry(usuarioUbicacion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!usuarioUbicacionExists(id))
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

        // POST: api/usuarioUbicacion
        [ResponseType(typeof(usuarioUbicacion))]
        public IHttpActionResult PostusuarioUbicacion(usuarioUbicacion usuarioUbicacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.usuarioUbicacion.Add(usuarioUbicacion);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (usuarioUbicacionExists(usuarioUbicacion.idUbicacion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = usuarioUbicacion.idUbicacion }, usuarioUbicacion);
        }

        // DELETE: api/usuarioUbicacion/5
        [ResponseType(typeof(usuarioUbicacion))]
        public IHttpActionResult DeleteusuarioUbicacion(int id)
        {
            usuarioUbicacion usuarioUbicacion = db.usuarioUbicacion.Find(id);
            if (usuarioUbicacion == null)
            {
                return NotFound();
            }

            db.usuarioUbicacion.Remove(usuarioUbicacion);
            db.SaveChanges();

            return Ok(usuarioUbicacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool usuarioUbicacionExists(int id)
        {
            return db.usuarioUbicacion.Count(e => e.idUbicacion == id) > 0;
        }
    }
}