using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mail;
using System.Web.Mvc;

namespace AppWinMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sobre()
        {
            ViewBag.Message = "Sua descrição";

            return View();
        }

        public ActionResult Contato()
        {
            ViewBag.Message = "Informações contatos";

            return View();
        }

        public void TesteEnvioEmail1()
        {
            var Email = new System.Web.Mail.MailMessage();
            Email.From = "josefelipe@ilhadepaqueta.net";
            Email.To = "programador@josefelipe.net";
            Email.Subject = "teste novo e-mail";
            Email.BodyFormat = MailFormat.Html;
            Email.Body = "<div style=\"background-color: #ccddff;\"><h1>Apenas um teste</h1><p>Envio de e-mail via novo método com C# DotNet</p>";
            SmtpMail.SmtpServer = "localhost";
            SmtpMail.Send(Email);

            Response.Write("Foi");
            Response.End();
        }

        public void TesteEnvioEmail2()
        {
            var Email = new System.Net.Mail.MailMessage();
            Email.From = new MailAddress("josefelipe@ilhadepaqueta.net");
            Email.To.Add(new MailAddress("programador@josefelipe.net"));
            Email.Subject = "teste novo e-mail";
            Email.IsBodyHtml = true;
            Email.Body = "<div style=\"background-color: #ccddff;\"><h1>Apenas um teste</h1><p>Envio de e-mail via novo método com C# DotNet</p>";

            var client = new SmtpClient("localhost");
            client.Send(Email);

            Response.Write("Foi");
            Response.End();
        }
    }
}