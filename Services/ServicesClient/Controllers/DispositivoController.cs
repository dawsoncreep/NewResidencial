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
    public class DispositivoController : ApiController
    {
        private ResidencialEntities db = new ResidencialEntities();

        // GET: api/Dispositivo
        public IQueryable<Dispositivo> GetDispositivo()
        {
            return db.Dispositivo;
        }

        // GET: api/Dispositivo/5
        [ResponseType(typeof(Dispositivo))]
        public IHttpActionResult GetDispositivo(int id)
        {
            Dispositivo dispositivo = db.Dispositivo.Find(id);
            if (dispositivo == null)
            {
                return NotFound();
            }

            return Ok(dispositivo);
        }

        // PUT: api/Dispositivo/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDispositivo(int id, Dispositivo dispositivo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dispositivo.idDispositivo)
            {
                return BadRequest();
            }

            db.Entry(dispositivo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DispositivoExists(id))
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

        // POST: api/Dispositivo
        [ResponseType(typeof(Dispositivo))]
        public IHttpActionResult PostDispositivo(Dispositivo dispositivo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Dispositivo.Add(dispositivo);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DispositivoExists(dispositivo.idDispositivo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = dispositivo.idDispositivo }, dispositivo);
        }

        // DELETE: api/Dispositivo/5
        [ResponseType(typeof(Dispositivo))]
        public IHttpActionResult DeleteDispositivo(int id)
        {
            Dispositivo dispositivo = db.Dispositivo.Find(id);
            if (dispositivo == null)
            {
                return NotFound();
            }

            db.Dispositivo.Remove(dispositivo);
            db.SaveChanges();

            return Ok(dispositivo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DispositivoExists(int id)
        {
            return db.Dispositivo.Count(e => e.idDispositivo == id) > 0;
        }
    }
}