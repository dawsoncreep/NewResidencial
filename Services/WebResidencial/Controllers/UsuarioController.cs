using System;

using System.Collections.Generic;
using System.Web.Mvc;
using WebResidencial.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WebResidencial.Controllers
{
    using System.Configuration;

    public class UsuarioController : Controller
    {
        // GET: Usuario
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            List<Usuario> EmpInfo = new List<Usuario>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiServiceUrl"]);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/usuario/get");
                if (res.IsSuccessStatusCode)
                {
                    var EmpResponse = res.Content.ReadAsStringAsync().Result;
                    EmpInfo = JsonConvert.DeserializeObject<List<Usuario>>(EmpResponse);
                }
            }

            return View(EmpInfo);
        }

        public ActionResult Create()
        {
            Usuario user = new Usuario();
            return View(user);
        }

        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiServiceUrl"]);
                    var postTask = client.PostAsJsonAsync<Usuario>("api/usuario/AgregarUsuario", usuario);
                    postTask.Wait();
                    var result = postTask.Result;

                    if (result.IsSuccessStatusCode)
                        return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, "Error, contacta con el administrador");
                return View(usuario);

            }
            catch (Exception e)
            {
                return View(usuario);
            }
        }

        public async System.Threading.Tasks.Task<ActionResult> Edit(int id)
        {
            Usuario user = new Usuario();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiServiceUrl"]);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync(string.Format("api/usuario/get?idUser={0}",id));
                if (res.IsSuccessStatusCode)
                {
                    var EmpResponse = res.Content.ReadAsStringAsync().Result;
                    user = JsonConvert.DeserializeObject<Usuario>(EmpResponse);
                }
            }
            return View(user);

        }

        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiServiceUrl"]);

                    var res = client.PutAsJsonAsync<Usuario>("api/usuario/ActualizarUsuario", usuario);
                    
                    if (res.Result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }

                }
                ModelState.AddModelError(string.Empty, "Error, contacta con el administrador");
                return View(usuario);
            }
            catch (Exception e)
            {

                return View(usuario);
            }
        }

        public ActionResult Delete(int id)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiServiceUrl"]);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res =  client.DeleteAsync(string.Format("api/usuario/EliminarUsuario?id={0}", id)).Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, "Error, contacta con el administrador");
                return RedirectToAction("Index");
            }
        }
    }
}