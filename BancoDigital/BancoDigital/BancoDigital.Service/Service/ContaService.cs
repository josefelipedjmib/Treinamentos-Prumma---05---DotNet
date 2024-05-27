using BancoDigital.Data;
using BancoDigital.Data.Repository;
using BancoUtils.Entidade;
using System.Linq;

namespace BancoDigital.Service.Service
{
    public class ContaService : BaseService<ContaBancaria>
    {
        public ContaService() : base(new ContaRepository<ContaBancaria>(new BancoContext<ContaBancaria>()))
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
