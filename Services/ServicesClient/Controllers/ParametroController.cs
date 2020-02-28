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
    public class ParametroController : ApiController
    {
        private ResidencialEntities db = new ResidencialEntities();

        // GET: api/Parametroes
        public IQueryable<Parametro> GetParametro()
        {
            return db.Parametro;
        }

        // GET: api/Parametroes/5
        [ResponseType(typeof(Parametro))]
        public IHttpActionResult GetParametro(string id)
        {
            Parametro parametro = db.Parametro.Find(id);
            if (parametro == null)
            {
                return NotFound();
            }

            return Ok(parametro);
        }

        // PUT: api/Parametroes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutParametro(string id, Parametro parametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != parametro.name)
            {
                return BadRequest();
            }

            db.Entry(parametro).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParametroExists(id))
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

        // POST: api/Parametroes
        [ResponseType(typeof(Parametro))]
        public IHttpActionResult PostParametro(Parametro parametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Parametro.Add(parametro);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ParametroExists(parametro.name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = parametro.name }, parametro);
        }

        // DELETE: api/Parametroes/5
        [ResponseType(typeof(Parametro))]
        public IHttpActionResult DeleteParametro(string id)
        {
            Parametro parametro = db.Parametro.Find(id);
            if (parametro == null)
            {
                return NotFound();
            }

            db.Parametro.Remove(parametro);
            db.SaveChanges();

            return Ok(parametro);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ParametroExists(string id)
        {
            return db.Parametro.Count(e => e.name == id) > 0;
        }
    }
}