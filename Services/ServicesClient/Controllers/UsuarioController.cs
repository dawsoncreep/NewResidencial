using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ConectarDatos;

namespace ServicesClient.Controllers
{
    public class UsuarioController : ApiController
    {
        private ResidencialEntities contexto = new ResidencialEntities();

        [HttpGet]
        public IEnumerable<Usuario> Get()
        {

            using (ResidencialEntities residencialEntities = new ResidencialEntities())
            {
                residencialEntities.Configuration.LazyLoadingEnabled = false;
                List<Usuario> lista = residencialEntities.Usuario.ToList<Usuario>();
                foreach (Usuario user in lista)
                {
                    List<UsuarioRol> roles = (List<UsuarioRol>)residencialEntities.UsuarioRol.Where(s => s.idUsuario == user.idUsuario).ToList();
                    user.UsuarioRol = roles;
                }
                return lista;
            }
        }


        [HttpGet]
        public Usuario Get(int idUser)
        {
            using (ResidencialEntities residencialEntities = new ResidencialEntities())
            {
                residencialEntities.Configuration.LazyLoadingEnabled = false;
                var user = residencialEntities.Usuario.FirstOrDefault(s => s.idUsuario == idUser);
                return user;

            }
        }

        [HttpPost]
        public IHttpActionResult AgregarUsuario([FromBody]Usuario usuario)
        {

            using (ResidencialEntities residencialEntities = new ResidencialEntities())
            {
                if (ModelState.IsValid)
                {

                    contexto.Usuario.Add(usuario);
                    contexto.SaveChanges();
                    return Ok(usuario);
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        [HttpPut]
        public IHttpActionResult ActualizarUsuario([FromBody]Usuario usuario)
        {


            if (ModelState.IsValid)
            {
                using (ResidencialEntities residencialEntities = new ResidencialEntities())
                {
                    int usuarioExiste;
                    usuarioExiste = contexto.Usuario.Count(s => s.idUsuario == usuario.idUsuario);
                    if (usuarioExiste == 0)
                    {
                        return NotFound();
                    }
                    else
                    {
                        contexto.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
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
        public IHttpActionResult EliminarUsuario(int id)
        {

            if (ModelState.IsValid)
            {
                using (ResidencialEntities residencialEntities = new ResidencialEntities())
                {
                    int usuarioExiste;
                    usuarioExiste = contexto.Usuario.Count(s => s.idUsuario == id);
                    Usuario usuario = contexto.Usuario.FirstOrDefault(s => s.idUsuario == id);
                    usuario.activo = false;
                    if (usuarioExiste == 0)
                    {
                        return NotFound();
                    }
                    else
                    {
                        contexto.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
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
