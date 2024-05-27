using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Utils
{
    public static class Texto
    {
        public static string NumeroParaTextoPreenchimentoEsquerda(Int64 numero, int comprimento, char preenchimento = '0')
        {
            return numero.ToString().PadLeft(comprimento, preenchimento);
        }
    }
}
