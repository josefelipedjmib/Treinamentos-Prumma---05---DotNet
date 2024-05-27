
using System;
using System.Collections.Generic;
using System.Linq;

namespace Auxiliar.Helper
{
    public static class TextoHelper
    {

        public static List<string> QuebrarEmPartes(string texto, int tamanho = 20)
        {
            return ChunkText(texto, tamanho);
        }

        public static List<string> ChunkText(string texto, int tamanho)
        {
            var chunks = new List<string>();
            for (int i = 0; i < texto.Length; i += tamanho)
            {
                int chunkSize = Math.Min(tamanho, texto.Length - i);
                chunks.Add(new string(texto.Skip(i).Take(chunkSize).ToArray()));
            }
            return chunks;
        }

    }
}
