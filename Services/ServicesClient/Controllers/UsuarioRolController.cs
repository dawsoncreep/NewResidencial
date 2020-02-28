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
    public class UsuarioRolController : ApiController
    {
        private ResidencialEntities db = new ResidencialEntities();

        // GET: api/UsuarioRol
        public IQueryable<UsuarioRol> GetUsuarioRol()
        {
            return db.UsuarioRol;
        }

        // GET: api/UsuarioRol/5
        [ResponseType(typeof(UsuarioRol))]
        public IHttpActionResult GetUsuarioRol(int id)
        {
            UsuarioRol usuarioRol = db.UsuarioRol.Find(id);
            if (usuarioRol == null)
            {
                return NotFound();
            }

            return Ok(usuarioRol);
        }

        // PUT: api/UsuarioRol/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsuarioRol(int id, UsuarioRol usuarioRol)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuarioRol.idUsuario)
            {
                return BadRequest();
            }

            db.Entry(usuarioRol).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioRolExists(id))
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

        // POST: api/UsuarioRol
        [ResponseType(typeof(UsuarioRol))]
        public IHttpActionResult PostUsuarioRol(UsuarioRol usuarioRol)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UsuarioRol.Add(usuarioRol);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UsuarioRolExists(usuarioRol.idUsuario))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = usuarioRol.idUsuario }, usuarioRol);
        }

        // DELETE: api/UsuarioRol/5
        [ResponseType(typeof(UsuarioRol))]
        public IHttpActionResult DeleteUsuarioRol(int id)
        {
            UsuarioRol usuarioRol = db.UsuarioRol.Find(id);
            if (usuarioRol == null)
            {
                return NotFound();
            }

            db.UsuarioRol.Remove(usuarioRol);
            db.SaveChanges();

            return Ok(usuarioRol);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuarioRolExists(int id)
        {
            return db.UsuarioRol.Count(e => e.idUsuario == id) > 0;
        }
    }
}