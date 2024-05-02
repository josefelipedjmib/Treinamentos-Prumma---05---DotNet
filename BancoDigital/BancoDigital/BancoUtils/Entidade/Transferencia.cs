using System;
using System.Collections.Generic;
using System.Text;

namespace BancoUtils.Entidade
{
    public class Transferencia : IEntidade
    {
        public int ID { get; set; } = 0;
        public DateTime Data { get; set; }
        public Pessoa Remetente { get; set; }
        public Pessoa Destinatario { get; set; }
        public Decimal Valor { get; set; }
        public string Tipo { get; set; }
    }
}
