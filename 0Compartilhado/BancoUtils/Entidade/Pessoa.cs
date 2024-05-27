using System;
using Utils;

namespace BancoUtils.Entidade
{
    public abstract class Pessoa : IEntidade
    {
        public int ID { get; set; } = 0;
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public long Documento { get; set; }

        protected int GetIdade()
        {
            return Data.CalcularIdade(DataNascimento);
        }
    }
}
