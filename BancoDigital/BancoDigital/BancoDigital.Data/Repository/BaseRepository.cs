using BancoUtils.Entidade;
using System.Collections.Generic;

namespace BancoDigital.Data.Repository
{
    public abstract class BaseRepository<T> where T : IEntidade
    {
        protected BancoContext<T> _context;
        public BaseRepository(BancoContext<T> bancoContext)
        {
            _context = bancoContext;
        }

        public T Get(int id)
        {
            return _context.Get(id);
        }
        public List<T> GetAll()
        {
            return _context.GetAll();
        }

        public void Save(T dado)
        {
            _context.Save(dado);
        }

        public bool Remove(T dado)
        {
            return _context.Remove(dado);
        }
    }
}
