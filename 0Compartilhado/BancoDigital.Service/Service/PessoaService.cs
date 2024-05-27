using BancoDigital.Data;
using BancoDigital.Data.Repository;
using BancoUtils.Entidade;

namespace BancoDigital.Service.Service
{
    public class PessoaService : BaseService<Pessoa>
    {
        public PessoaService() : base(new PessoaRepositoy<Pessoa>(new BancoContext<Pessoa>()))
        {
        }
    }
}
