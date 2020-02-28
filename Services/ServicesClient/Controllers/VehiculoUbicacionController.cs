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
    public class VehiculoUbicacionController : ApiController
    {
        private ResidencialEntities db = new ResidencialEntities();

        // GET: api/VehiculoUbicacion
        public IQueryable<VehiculoUbicacion> GetVehiculoUbicacion()
        {
            return db.VehiculoUbicacion;
        }

        // GET: api/VehiculoUbicacion/5
        [ResponseType(typeof(VehiculoUbicacion))]
        public IHttpActionResult GetVehiculoUbicacion(int id)
        {
            VehiculoUbicacion vehiculoUbicacion = db.VehiculoUbicacion.Find(id);
            if (vehiculoUbicacion == null)
            {
                return NotFound();
            }

            return Ok(vehiculoUbicacion);
        }

        // PUT: api/VehiculoUbicacion/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVehiculoUbicacion(int id, VehiculoUbicacion vehiculoUbicacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vehiculoUbicacion.idVehiculo)
            {
                return BadRequest();
            }

            db.Entry(vehiculoUbicacion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiculoUbicacionExists(id))
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

        // POST: api/VehiculoUbicacion
        [ResponseType(typeof(VehiculoUbicacion))]
        public IHttpActionResult PostVehiculoUbicacion(VehiculoUbicacion vehiculoUbicacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VehiculoUbicacion.Add(vehiculoUbicacion);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (VehiculoUbicacionExists(vehiculoUbicacion.idVehiculo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vehiculoUbicacion.idVehiculo }, vehiculoUbicacion);
        }

        // DELETE: api/VehiculoUbicacion/5
        [ResponseType(typeof(VehiculoUbicacion))]
        public IHttpActionResult DeleteVehiculoUbicacion(int id)
        {
            VehiculoUbicacion vehiculoUbicacion = db.VehiculoUbicacion.Find(id);
            if (vehiculoUbicacion == null)
            {
                return NotFound();
            }

            db.VehiculoUbicacion.Remove(vehiculoUbicacion);
            db.SaveChanges();

            return Ok(vehiculoUbicacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VehiculoUbicacionExists(int id)
        {
            return db.VehiculoUbicacion.Count(e => e.idVehiculo == id) > 0;
        }
    }
}