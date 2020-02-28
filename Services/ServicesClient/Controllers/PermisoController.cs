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
    public class PermisoController : ApiController
    {
        private ResidencialEntities db = new ResidencialEntities();

        // GET: api/Permiso
        public IQueryable<Permiso> GetPermiso()
        {
            return db.Permiso;
        }

        // GET: api/Permiso/5
        [ResponseType(typeof(Permiso))]
        public IHttpActionResult GetPermiso(int id)
        {
            Permiso permiso = db.Permiso.Find(id);
            if (permiso == null)
            {
                return NotFound();
            }

            return Ok(permiso);
        }

        // PUT: api/Permiso/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPermiso(int id, Permiso permiso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != permiso.idPermiso)
            {
                return BadRequest();
            }

            db.Entry(permiso).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PermisoExists(id))
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

        // POST: api/Permiso
        [ResponseType(typeof(Permiso))]
        public IHttpActionResult PostPermiso(Permiso permiso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Permiso.Add(permiso);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PermisoExists(permiso.idPermiso))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = permiso.idPermiso }, permiso);
        }

        // DELETE: api/Permiso/5
        [ResponseType(typeof(Permiso))]
        public IHttpActionResult DeletePermiso(int id)
        {
            Permiso permiso = db.Permiso.Find(id);
            if (permiso == null)
            {
                return NotFound();
            }

            db.Permiso.Remove(permiso);
            db.SaveChanges();

            return Ok(permiso);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PermisoExists(int id)
        {
            return db.Permiso.Count(e => e.idPermiso == id) > 0;
        }
    }
}