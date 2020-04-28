using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebResidencial.Controllers
{
    public class VisitaController : Controller
    {
        // GET: Visita
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            return View();
        }
    }
}