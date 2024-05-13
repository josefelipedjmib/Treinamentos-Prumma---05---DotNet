using BancoUtils.Entidade;
using System.Collections.Generic;

namespace BancoUtils.Data
{
    public class BancoContext<T> where T : IEntidade
    {
        private DadosSet<T> _dados { get; set; }

        public BancoContext()
        {
            _dados = new DadosSet<T>();
        }
        public void Set(T dado)
        {
            _dados.Set(dado);
        }

        public void Set(List<T> list)
        {
            _dados.Set(list);
        }

        public T Get(int id)
        {
            return _dados.Get(id);
        }

        public List<T> GetAll()
        {
            return _dados.GetAll();
        }

        public void Save(T dado)
        {
            _dados.Save(dado);
        }

        public bool Remove(T dado)
        {
            return _dados.Remove(dado);
        }
    }
}
