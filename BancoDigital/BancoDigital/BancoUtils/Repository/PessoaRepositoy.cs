using BancoUtils.Data;
using BancoUtils.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoUtils.Repository
{
    public class PessoaRepositoy<T> : BaseRepository<T> where T : IEntidade
    {
        public PessoaRepositoy()
        {
        }
    }
}
