using BancoUtils.Entidade;
using BancoUtils.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoUtils.Service
{
    public class TransferenciaService : BaseService<Transferencia>
    {
        public TransferenciaService() : base(new TransferenciaRepository<Transferencia>())
        {
        }
    }
}
