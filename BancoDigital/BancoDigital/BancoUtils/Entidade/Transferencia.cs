using System;

namespace BancoUtils.Entidade
{
    public class Transferencia : IEntidade
    {
        public int ID { get; set; } = 0;
        public DateTime Data { get; set; }
        public ContaBancaria Remetente { get; set; }
        public ContaBancaria Destinatario { get; set; }
        public Decimal Valor { get; set; }
        public string Tipo { get; set; }
    }
}
