
namespace BancoUtils.Entidade
{
    public abstract class ContaBancaria : IEntidade
    {
        public int ID { get; set; } = 0;
        public Pessoa Pessoa { get; set; }
        public int Agencia { get; set; }
        public int Conta { get; set; }
        public int Tipo { get; set; }
        public decimal Valor { get; set; }
    }
}
