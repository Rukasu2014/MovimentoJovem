using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using SiteCopaMovi.Models;

namespace SiteCopaMovi.Repositories
{
    public class PatrocinadorRepositories
    {
        private DataContext db=new DataContext();

        public List<SelectListItem> CriarLista()
        {
            List<SelectListItem> lista = new List<SelectListItem>();
            lista.Add(new SelectListItem{Text = "Cota Diamente - R$2.000,00"});
            lista.Add(new SelectListItem {Text = "Cota Ouro - R$1.000,00"});
            lista.Add(new SelectListItem {Text = "Cota Prata - R$300,00"});
            lista.Add(new SelectListItem {Text = "Cota Bronze - R$100,00"});
            return lista;
        }

        public void EnviarEmailPatrocinador(Patrocinador patrocinador)
        {
              MailMessage mail = new MailMessage("faleconoscocopamovi@gmail.com", "fabio_luiz1991@hotmail.com");
                SmtpClient client = new SmtpClient();
                CriarEmail(patrocinador, client, mail);
        }

         
      public void CriarEmail(Patrocinador patrocinador, SmtpClient client, MailMessage mail)
        {
            client.Credentials = new System.Net.NetworkCredential("faleconoscocopamovi@gmail.com", "movimente");
            client.EnableSsl = true;
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Host = "smtp.gmail.com";
            mail.Subject = "Patrocinio Copa Movi";
            mail.Body = CriarHtml(patrocinador);
            mail.IsBodyHtml = true;
            client.Send(mail);
        }
        public string CriarHtml(Patrocinador pf)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<html xmlns='http://www.w3.org/1999/xhtml'>");
            sb.Append("<head>");
            sb.Append("<meta content='text/html; charset=utf-8' http-equiv='Content-Type'>");
            sb.Append("<title>Contato Site Copa Movi</title>");
            sb.Append("</head>");
            sb.Append("<body bgcolor='#FFFFFF' leftmargin='0' marginheight='0' marginwidth='0' topmargin='0'>");
            sb.Append("<table align='center' border='1' cellpadding='0' cellspacing='0' width='580'>");
            sb.Append("<tr>");
            sb.Append("<td align='center' height='35' width='580'>");
            sb.Append("<center>");
            sb.Append("<font face='Arial' color='#333' style='font-size:14px;'>");
            sb.Append("Contato de usuário através do site Copa Movi");
            sb.Append("</font>");
            sb.Append("</center>");
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td align='left' width='580'>");
            sb.Append("<font face='Arial' color='#333' style='font-size:14px;'>");
            sb.AppendFormat("<strong>Nome Completo: </strong>{0}<br>", pf.NOME_EMPRESA);
            sb.AppendFormat("<strong>Email: </strong>{0}<br>", pf.EMAIL_EMPRESA);
            sb.AppendFormat("<strong>Telefone: </strong>{0}<br>", pf.TELEFONE_EMPRESA);
            sb.AppendFormat("<strong>Messagem: </strong>{0}<br>", pf.TIPO_COTA);
            sb.Append("</font>");
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("</table>");
            sb.Append("</body>");
            sb.Append("</html>");
            return sb.ToString();
        }
    }
}