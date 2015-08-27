using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using SiteCopaMovi.Models;

namespace SiteCopaMovi.Repositories
{
    public class IntegrantesRepositories
    {
        private DataContext db= new DataContext();
        private Integrantes integrantes;
        public void CadastrarIntegrante(Integrantes integrantes)
        {
        
             db.Integrantes.Add(integrantes);
             db.SaveChanges();
        
        }

        public Integrantes CriarClasse()
        {
            return db.Integrantes.Create();
        }

        public string  ExcluirIntegrante(string nome )
        {
            var equipe = (from a in db.Time where a.NOME_EQUIPE == nome select a).FirstOrDefault().TIMEID;
            var classe =(from a in db.Integrantes where a.CAPITAO==false&&a.TIMEID==equipe select a).ToList();
            foreach (var a in classe)
            {
                db.Entry(a).State = EntityState.Deleted;
                db.SaveChanges();
            }
         
            return "";
        }
    }
}