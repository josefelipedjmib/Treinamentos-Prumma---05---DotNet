
using BancoUtils.Entidade;

namespace BancoDigital.Data.MySQL.Repository
{
    public class TransferenciaRepository<T> : BaseRepository<T> where T : IEntidade
    {
        public TransferenciaRepository(BancoContext<T> context) : base(context)
        {
        }
    }
}
