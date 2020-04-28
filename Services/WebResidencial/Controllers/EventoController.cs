using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebResidencial.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WebResidencial.Controllers
{
    public class EventoController : Controller
    {
        string Baseurl = "http://localhost:2787/";
        // GET: Evento
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            List<Evento> EmpInfo = new List<Evento>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/Evento");
                if (res.IsSuccessStatusCode)
                {
                    var EmpResponse = res.Content.ReadAsStringAsync().Result;
                    EmpInfo = JsonConvert.DeserializeObject<List<Evento>>(EmpResponse);
                }
            }
            return View(EmpInfo);
        }
        public ActionResult Create()
        {
            Evento evento = new Evento();
            List<Ubicacion> EmpInfo = new List<Ubicacion>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = client.GetAsync("api/ubicacion").Result;
                if (res.IsSuccessStatusCode)
                {
                    var EmpResponse = res.Content.ReadAsStringAsync().Result;
                    EmpInfo = JsonConvert.DeserializeObject<List<Ubicacion>>(EmpResponse);
                }
            }
            evento.LstUbicaciones = EmpInfo;
            return View(evento);
        }

        [HttpPost]
        public ActionResult Create(Evento evento)
        {
            //valor de QR es el nombre del evento, el id del usuario y la fecha en la que se creo el usuario
            evento.QR = string.Format("{0}{1}{2}",evento.Nombre, "2", DateTime.Now.ToString());

            //Se agrega esta asignación de momento, ya que no hay loggin y manera de obtener el usuario
            evento.IdUsuario = 2;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    var postTask = client.PostAsJsonAsync<Evento>("api/Evento/Agregar", evento);
                    postTask.Wait();
                    var result = postTask.Result;

                    if (result.IsSuccessStatusCode)
                        return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, "Error, contacta con el administrador");
                return View(evento);

            }
            catch (Exception e)
            {
                return View(evento);
            }
        }

        public async System.Threading.Tasks.Task<ActionResult> Edit(int id)
        {
            Evento evento = new Evento();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync(string.Format("api/evento/GetEvento?idEvento={0}", id));
                if (res.IsSuccessStatusCode)
                {
                    var EmpResponse = res.Content.ReadAsStringAsync().Result;
                    evento = JsonConvert.DeserializeObject<Evento>(EmpResponse);
                }
            }

            List<Ubicacion> EmpInfo = new List<Ubicacion>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = client.GetAsync("api/ubicacion").Result;
                if (res.IsSuccessStatusCode)
                {
                    var EmpResponse = res.Content.ReadAsStringAsync().Result;
                    EmpInfo = JsonConvert.DeserializeObject<List<Ubicacion>>(EmpResponse);
                }
            }
            evento.LstUbicaciones = EmpInfo;
            TempData["inicio"] = evento.Inicio;
            TempData["fin"] = evento.Fin;


            return View(evento);

        }

        [HttpPost]
        public ActionResult Edit(Evento evento)
        {
            evento.Inicio = evento.Inicio ?? Convert.ToDateTime(TempData["inicio"]);
            evento.Fin = evento.Fin ?? Convert.ToDateTime(TempData["fin"]);

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);

                    var res = client.PutAsJsonAsync<Evento>("api/evento/Actualizar", evento);

                    if (res.Result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }

                }
                ModelState.AddModelError(string.Empty, "Error, contacta con el administrador");
                return View(evento);
            }
            catch (Exception e)
            {

                return View(evento);
            }
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = client.DeleteAsync(string.Format("api/Evento/Eliminar?id={0}", id)).Result;
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