using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using WebResidencial.Enums;
using WebResidencial.Models;

namespace WebResidencial.Controllers
{
    using System.Configuration;

    public class UbicacionController : Controller
    {
        // GET: Ubicacion
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            List<Ubicacion> ubicaciones = new List<Ubicacion>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiServiceUrl"]);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/Ubicacion");
                if (res.IsSuccessStatusCode)
                {
                    var EmpResponse = res.Content.ReadAsStringAsync().Result;
                    ubicaciones = JsonConvert.DeserializeObject<List<Ubicacion>>(EmpResponse);

                }
            }
            foreach (var item in ubicaciones)
            {
                item.TipoUbicacionNombre = Enum.GetName(typeof(TipoUbicacionStatus), item.IdTipoUbicacion);
            }
            return View(ubicaciones);
        }

        public ActionResult Create()
        {
            Ubicacion ubicacion = new Ubicacion();
            List<TipoUbicacion> EmpInfo = new List<TipoUbicacion>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiServiceUrl"]);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = client.GetAsync("api/tipoUbicacion").Result;
                if (res.IsSuccessStatusCode)
                {
                    var EmpResponse = res.Content.ReadAsStringAsync().Result;
                    EmpInfo = JsonConvert.DeserializeObject<List<TipoUbicacion>>(EmpResponse);
                }
            }
            ubicacion.TipoUbicacionList = EmpInfo;

            return View(ubicacion);
        }

        [HttpPost]
        public ActionResult Create(Ubicacion ubicacion)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiServiceUrl"]);
                    var postTask = client.PostAsJsonAsync<Ubicacion>("api/Ubicacion/AgregarUbicacion", ubicacion);
                    postTask.Wait();
                    var result = postTask.Result;

                    if (result.IsSuccessStatusCode)
                        return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, "Error, contacta con el administrador");
                return View(ubicacion);

            }
            catch (Exception e)
            {
                return View(ubicacion);
            }
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiServiceUrl"]);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = client.DeleteAsync(string.Format("api/Ubicacion/Eliminar?id={0}", id)).Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, "Error, contacta con el administrador");
                return RedirectToAction("Index");
            }
        }

        public ActionResult AddUser(int id)
        {
            Ubicacion ubicacion = new Ubicacion();
            List<Usuario> EmpInfo = new List<Usuario>();
            UbicacionUsuario ubicacionUsuario = new UbicacionUsuario();

            //Se trae la ubicación mediante el id de la ubicación
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiServiceUrl"]);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = client.GetAsync(string.Format("api/ubicacion/get?idUbicacion={0}", id)).Result;
                if (res.IsSuccessStatusCode)
                {
                    var EmpResponse = res.Content.ReadAsStringAsync().Result;
                    ubicacion = JsonConvert.DeserializeObject<Ubicacion>(EmpResponse);

                }
            }

            //Se traer la lista de usuarios
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiServiceUrl"]);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = client.GetAsync("api/usuario/get").Result;
                if (res.IsSuccessStatusCode)
                {
                    var EmpResponse = res.Content.ReadAsStringAsync().Result;
                    EmpInfo = JsonConvert.DeserializeObject<List<Usuario>>(EmpResponse);
                }
            }

            //Se manda los datos en para asignar los usarios a la ubicación
            ubicacionUsuario.IdUbicacion = id;
            ubicacionUsuario.Ubicacion = ubicacion;
            ubicacionUsuario.UsuariosLst = EmpInfo;

            return View(ubicacionUsuario);


        }

        [HttpPost]
        public ActionResult AddUser(UbicacionUsuario model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiServiceUrl"]);
                var postTask = client.PostAsJsonAsync<UbicacionUsuario>("api/usuarioUbicacion/Agregar", model);
                postTask.Wait();
                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "Error, contacta con el administrador");
            return View(model);
        }

        public ActionResult Detail(int id)
        {
            List<UbicacionUsuario> ubicacionUsuario = new List<UbicacionUsuario>();

            #region Relación de la ubicación con los usaurios
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiServiceUrl"]);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = client.GetAsync(string.Format("api/usuarioUbicacion/get?id={0}", id)).Result;
                if (res.IsSuccessStatusCode)
                {
                    var EmpResponse = res.Content.ReadAsStringAsync().Result;
                    ubicacionUsuario = JsonConvert.DeserializeObject<List<UbicacionUsuario>>(EmpResponse);

                }
            }
            #endregion

            #region Asginación de los a los usuarios
            //Traemos los usuarios
            List<Usuario> EmpInfo = new List<Usuario>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiServiceUrl"]);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = client.GetAsync("api/usuario/get").Result;
                if (res.IsSuccessStatusCode)
                {
                    var EmpResponse = res.Content.ReadAsStringAsync().Result;
                    EmpInfo = JsonConvert.DeserializeObject<List<Usuario>>(EmpResponse);
                }
            }
            //
            // Asiganamos los usuarios
            foreach (var item in ubicacionUsuario)
            {
                item.Usuario = EmpInfo.Find(x => x.IdUsuario == item.IdUsuario);
            }


            #endregion
            return View(ubicacionUsuario);
        }
    }
}