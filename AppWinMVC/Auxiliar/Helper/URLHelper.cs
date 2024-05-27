using Auxiliar.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Auxiliar.Helper
{
    public static class URLHelper
    {
        public static string Pagina = "principal";
        public static string GetPaginaURL(string uri)
        {
            var paginaUrl = GetTratada(uri);
            if (paginaUrl[paginaUrl.Length - 1].Equals('/'))
            {
                paginaUrl = paginaUrl.Substring(0, paginaUrl.Length - 1);
            }
            if (!string.IsNullOrEmpty(paginaUrl))
            {
                Pagina = paginaUrl;
            }
            return Pagina;
        }

        public static string GetPaginaArquivo(string uri)
        {
            return GetPaginaURL(uri).Replace("/", "-");
        }

        public static string GetTratada(string uri)
        {
            var url = Regex.Matches(uri, @"\/?([^?]+).*", RegexOptions.IgnoreCase);
            if (url.Count.Equals(0) || url[0].Value.Equals("/"))
                return "";
            return url[0].Groups[1].Value;
        }
    }
}
