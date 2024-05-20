using BancoUtils.Data;
using BancoUtils.Entidade;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace BancoUtils.Repository
{
    public class ContaRepository<T> : BaseRepository<T> where T : IEntidade
    {
        public ContaRepository(BancoContext<T> context) : base(context)
        {
        }
    }
}
