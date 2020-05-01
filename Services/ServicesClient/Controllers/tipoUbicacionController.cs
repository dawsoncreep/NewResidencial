using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ConectarDatos;

namespace ServicesClient.Controllers
{
    public class tipoUbicacionController : ApiController
    {
        private ResidencialEntities db = new ResidencialEntities();

        // GET: api/tipoUbicacion
        [HttpGet]
        public IEnumerable<tipoUbicacion> Get()
        {

            using (ResidencialEntities residencialEntities = new ResidencialEntities())
            {
                residencialEntities.Configuration.LazyLoadingEnabled = false;
                List<tipoUbicacion> lista = residencialEntities.tipoUbicacion.ToList<tipoUbicacion>();
                return lista;
            }
        }

        // GET: api/tipoUbicacion/5
        [ResponseType(typeof(tipoUbicacion))]
        public IHttpActionResult GettipoUbicacion(int id)
        {
            tipoUbicacion tipoUbicacion = db.tipoUbicacion.Find(id);
            if (tipoUbicacion == null)
            {
                return NotFound();
            }

            return Ok(tipoUbicacion);
        }

        // PUT: api/tipoUbicacion/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttipoUbicacion(int id, tipoUbicacion tipoUbicacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoUbicacion.idTipoUbicacion)
            {
                return BadRequest();
            }

            db.Entry(tipoUbicacion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tipoUbicacionExists(id))
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

        // POST: api/tipoUbicacion
        [ResponseType(typeof(tipoUbicacion))]
        public IHttpActionResult PosttipoUbicacion(tipoUbicacion tipoUbicacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tipoUbicacion.Add(tipoUbicacion);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tipoUbicacionExists(tipoUbicacion.idTipoUbicacion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tipoUbicacion.idTipoUbicacion }, tipoUbicacion);
        }

        // DELETE: api/tipoUbicacion/5
        [ResponseType(typeof(tipoUbicacion))]
        public IHttpActionResult DeletetipoUbicacion(int id)
        {
            tipoUbicacion tipoUbicacion = db.tipoUbicacion.Find(id);
            if (tipoUbicacion == null)
            {
                return NotFound();
            }

            db.tipoUbicacion.Remove(tipoUbicacion);
            db.SaveChanges();

            return Ok(tipoUbicacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tipoUbicacionExists(int id)
        {
            return db.tipoUbicacion.Count(e => e.idTipoUbicacion == id) > 0;
        }
    }
}