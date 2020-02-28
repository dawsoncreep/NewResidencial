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
    public class IngresoSalidaPersonalController : ApiController
    {
        private ResidencialEntities db = new ResidencialEntities();

        // GET: api/IngresoSalidaPersonal
        public IQueryable<IngresoSalidaPersonal> GetIngresoSalidaPersonal()
        {
            return db.IngresoSalidaPersonal;
        }

        // GET: api/IngresoSalidaPersonal/5
        [ResponseType(typeof(IngresoSalidaPersonal))]
        public IHttpActionResult GetIngresoSalidaPersonal(int id)
        {
            IngresoSalidaPersonal ingresoSalidaPersonal = db.IngresoSalidaPersonal.Find(id);
            if (ingresoSalidaPersonal == null)
            {
                return NotFound();
            }

            return Ok(ingresoSalidaPersonal);
        }

        // PUT: api/IngresoSalidaPersonal/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIngresoSalidaPersonal(int id, IngresoSalidaPersonal ingresoSalidaPersonal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ingresoSalidaPersonal.idPersonal)
            {
                return BadRequest();
            }

            db.Entry(ingresoSalidaPersonal).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngresoSalidaPersonalExists(id))
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

        // POST: api/IngresoSalidaPersonal
        [ResponseType(typeof(IngresoSalidaPersonal))]
        public IHttpActionResult PostIngresoSalidaPersonal(IngresoSalidaPersonal ingresoSalidaPersonal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.IngresoSalidaPersonal.Add(ingresoSalidaPersonal);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (IngresoSalidaPersonalExists(ingresoSalidaPersonal.idPersonal))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ingresoSalidaPersonal.idPersonal }, ingresoSalidaPersonal);
        }

        // DELETE: api/IngresoSalidaPersonal/5
        [ResponseType(typeof(IngresoSalidaPersonal))]
        public IHttpActionResult DeleteIngresoSalidaPersonal(int id)
        {
            IngresoSalidaPersonal ingresoSalidaPersonal = db.IngresoSalidaPersonal.Find(id);
            if (ingresoSalidaPersonal == null)
            {
                return NotFound();
            }

            db.IngresoSalidaPersonal.Remove(ingresoSalidaPersonal);
            db.SaveChanges();

            return Ok(ingresoSalidaPersonal);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IngresoSalidaPersonalExists(int id)
        {
            return db.IngresoSalidaPersonal.Count(e => e.idPersonal == id) > 0;
        }
    }
}