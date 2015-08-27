using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SiteCopaMovi.Models;


namespace SiteCopaMovi.Repositories
{
    public class TimesRepositories
    {
        private DataContext db = new DataContext();
        private List<SelectListItem> lista;
        private Integrantes integrantes;
        public Time CadastrarTimes(Time time)
        {

            db.Time.Add(time);

            db.SaveChanges();
            var nome = (from a in db.Time where a.NOME_EQUIPE == time.NOME_EQUIPE select a).FirstOrDefault();
            integrantes=new Integrantes();
            integrantes.NOME_JOGADORES = time.CAPITAO_DO_TIME;
            integrantes.RG = time.RG_CAPITAO;
            integrantes.DATA_NASCIMENTO = time.DATA_NASCIMENTO_CAPITAO;
            integrantes.TIMEID = nome.TIMEID;
            integrantes.CAPITAO = true;
            db.Integrantes.Add(integrantes);
            db.SaveChanges();
            return nome;
        }

        public List<SelectListItem> RetornarListaSexo()
        {
            lista = new List<SelectListItem>();
            lista.Add(new SelectListItem { Text = "Masculino", Value = "Masculino" });
            lista.Add(new SelectListItem { Text = "Feminino", Value = "Feminino" });
            return lista;
        }

        public List<SelectListItem> RetornarListaModalidade()
        {
            lista = new List<SelectListItem>();
            lista.Add(new SelectListItem { Text = "Futebol", Value = "Futebol" });
            lista.Add(new SelectListItem { Text = "Voleibol", Value = "Voleibol" });
            return lista;
        }

        public List<SelectListItem> RetornarEntidades()
        {
            lista = new List<SelectListItem>();
            lista.Add(new SelectListItem { Text = "Nippon Country Club", Value = "Nippon Country Club" });
            lista.Add(new SelectListItem { Text = "Seinenkai Vila Carrão", Value = "Seinenkai Vila Carrão" });
            lista.Add(new SelectListItem { Text = "Seinenkai Ribeirão Pires", Value = "Seinenkai Ribeirão Pires" });
            lista.Add(new SelectListItem { Text = "Seinenkai Biritiba Mirim", Value = "Seinenkai Biritiba Mirim" });
            lista.Add(new SelectListItem { Text = "Aliança Beneficente Universitária de São Paulo (ABEUNI)", Value = "Aliança Beneficente Universitária de São Paulo (ABEUNI)" });
            lista.Add(new SelectListItem { Text = "Movimento Jovem", Value = "Movimento Jovem" });
            lista.Add(new SelectListItem { Text = "Instituto Cultural Nipo Brasileiro de Campinas", Value = "Instituto Cultural Nipo Brasileiro de Campinas" }); ;
            lista.Add(new SelectListItem { Text = "Clube Cultural e Recreativo Nipo-Brasileiro de Brasília", Value = "Clube Cultural e Recreativo Nipo-Brasileiro de Brasília" });
            lista.Add(new SelectListItem { Text = "União dos Gakusseis de Curitiba", Value = "União dos Gakusseis de Curitiba" });
            lista.Add(new SelectListItem { Text = "Associação Mineira de Cultura Nipo-Brasileira", Value = "Associação Mineira de Cultura Nipo-Brasileira" });
            lista.Add(new SelectListItem { Text = "Sociedade Brasileira de Cultura Japonesa e de Assistência Social (Bunkyo-SP)", Value = "Sociedade Brasileira de Cultura Japonesa e de Assistência Social (Bunkyo-SP)" });
            lista.Add(new SelectListItem { Text = "Associação Cultural de Mogi das Cruzes", Value = "Associação Cultural de Mogi das Cruzes" });
            lista.Add(new SelectListItem { Text = "Outra", Value = "Outra" });
            return lista;

        }

        public Time RetornarNomeCapitao(string nome)
        {
            var time = (from a in db.Time where a.NOME_EQUIPE == nome select a).FirstOrDefault();
            return time;
        }

        public List<Integrantes> RetornarJogadoresTime(string id)
        {
            var nome = (from a in db.Time where a.NOME_EQUIPE == id select a).FirstOrDefault();
            var lista = (from a in db.Integrantes where a.TIMEID == nome.TIMEID select a).ToList();
            return lista;
        }

        public bool VerificarNome(string id)
        {
            var nome = (from a in db.Time where a.NOME_EQUIPE == id select a).ToList();
            if (nome.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public int RetornaIdTime(string nome)
        {
            var id = (from a in db.Time where a.NOME_EQUIPE == nome select a).FirstOrDefault().TIMEID;
            return id;
        }
    }
}