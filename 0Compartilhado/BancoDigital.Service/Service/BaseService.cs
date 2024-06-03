using BancoDigital.Data.MySQL;
using BancoDigital.Data.Repository;
using BancoUtils.Entidade;
using System.Collections.Generic;

namespace BancoDigital.Service.Service
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
            var teste = new Contexto("Server=winpqt.mysql.dbaas.com.br;User Id=winpqt;Database=winpqt;Pwd=djMIB@2022@pqt;includesecurityasserts=true;");
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
