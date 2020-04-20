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
    public class usuarioUbicacionController : ApiController
    {
        private ResidencialEntities contexto = new ResidencialEntities();

        [HttpGet]
        public IEnumerable<usuarioUbicacion> Get()
        {

            using (ResidencialEntities residencialEntities = new ResidencialEntities())
            {
                residencialEntities.Configuration.LazyLoadingEnabled = false;
                List<usuarioUbicacion> lista = residencialEntities.usuarioUbicacion.ToList<usuarioUbicacion>();
                return lista;
            }
        }

        [HttpGet]
        public IEnumerable<usuarioUbicacion> Get(int id)
        {
            using (ResidencialEntities residencialEntities = new ResidencialEntities())
            {
                residencialEntities.Configuration.LazyLoadingEnabled = false;
                List<usuarioUbicacion> lista = residencialEntities.usuarioUbicacion.ToList<usuarioUbicacion>().Where(s => s.idUbicacion == id).ToList();
                return lista;

            }
        }

        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult Agregar([FromBody]usuarioUbicacion model)
        {

            using (ResidencialEntities residencialEntities = new ResidencialEntities())
            {
                if (ModelState.IsValid)
                {

                    contexto.usuarioUbicacion.Add(model);
                    contexto.SaveChanges();
                    return Ok(model);
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        [HttpDelete]
        public IHttpActionResult Eliminar(usuarioUbicacion model)
        {

            if (ModelState.IsValid)
            {
                using (ResidencialEntities residencialEntities = new ResidencialEntities())
                {
                    int existe;
                    existe = contexto.usuarioUbicacion.Count(s => s.idUbicacion == model.idUbicacion && s.idUsuario == model.idUsuario);
                    usuarioUbicacion ubicacion = contexto.usuarioUbicacion.FirstOrDefault(s => s.idUbicacion == model.idUbicacion && s.idUsuario == model.idUsuario);
                    if (existe == 0)
                    {
                        return NotFound();
                    }
                    else
                    {
                        contexto.usuarioUbicacion.Remove(ubicacion);
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