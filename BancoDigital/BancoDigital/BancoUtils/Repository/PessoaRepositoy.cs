using BancoUtils.Data;
using BancoUtils.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoUtils.Repository
{
    public class PessoaRepositoy : BaseRepository<Pessoa>
    {
        private BancoContext _bancoContext;
        public PessoaRepositoy(BancoContext context) : base(context.Pessoa)
        {
            _bancoContext = context;
        }
    }
}
