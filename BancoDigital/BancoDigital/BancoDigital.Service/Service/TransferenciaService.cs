using BancoDigital.Data;
using BancoDigital.Data.Repository;
using BancoUtils.Entidade;
using System;

namespace BancoDigital.Service.Service
{
    public class TransferenciaService : BaseService<Transferencia>
    {
        private ContaService _contaService;
        public TransferenciaService(ContaService contaService) : base(new TransferenciaRepository<Transferencia>(new BancoContext<Transferencia>()))
        {
            _contaService = contaService;
        }
        public void Save(Transferencia transferencia)
        {
            if (!transferencia.ID.Equals(0))
                throw new Exception("Transferência não pode ser alterada.");
            if (transferencia.Remetente.Valor < transferencia.Valor)
                throw new Exception("Transferência não pode ser relizada, por não ter saldo suficiente.");
            if (transferencia.Valor < 1)
                throw new Exception("Transferência só pode ser realizada com valor maior ou igual a 1");
            if(transferencia.Remetente == null || transferencia.Destinatario == null)
                throw new Exception("Transferência não pode ser relizada com conta inexistente.");
            var remetenteConta = new ContaPoupanca();
            remetenteConta.ID = transferencia.Remetente.ID;
            remetenteConta.Pessoa = transferencia.Remetente.Pessoa;
            remetenteConta.Agencia = transferencia.Remetente.Agencia;
            remetenteConta.Conta = transferencia.Remetente.Conta;
            remetenteConta.Tipo = transferencia.Remetente.Tipo;
            remetenteConta.Valor = transferencia.Remetente.Valor;
            var destinatarioConta = new ContaPoupanca();
            destinatarioConta.ID = transferencia.Destinatario.ID;
            destinatarioConta.Pessoa = transferencia.Destinatario.Pessoa;
            destinatarioConta.Agencia = transferencia.Destinatario.Agencia;
            destinatarioConta.Conta = transferencia.Destinatario.Conta;
            destinatarioConta.Tipo = transferencia.Destinatario.Tipo;
            destinatarioConta.Valor = transferencia.Destinatario.Valor;
            remetenteConta.Valor -= transferencia.Valor;
            destinatarioConta.Valor += transferencia.Valor;
            _contaService.Save(remetenteConta);
            _contaService.Save(destinatarioConta);
            _repository.Save(transferencia);
        }

        public bool Remove(Transferencia transferencia)
        {
            throw new Exception("Transferência não pode ser removida.");
        }
    }
}
