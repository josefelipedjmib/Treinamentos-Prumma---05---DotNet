using BancoUtils.Entidade;
using BancoUtils.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoUtils.Service
{
    public abstract class BaseService<T> where T : IEntidade
    {
        protected BaseRepository<T> _repository;
        public BaseService(BaseRepository<T> repository)
        {
            _repository = repository;
        }

        public T Get(int id)
        {
            return _repository.Get(id);
        }

        public List<T> GetAll()
        {
            return _repository.GetAll();
        }

        public void Save(T dado)
        {
            _repository.Save(dado);
        }

        public bool Remove(T dado)
        {
            return _repository.Remove(dado);
        }
    }
}
