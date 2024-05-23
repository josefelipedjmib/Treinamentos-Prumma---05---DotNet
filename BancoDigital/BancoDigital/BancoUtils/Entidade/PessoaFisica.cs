using System;
using Utils;

namespace BancoUtils.Entidade
{
    public class PessoaFisica : Pessoa
    {
        public PessoaFisica() { }

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
