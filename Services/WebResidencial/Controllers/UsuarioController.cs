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
    public class UsuarioController : Controller
    {
        string Baseurl = "http://10.92.184.7:8070";
        // GET: Usuario
        public async System.Threading.Tasks.Task<ActionResult> IndexAsync()
        {
            List<Usuario> EmpInfo = new List<Usuario>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/usuario");
                if (res.IsSuccessStatusCode)
                {
                    var EmpResponse = res.Content.ReadAsStringAsync().Result;
                    EmpInfo = JsonConvert.DeserializeObject<List<Usuario>>(EmpResponse);
                }
            }

            return View(EmpInfo);
        }
    }
}