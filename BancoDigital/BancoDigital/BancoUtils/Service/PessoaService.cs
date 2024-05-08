using BancoUtils.Data;
using BancoUtils.Entidade;
using BancoUtils.Repository;
using System.Collections.Generic;

namespace BancoUtils.Service
{
    public class PessoaService
    {
        private BancoContext _bancoContext;
        private PessoaRepositoy _pessoaRepository;
        public PessoaService(BancoContext context)
        {
            _bancoContext = context;
            _pessoaRepository = new PessoaRepositoy(_bancoContext);
        }

        public Pessoa Get(int id)
        {
            return _pessoaRepository.Get(id);
        }

        public List<Pessoa> GetAll()
        {
            return _pessoaRepository.GetAll();
        }

        public void Save(Pessoa pessoa)
        {
            _pessoaRepository.Save(pessoa);
        }
    }
}
