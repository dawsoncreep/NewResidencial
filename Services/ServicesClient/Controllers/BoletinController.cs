using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ConectarDatos;

namespace ServicesClient.Controllers
{
    public class BoletinController : ApiController
    {
        private ResidencialEntities db = new ResidencialEntities();

        // GET: api/Boletin
        public IQueryable<Boletin> GetBoletin()
        {
            return db.Boletin;
        }

        // GET: api/Boletin/5
        [ResponseType(typeof(Boletin))]
        public IHttpActionResult GetBoletin(int id)
        {
            Boletin boletin = db.Boletin.Find(id);
            if (boletin == null)
            {
                return NotFound();
            }

            return Ok(boletin);
        }

        // PUT: api/Boletin/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBoletin(int id, Boletin boletin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != boletin.idBoletin)
            {
                return BadRequest();
            }

            db.Entry(boletin).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoletinExists(id))
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

        // POST: api/Boletin
        [ResponseType(typeof(Boletin))]
        public IHttpActionResult PostBoletin(Boletin boletin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Boletin.Add(boletin);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (BoletinExists(boletin.idBoletin))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = boletin.idBoletin }, boletin);
        }

        // DELETE: api/Boletin/5
        [ResponseType(typeof(Boletin))]
        public IHttpActionResult DeleteBoletin(int id)
        {
            Boletin boletin = db.Boletin.Find(id);
            if (boletin == null)
            {
                return NotFound();
            }

            db.Boletin.Remove(boletin);
            db.SaveChanges();

            return Ok(boletin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BoletinExists(int id)
        {
            return db.Boletin.Count(e => e.idBoletin == id) > 0;
        }
    }
}