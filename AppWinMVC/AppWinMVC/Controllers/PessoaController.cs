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
            return View(new PessoaFisica());
        }

        [HttpPost]
        public ActionResult Criar(PessoaFisica pessoa)
        {
            RecuperaPessoaServiceSecao();
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