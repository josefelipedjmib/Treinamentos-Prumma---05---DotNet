using BancoUtils.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoUtils.Repository
{
    public abstract class BaseRepository<T>
    {
        public T Get(int id)
        {
            return (T)Activator.CreateInstance(typeof(T), new object[] { });
        }
        public List<T> GetAll()
        {
            var retorno = new List<T>();

            return retorno;
        }

        public void Save(T conta)
        {

        }

        public void Remove(ContaBancaria conta)
        {

        }
    }
}
