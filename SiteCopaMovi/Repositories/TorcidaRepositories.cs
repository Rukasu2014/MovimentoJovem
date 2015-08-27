using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using SiteCopaMovi.Models;

namespace SiteCopaMovi.Repositories
{
    public class TorcidaRepositories
    {
        private DataContext db = new DataContext();
       
        public List<Torcida> RetornarTorcida(string  id)
        {
         
            var nometime = (from b in db.Time where b.NOME_EQUIPE == id select b).FirstOrDefault().TIMEID;
            var lista = (from a in db.Torcida where a.TIMEID == nometime select a).ToList();
            return lista;
        }

        public void CadastrarTorcida(string id, Torcida torcida)
        {
            var timeid = (from a in db.Time where a.NOME_EQUIPE == id select a).FirstOrDefault().TIMEID;

            torcida.TIMEID = timeid;
            db.Torcida.Add(torcida);
            db.SaveChanges();
        }
    }
}