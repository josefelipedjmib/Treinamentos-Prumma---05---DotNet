using Auxiliar.Helper;
using System;
using System.IO;
using System.Net;
using System.Web.Mvc;
using System.Xml;

namespace AppWinMVC.Controllers
{
    public class ErrorController : Controller
    {
        [ActionName("404")]
        public ActionResult Error404()
        {
            try
            {
                var uri = Request.ServerVariables["REQUEST_URI"];
                var paginaArquivo = URLHelper.GetPaginaArquivo(uri);
                var arquivoXML = Server.MapPath("~/Content/ctd/" + paginaArquivo + ".xml");
                var xml = new XmlDocument();
                xml.Load(arquivoXML);
                var conteudo = xml.SelectNodes("//conteudo")[0].InnerText;
               return View("ConteudoXML", "", conteudo);
            }catch(Exception ex)
            {
                
            }

            var status = new HttpStatusCodeResult(HttpStatusCode.NotFound, "404 Not Found");
            Response.Status = status.StatusDescription;
            Response.StatusCode = status.StatusCode;
            Response.StatusDescription = status.StatusDescription;
            return View();
        }
    }
}