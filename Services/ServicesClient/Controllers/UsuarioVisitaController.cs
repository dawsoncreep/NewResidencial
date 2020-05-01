using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ConectarDatos;

namespace ServicesClient.Controllers
{
    public class UsuarioVisitaController : ApiController
    {
        private ResidencialEntities db = new ResidencialEntities();

        // GET: api/UsuarioVisita
        public IQueryable<UsuarioVisita> GetUsuarioVisita()
        {
            return db.UsuarioVisita;
        }

        // GET: api/UsuarioVisita/5
        [ResponseType(typeof(UsuarioVisita))]
        public IHttpActionResult GetUsuarioVisita(int id)
        {
            UsuarioVisita usuarioVisita = db.UsuarioVisita.Find(id);
            if (usuarioVisita == null)
            {
                return NotFound();
            }

            return Ok(usuarioVisita);
        }

        // PUT: api/UsuarioVisita/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsuarioVisita(int id, UsuarioVisita usuarioVisita)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuarioVisita.idUsuario)
            {
                return BadRequest();
            }

            db.Entry(usuarioVisita).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioVisitaExists(id))
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

        // POST: api/UsuarioVisita
        [ResponseType(typeof(UsuarioVisita))]
        public IHttpActionResult PostUsuarioVisita(UsuarioVisita usuarioVisita)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UsuarioVisita.Add(usuarioVisita);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UsuarioVisitaExists(usuarioVisita.idUsuario))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = usuarioVisita.idUsuario }, usuarioVisita);
        }

        // DELETE: api/UsuarioVisita/5
        [ResponseType(typeof(UsuarioVisita))]
        public IHttpActionResult DeleteUsuarioVisita(int id)
        {
            UsuarioVisita usuarioVisita = db.UsuarioVisita.Find(id);
            if (usuarioVisita == null)
            {
                return NotFound();
            }

            db.UsuarioVisita.Remove(usuarioVisita);
            db.SaveChanges();

            return Ok(usuarioVisita);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuarioVisitaExists(int id)
        {
            return db.UsuarioVisita.Count(e => e.idUsuario == id) > 0;
        }
    }
}