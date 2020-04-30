using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ConectarDatos;

namespace ServicesClient.Controllers
{
    public class PersonalUbicacionController : ApiController
    {
        private ResidencialEntities db = new ResidencialEntities();

        // GET: api/PersonalUbicacion
        public IQueryable<PersonalUbicacion> GetPersonalUbicacion()
        {
            return db.PersonalUbicacion;
        }

        // GET: api/PersonalUbicacion/5
        [ResponseType(typeof(PersonalUbicacion))]
        public IHttpActionResult GetPersonalUbicacion(int id)
        {
            PersonalUbicacion personalUbicacion = db.PersonalUbicacion.Find(id);
            if (personalUbicacion == null)
            {
                return NotFound();
            }

            return Ok(personalUbicacion);
        }

        // PUT: api/PersonalUbicacion/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersonalUbicacion(int id, PersonalUbicacion personalUbicacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personalUbicacion.idPersonal)
            {
                return BadRequest();
            }

            db.Entry(personalUbicacion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalUbicacionExists(id))
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

        // POST: api/PersonalUbicacion
        [ResponseType(typeof(PersonalUbicacion))]
        public IHttpActionResult PostPersonalUbicacion(PersonalUbicacion personalUbicacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PersonalUbicacion.Add(personalUbicacion);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PersonalUbicacionExists(personalUbicacion.idPersonal))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = personalUbicacion.idPersonal }, personalUbicacion);
        }

        // DELETE: api/PersonalUbicacion/5
        [ResponseType(typeof(PersonalUbicacion))]
        public IHttpActionResult DeletePersonalUbicacion(int id)
        {
            PersonalUbicacion personalUbicacion = db.PersonalUbicacion.Find(id);
            if (personalUbicacion == null)
            {
                return NotFound();
            }

            db.PersonalUbicacion.Remove(personalUbicacion);
            db.SaveChanges();

            return Ok(personalUbicacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonalUbicacionExists(int id)
        {
            return db.PersonalUbicacion.Count(e => e.idPersonal == id) > 0;
        }
    }
}