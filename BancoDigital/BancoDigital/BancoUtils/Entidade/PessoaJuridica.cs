using System;
using System.Collections.Generic;
using System.Text;
using Utils;

namespace BancoUtils.Entidade
{
    public class PessoaJuridica : Pessoa
    {
        private int documentoComprimento = 14;
        public string CNPJ
        {
            get
            {
                return Texto.NumeroParaTextoPreenchimentoEsquerda(Documento, documentoComprimento);
            }
            set
            {
                Documento = Numero.TextoParaLong(value);
            }
        }
        public int GetAnos()
        {
            return GetIdade();
        }
    }
}
