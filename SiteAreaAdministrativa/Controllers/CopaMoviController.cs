using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteAreaAdministrativa.Controllers
{
    public class CopaMoviController : Controller
    {
        // GET: CopaMovi
        public ActionResult VisualizarTimes()
        {
            return View();
        }
        public ActionResult VisualizaTorcida()
        {
            return View();
        }
        public ActionResult VisualizarPatrocinadores()
        {
            return View();
        }
    }
}