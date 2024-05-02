using System;
using Utils;

namespace BancoUtils.Entidade
{
    public class PessoaFisica : Pessoa
    {
        public PessoaFisica() { }

        public PessoaFisica(string nome, string email, DateTime dataNascimento)
        {
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
        }

        public PessoaFisica(string nome, string email, DateTime dataNascimento, string cpf)
        {
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            CPF = cpf;
        }

        private int documentoComprimento = 11;

        public string CPF {
            get
            {
                return Texto.NumeroParaTextoPreenchimentoEsquerda(Documento, documentoComprimento);
            } 
            set
            {
                Documento = Numero.TextoParaLong(value);
            }
        }

        public int GetIdade()
        {
            return base.GetIdade();
        }
    }
}
