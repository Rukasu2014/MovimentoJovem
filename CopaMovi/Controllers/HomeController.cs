using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CopaMovi.Models;
using CopaMovi.Repositories;

namespace CopaMovi.Controllers
{
    public class HomeController : Controller
    {
        private TimesRepositories timerepositorio =new TimesRepositories();
        private Time time=new Time();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Modalidades()
        {
            return View();
        }

        public ActionResult Patrocinadores()
        {
            return View();
        }

        public ActionResult FaleConosco()
        {
            return View();
        }

        public ActionResult GaleriaFotos()
        {
            return View();
        }
        public ActionResult PatrocinarEvento()
        {
            return View();
        }



        public ActionResult Inscricao()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Inscricao(Time time)
        {

            if (ModelState.IsValid)
            {
                timerepositorio.CadastrarTimes(time);

            }
            return View();
        }


    }
}