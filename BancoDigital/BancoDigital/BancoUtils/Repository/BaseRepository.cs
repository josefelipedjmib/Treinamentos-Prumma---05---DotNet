using BancoUtils.Data;
using BancoUtils.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoUtils.Repository
{
    public abstract class BaseRepository<T> where T : IEntidade
    {
        private DadosSet<T> _dadosSet;
        public BaseRepository(DadosSet<T> dadosSet)
        {
            _dadosSet = dadosSet;
        }

        public T Get(int id)
        {
            return _dadosSet.Get(id);
        }
        public List<T> GetAll()
        {
            return _dadosSet.GetAll();
        }

        public void Save(T dado)
        {
            _dadosSet.Save(dado);
        }

        public bool Remove(T dado)
        {
            return _dadosSet.Remove(dado);
        }
    }
}
