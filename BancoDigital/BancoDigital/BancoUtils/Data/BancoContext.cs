using BancoUtils.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoUtils.Data
{
    public class BancoContext
    {
        public DadosSet<Pessoa> Pessoa { get; set; }
        public DadosSet<ContaBancaria> Conta { get; set; }
        public DadosSet<Transferencia> Transferencia { get; set; }

        public BancoContext()
        {
            Pessoa = new DadosSet<Pessoa>();
            Conta = new DadosSet<ContaBancaria>();
            Transferencia = new DadosSet<Transferencia>();
        }
    }
}
