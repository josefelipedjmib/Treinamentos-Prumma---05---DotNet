using BancoUtils.Data;
using BancoUtils.Entidade;
using BancoUtils.Repository;
using System.Collections.Generic;

namespace BancoUtils.Service
{
    public class PessoaService : BaseService<Pessoa>
    {
        public PessoaService(BancoContext<Pessoa> context) : base(new PessoaRepositoy<Pessoa>(context))
        {
        }
    }
}
