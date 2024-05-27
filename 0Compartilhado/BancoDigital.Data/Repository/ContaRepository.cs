using BancoUtils.Entidade;

namespace BancoDigital.Data.Repository
{
    public class ContaRepository<T> : BaseRepository<T> where T : IEntidade
    {
        public ContaRepository(BancoContext<T> context) : base(context)
        {
        }
    }
}
