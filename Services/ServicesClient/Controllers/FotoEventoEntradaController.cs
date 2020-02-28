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
    public class FotoEventoEntradaController : ApiController
    {
        private ResidencialEntities db = new ResidencialEntities();

        // GET: api/FotoEventoEntrada
        public IQueryable<FotoEventoEntrada> GetFotoEventoEntrada()
        {
            return db.FotoEventoEntrada;
        }

        // GET: api/FotoEventoEntrada/5
        [ResponseType(typeof(FotoEventoEntrada))]
        public IHttpActionResult GetFotoEventoEntrada(int id)
        {
            FotoEventoEntrada fotoEventoEntrada = db.FotoEventoEntrada.Find(id);
            if (fotoEventoEntrada == null)
            {
                return NotFound();
            }

            return Ok(fotoEventoEntrada);
        }

        // PUT: api/FotoEventoEntrada/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFotoEventoEntrada(int id, FotoEventoEntrada fotoEventoEntrada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fotoEventoEntrada.idFotoEvento)
            {
                return BadRequest();
            }

            db.Entry(fotoEventoEntrada).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FotoEventoEntradaExists(id))
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

        // POST: api/FotoEventoEntrada
        [ResponseType(typeof(FotoEventoEntrada))]
        public IHttpActionResult PostFotoEventoEntrada(FotoEventoEntrada fotoEventoEntrada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FotoEventoEntrada.Add(fotoEventoEntrada);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (FotoEventoEntradaExists(fotoEventoEntrada.idFotoEvento))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = fotoEventoEntrada.idFotoEvento }, fotoEventoEntrada);
        }

        // DELETE: api/FotoEventoEntrada/5
        [ResponseType(typeof(FotoEventoEntrada))]
        public IHttpActionResult DeleteFotoEventoEntrada(int id)
        {
            FotoEventoEntrada fotoEventoEntrada = db.FotoEventoEntrada.Find(id);
            if (fotoEventoEntrada == null)
            {
                return NotFound();
            }

            db.FotoEventoEntrada.Remove(fotoEventoEntrada);
            db.SaveChanges();

            return Ok(fotoEventoEntrada);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FotoEventoEntradaExists(int id)
        {
            return db.FotoEventoEntrada.Count(e => e.idFotoEvento == id) > 0;
        }
    }
}