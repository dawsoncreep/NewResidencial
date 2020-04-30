using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ConectarDatos;

namespace ServicesClient.Controllers
{
    public class VehiculoController : ApiController
    {
        private ResidencialEntities db = new ResidencialEntities();

        // GET: api/Vehiculo
        public IQueryable<Vehiculo> GetVehiculo()
        {
            return db.Vehiculo;
        }

        // GET: api/Vehiculo/5
        [ResponseType(typeof(Vehiculo))]
        public IHttpActionResult GetVehiculo(int id)
        {
            Vehiculo vehiculo = db.Vehiculo.Find(id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            return Ok(vehiculo);
        }

        // PUT: api/Vehiculo/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVehiculo(int id, Vehiculo vehiculo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vehiculo.idVehiculo)
            {
                return BadRequest();
            }

            db.Entry(vehiculo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiculoExists(id))
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

        // POST: api/Vehiculo
        [ResponseType(typeof(Vehiculo))]
        public IHttpActionResult PostVehiculo(Vehiculo vehiculo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Vehiculo.Add(vehiculo);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (VehiculoExists(vehiculo.idVehiculo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vehiculo.idVehiculo }, vehiculo);
        }

        // DELETE: api/Vehiculo/5
        [ResponseType(typeof(Vehiculo))]
        public IHttpActionResult DeleteVehiculo(int id)
        {
            Vehiculo vehiculo = db.Vehiculo.Find(id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            db.Vehiculo.Remove(vehiculo);
            db.SaveChanges();

            return Ok(vehiculo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VehiculoExists(int id)
        {
            return db.Vehiculo.Count(e => e.idVehiculo == id) > 0;
        }
    }
}