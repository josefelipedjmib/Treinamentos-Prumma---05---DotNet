using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Utils
{
    public static class Arquivo
    {
        private static string arquivoDados = Directory.GetCurrentDirectory() + "\\dados.txt";
        public static void Salvar(string dados)
        {
            File.WriteAllText(arquivoDados, dados);
        }

        public static string Ler()
        {
            if (File.Exists(arquivoDados))
                return File.ReadAllText(arquivoDados);
            return "";
        }
    }
}
