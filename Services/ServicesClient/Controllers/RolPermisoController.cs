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
    public class RolPermisoController : ApiController
    {
        private ResidencialEntities db = new ResidencialEntities();

        // GET: api/RolPermiso
        public IQueryable<RolPermiso> GetRolPermiso()
        {
            return db.RolPermiso;
        }

        // GET: api/RolPermiso/5
        [ResponseType(typeof(RolPermiso))]
        public IHttpActionResult GetRolPermiso(int id)
        {
            RolPermiso rolPermiso = db.RolPermiso.Find(id);
            if (rolPermiso == null)
            {
                return NotFound();
            }

            return Ok(rolPermiso);
        }

        // PUT: api/RolPermiso/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRolPermiso(int id, RolPermiso rolPermiso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rolPermiso.idRol)
            {
                return BadRequest();
            }

            db.Entry(rolPermiso).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolPermisoExists(id))
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

        // POST: api/RolPermiso
        [ResponseType(typeof(RolPermiso))]
        public IHttpActionResult PostRolPermiso(RolPermiso rolPermiso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RolPermiso.Add(rolPermiso);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RolPermisoExists(rolPermiso.idRol))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = rolPermiso.idRol }, rolPermiso);
        }

        // DELETE: api/RolPermiso/5
        [ResponseType(typeof(RolPermiso))]
        public IHttpActionResult DeleteRolPermiso(int id)
        {
            RolPermiso rolPermiso = db.RolPermiso.Find(id);
            if (rolPermiso == null)
            {
                return NotFound();
            }

            db.RolPermiso.Remove(rolPermiso);
            db.SaveChanges();

            return Ok(rolPermiso);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RolPermisoExists(int id)
        {
            return db.RolPermiso.Count(e => e.idRol == id) > 0;
        }
    }
}