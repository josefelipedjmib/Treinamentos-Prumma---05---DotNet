using BancoUtils.Entidade;
using BancoUtils.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BancoUtils.Service
{
    public class ContaService : BaseService<ContaBancaria>
    {
        public ContaService() : base(new ContaRepository<ContaBancaria>())
        {
        }

        public void Save(ContaBancaria contaBancaria)
        {
            contaBancaria.Agencia = 1;
            var numeroConta = 0;
            if (GetAll().Any())
                numeroConta = GetAll().Max(c => c.ID);
            contaBancaria.Conta = numeroConta + 1;
            base.Save(contaBancaria);
        }
    }
}
