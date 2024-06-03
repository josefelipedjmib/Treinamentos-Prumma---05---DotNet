using BancoDigital.Service.Service;
using BancoUtils.Entidade;
using System.Web.Mvc;

namespace AppWinMVC.Controllers
{
    public class PessoaController : Controller
    {
        private PessoaService _pessoaService = new PessoaService();

        public ActionResult Index()
        {
            RecuperaPessoaServiceSecao();
            var pessoas = _pessoaService.GetAll();
            return View(pessoas);
        }

        public ActionResult Criar()
        {
            return View(new PessoaFisica() { Nome = "Teste"});
        }

        [HttpPost]
        public ActionResult Criar(FormCollection form)
        {
            RecuperaPessoaServiceSecao();
            var pessoa = new PessoaFisica();
            //Exemplo pegando dados da FormCollection
            pessoa.Nome = form["nome"];
            pessoa.Email = form["email"];
            //Exemplo pegando dados direto da Requisição
            pessoa.Nome = Request.Form["nome"];
            pessoa.Email = Request.Form["email"];
            _pessoaService.Save(pessoa);

            Session["pessoaService"] = _pessoaService;
            return RedirectToAction("Index");
        }

        private void RecuperaPessoaServiceSecao()
        {
            if (Session["pessoaService"] != null)
                _pessoaService = (PessoaService) Session["pessoaService"];
        }
    }
}