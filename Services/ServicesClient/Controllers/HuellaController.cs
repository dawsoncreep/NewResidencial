using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ConectarDatos;

namespace ServicesClient.Controllers
{
    public class HuellaController : ApiController
    {
        private ResidencialEntities db = new ResidencialEntities();

        // GET: api/Huella
        public IQueryable<Huella> GetHuella()
        {
            return db.Huella;
        }

        // GET: api/Huella/5
        [ResponseType(typeof(Huella))]
        public IHttpActionResult GetHuella(int id)
        {
            Huella huella = db.Huella.Find(id);
            if (huella == null)
            {
                return NotFound();
            }

            return Ok(huella);
        }

        // PUT: api/Huella/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHuella(int id, Huella huella)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != huella.idHuella)
            {
                return BadRequest();
            }

            db.Entry(huella).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HuellaExists(id))
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

        // POST: api/Huella
        [ResponseType(typeof(Huella))]
        public IHttpActionResult PostHuella(Huella huella)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Huella.Add(huella);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (HuellaExists(huella.idHuella))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = huella.idHuella }, huella);
        }

        // DELETE: api/Huella/5
        [ResponseType(typeof(Huella))]
        public IHttpActionResult DeleteHuella(int id)
        {
            Huella huella = db.Huella.Find(id);
            if (huella == null)
            {
                return NotFound();
            }

            db.Huella.Remove(huella);
            db.SaveChanges();

            return Ok(huella);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HuellaExists(int id)
        {
            return db.Huella.Count(e => e.idHuella == id) > 0;
        }
    }
}