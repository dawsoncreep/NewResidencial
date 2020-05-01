using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ConectarDatos;

namespace ServicesClient.Controllers
{
    public class FotoEventoSalidaController : ApiController
    {
        private ResidencialEntities db = new ResidencialEntities();

        // GET: api/FotoEventoSalida
        public IQueryable<FotoEventoSalida> GetFotoEventoSalida()
        {
            return db.FotoEventoSalida;
        }

        // GET: api/FotoEventoSalida/5
        [ResponseType(typeof(FotoEventoSalida))]
        public IHttpActionResult GetFotoEventoSalida(int id)
        {
            FotoEventoSalida fotoEventoSalida = db.FotoEventoSalida.Find(id);
            if (fotoEventoSalida == null)
            {
                return NotFound();
            }

            return Ok(fotoEventoSalida);
        }

        // PUT: api/FotoEventoSalida/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFotoEventoSalida(int id, FotoEventoSalida fotoEventoSalida)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fotoEventoSalida.idFotoEventoSalida)
            {
                return BadRequest();
            }

            db.Entry(fotoEventoSalida).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FotoEventoSalidaExists(id))
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

        // POST: api/FotoEventoSalida
        [ResponseType(typeof(FotoEventoSalida))]
        public IHttpActionResult PostFotoEventoSalida(FotoEventoSalida fotoEventoSalida)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FotoEventoSalida.Add(fotoEventoSalida);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (FotoEventoSalidaExists(fotoEventoSalida.idFotoEventoSalida))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = fotoEventoSalida.idFotoEventoSalida }, fotoEventoSalida);
        }

        // DELETE: api/FotoEventoSalida/5
        [ResponseType(typeof(FotoEventoSalida))]
        public IHttpActionResult DeleteFotoEventoSalida(int id)
        {
            FotoEventoSalida fotoEventoSalida = db.FotoEventoSalida.Find(id);
            if (fotoEventoSalida == null)
            {
                return NotFound();
            }

            db.FotoEventoSalida.Remove(fotoEventoSalida);
            db.SaveChanges();

            return Ok(fotoEventoSalida);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FotoEventoSalidaExists(int id)
        {
            return db.FotoEventoSalida.Count(e => e.idFotoEventoSalida == id) > 0;
        }
    }
}