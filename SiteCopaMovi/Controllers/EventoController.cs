using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

using SiteCopaMovi.Models;
using SiteCopaMovi.Repositories;

namespace SiteCopaMovi.Controllers
{
    public class EventoController : Controller
    {
        private TimesRepositories timerepositorio =new TimesRepositories();
        private IntegrantesRepositories integrantesrepositorio = new IntegrantesRepositories();
        private TorcidaRepositories torcidarepositorio = new TorcidaRepositories();
        private  FaleConoscoRepositories faleConoscoRepositories= new FaleConoscoRepositories();
        private PatrocinadorRepositories patrocinadorRepositories =new PatrocinadorRepositories();
        
        // GET: Home


        public ActionResult Index()
        {
            return View();
        }
        public ActionResult OqueeCopaMovi()
        {
            return View();
        }
        public ActionResult CotasPatrocinio()
        {
            return View();
        }
        public ActionResult ConcluirCadastro()
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FaleConosco(FaleConosco conosco)
        {
           faleConoscoRepositories.EnviarEmail(conosco);
            return RedirectToAction("ConcluirFaleConosco", "Evento");
        }
        public ActionResult ConcluirFaleConosco()
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
            if (timerepositorio.VerificarNome(time.NOME_EQUIPE))
            {
                 if (ModelState.IsValid)
                    {
                        var nome =timerepositorio.CadastrarTimes(time);
                        return RedirectToAction("CadastroDeMembrosEquipe/" + nome.NOME_EQUIPE, "Evento");
                    }
            }
            ModelState.AddModelError("", "Digite um nome de Time diferente!");
            return View();
        }
        public ActionResult CadastroDeMembrosEquipe(string id)
        {
            var classe = integrantesrepositorio.CriarClasse();
            ViewBag.nome=timerepositorio.RetornarNomeCapitao(id);
            ViewBag.lista = timerepositorio.RetornarJogadoresTime(id);
            classe.TIMEID = timerepositorio.RetornaIdTime(id);
            return View(classe);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastroDeMembrosEquipe(Integrantes integrantes,string id)
        {
            integrantes.TIMEID = timerepositorio.RetornaIdTime(id);
            integrantesrepositorio.CadastrarIntegrante(integrantes);
            var classe = integrantesrepositorio.CriarClasse();
            classe.NOME_JOGADORES = "";
            classe.RG = "";
            classe.DATA_NASCIMENTO =DateTime.Now;
            ViewBag.nome = timerepositorio.RetornarNomeCapitao(id);
            ViewBag.lista = timerepositorio.RetornarJogadoresTime(id);
            return View(classe);
        }
        public ActionResult CadastroTorcida(string id)
        {
            ViewBag.nome = timerepositorio.RetornarNomeCapitao(id);
            ViewBag.lista = torcidarepositorio.RetornarTorcida(id);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastroTorcida(Torcida torcida ,string id)
        {
            ViewBag.nome = timerepositorio.RetornarNomeCapitao(id);
            ViewBag.lista = torcidarepositorio.RetornarTorcida(id);
            torcidarepositorio.CadastrarTorcida(id,torcida);
            return View();
        }

        public ActionResult CadastroPatrocinador()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastroPatrocinador(Patrocinador patrocinador)
        {
            patrocinadorRepositories.EnviarEmailPatrocinador(patrocinador);
            return RedirectToAction("ConcluirPatrocinio", "Evento");
        }

        public ActionResult ConcluirPatrocinio()
        {
            return View();
        }
      
        public ActionResult Excluir(string id)
        {
            integrantesrepositorio.ExcluirIntegrante(id);
            return RedirectToAction("CadastroDeMembrosEquipe/" + id);
        }
    }
}