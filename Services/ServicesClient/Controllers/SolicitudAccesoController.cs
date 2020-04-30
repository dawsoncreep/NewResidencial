using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ConectarDatos;

namespace ServicesClient.Controllers
{
    public class SolicitudAccesoController : ApiController
    {
        private ResidencialEntities db = new ResidencialEntities();

        // GET: api/SolicitudAcceso
        public IQueryable<SolicitudAcceso> GetSolicitudAcceso()
        {
            return db.SolicitudAcceso;
        }

        // GET: api/SolicitudAcceso/5
        [ResponseType(typeof(SolicitudAcceso))]
        public IHttpActionResult GetSolicitudAcceso(int id)
        {
            SolicitudAcceso solicitudAcceso = db.SolicitudAcceso.Find(id);
            if (solicitudAcceso == null)
            {
                return NotFound();
            }

            return Ok(solicitudAcceso);
        }

        // PUT: api/SolicitudAcceso/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSolicitudAcceso(int id, SolicitudAcceso solicitudAcceso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != solicitudAcceso.idVisita)
            {
                return BadRequest();
            }

            db.Entry(solicitudAcceso).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SolicitudAccesoExists(id))
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

        // POST: api/SolicitudAcceso
        [ResponseType(typeof(SolicitudAcceso))]
        public IHttpActionResult PostSolicitudAcceso(SolicitudAcceso solicitudAcceso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SolicitudAcceso.Add(solicitudAcceso);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SolicitudAccesoExists(solicitudAcceso.idVisita))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = solicitudAcceso.idVisita }, solicitudAcceso);
        }

        // DELETE: api/SolicitudAcceso/5
        [ResponseType(typeof(SolicitudAcceso))]
        public IHttpActionResult DeleteSolicitudAcceso(int id)
        {
            SolicitudAcceso solicitudAcceso = db.SolicitudAcceso.Find(id);
            if (solicitudAcceso == null)
            {
                return NotFound();
            }

            db.SolicitudAcceso.Remove(solicitudAcceso);
            db.SaveChanges();

            return Ok(solicitudAcceso);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SolicitudAccesoExists(int id)
        {
            return db.SolicitudAcceso.Count(e => e.idVisita == id) > 0;
        }
    }
}