using BancoUtils.Entidade;

namespace BancoDigital.Data.MySQL.Repository
{
    public class PessoaRepositoy<T> : BaseRepository<T> where T : IEntidade
    {
        public PessoaRepositoy(BancoContext<T> context) : base(context)
        {
        }
    }
}
