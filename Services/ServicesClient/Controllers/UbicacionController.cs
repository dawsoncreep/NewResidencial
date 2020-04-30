using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using ConectarDatos;

namespace ServicesClient.Controllers
{
    public class UbicacionController : ApiController
    {
        private ResidencialEntities contexto = new ResidencialEntities();

        // GET: api/Ubicacion
        [HttpGet]
        public IEnumerable<Ubicacion> Get()
        {

            using (ResidencialEntities residencialEntities = new ResidencialEntities())
            {
                residencialEntities.Configuration.LazyLoadingEnabled = false;
                List<Ubicacion> lista = residencialEntities.Ubicacion.ToList<Ubicacion>();
                return lista;
            }
        }

        [HttpGet]
        public Ubicacion Get(int idUbicacion)
        {
            using (ResidencialEntities residencialEntities = new ResidencialEntities())
            {
                residencialEntities.Configuration.LazyLoadingEnabled = false;
                var ubicacion = residencialEntities.Ubicacion.FirstOrDefault(s => s.idTipoUbicacion == idUbicacion);
                return ubicacion;

            }
        }

        [HttpPost]
        public IHttpActionResult AgregarUbicacion([FromBody]Ubicacion ubicacion)
        {

            using (ResidencialEntities residencialEntities = new ResidencialEntities())
            {
                if (ModelState.IsValid)
                {

                    contexto.Ubicacion.Add(ubicacion);
                    contexto.SaveChanges();
                    return Ok(ubicacion);
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        [HttpPut]
        public IHttpActionResult Actualizar([FromBody]Ubicacion ubicacion)
        {


            if (ModelState.IsValid)
            {
                using (ResidencialEntities residencialEntities = new ResidencialEntities())
                {
                    int ubicacionExiste;
                    ubicacionExiste = contexto.Ubicacion.Count(s => s.idUbicacion == ubicacion.idUbicacion);
                    if (ubicacionExiste == 0)
                    {
                        return NotFound();
                    }
                    else
                    {
                        contexto.Entry(ubicacion).State = System.Data.Entity.EntityState.Modified;
                        contexto.SaveChanges();
                        return Ok();
                    }
                }
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpDelete]
        public IHttpActionResult Eliminar(int id)
        {

            if (ModelState.IsValid)
            {
                using (ResidencialEntities residencialEntities = new ResidencialEntities())
                {
                    int existe;
                    existe = contexto.Ubicacion.Count(s => s.idUbicacion == id);
                    Ubicacion ubicacion = contexto.Ubicacion.FirstOrDefault(s => s.idUbicacion == id);
                    if (existe == 0)
                    {
                        return NotFound();
                    }
                    else
                    {
                        contexto.Ubicacion.Remove(ubicacion);
                        contexto.SaveChanges();
                        return Ok();
                    }
                }
            }
            else
            {
                return BadRequest();
            }

        }
    }
}