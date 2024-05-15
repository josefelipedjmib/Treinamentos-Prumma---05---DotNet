using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Utils
{
    public static class Numero
    {
        public static long TextoParaLong(string numeroEmTexto)
        {
            numeroEmTexto = numeroEmTexto.Replace(".", "").Replace("-", "").Replace("/", "");
            var numero = 0L;
            long.TryParse(numeroEmTexto, out numero);
            return numero;
        }
        public static decimal TextoParaDecimal(string numeroEmTexto)
        {
            numeroEmTexto = numeroEmTexto.Replace(".", "").Replace("-", "").Replace("/", "");
            var numero = 0M;
            decimal.TryParse(numeroEmTexto, out numero);
            return numero;
        }
    }
}
