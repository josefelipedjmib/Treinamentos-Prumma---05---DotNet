using BancoUtils.Entidade;
using System.Collections.Generic;
using System.Linq;

namespace BancoUtils.Data
{
    public class DadosSet<T> where T : IEntidade
    {
        public DadosSet() 
        { 
            Dados =  new List<T>();
        }

        private List<T> Dados { get; set; }
        public void Set(T dado)
        {
            Dados.Add(dado);
        }

        public void Set(List<T> list)
        {
            Dados.AddRange(list);
        }

        public T Get(int id)
        {
            return Dados.FirstOrDefault(d => d.ID.Equals(id));
        }

        public List<T> GetAll()
        {
            return Dados;
        }

        public void Save(T dado)
        {
            if (dado.ID.Equals(0))
            {
                var id = 0;
                if (Dados.Count > 0)
                    id = Dados.Max(d => d.ID);
                dado.ID = id + 1;
                Set(dado);
            }
            else
            {
                var dadoAtualizar = Get(dado.ID);
                if(dadoAtualizar != null)
                {
                    var index = Dados.IndexOf(dadoAtualizar);
                    Dados[index] = dado;
                }
            }
        }

        public bool Remove(T dado)
        {
            return Dados.Remove(dado);
        }
    }
}
