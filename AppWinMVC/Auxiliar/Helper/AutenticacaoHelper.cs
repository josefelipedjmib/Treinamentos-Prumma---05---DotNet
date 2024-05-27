using System;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Auxiliar.Helper
{
    public static class AutenticacaoHelper
    {
        public static int getIdByToken(ClaimsPrincipal user)
        {
            var id = 0;
            int.TryParse(user?.FindFirst(ClaimTypes.NameIdentifier).Value, out id);
            return id;
        }

        public static string GeraSenha(string usuario, string senha)
        {
            return ComputeSha256Hash(senha + usuario.ToLower());
        }

        public static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static string GeraCodigo(string original)
        {
            original = original.ToLower();
            var meio = original.Length / 2;
            return ComputeSha256Hash(
                        original.Substring(meio) 
                        + CaracteresParaGeraracao.Substring(0,6) 
                        + original.Substring(0, meio)
                    );
        }

        public static bool ValidaCodigo(string original, string codigo)
        {
            return codigo.Equals(GeraCodigo(original));
        }

        public static string EncryptCodigoURL(string original)
        {
            return WebUtility.UrlEncode((CaracteresParaGeraracao.Substring(0, 6) + original));
        }

        public static string DecryptCodigoURL(string codigo)
        {
            return codigo.Replace(CaracteresParaGeraracao.Substring(0, 6), "");
        }

        public static string GeraCaracter(int numero)
        {
            if (numero == 0 || numero > CaracteresParaGeraracao.Length)
            {
                var random = new Random();
                return CaracteresParaGeraracao.Substring(random.Next(0, CaracteresParaGeraracao.Length), 1);
            }
            return CaracteresParaGeraracao.Substring(numero - 1, 1);
        }

        public static string GeraHash(int inicial, int comprimento)
        {
            inicial = inicial % (CaracteresParaGeraracao.Length + 1);
            string id = GeraCaracter(inicial);
            for (int i = 1; i < comprimento; i++)
                id += GeraCaracter(0);
            return id;
        }

        public static string TirarCaracteresEspeciais(string texto)
        {
            var acentuada = "ŠŒŽšœžŸ¥µÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖØÙÚÛÜÝßàáâãäåæçèéêëìíîïðñòóôõöøùúûüýÿ";
            var semacento = "SOZsozYYuAAAAAAACEEEEIIIIDNOOOOOOUUUUYsaaaaaaaceeeeiiiionoooooouuuuyy";

            for (var i = 0; i < acentuada.Length; i++)
                texto = texto.Replace(acentuada[i], semacento[i]);
            return Regex.Replace(texto, "[^a-zA-Z0-9-_.]+", "-");
        }

        public static string CaracteresParaGeraracao = "qwertyuiopasdfghjklzxcvbnm_1475963082-MNBVCXZLKJHGFDSAPOIUYTREWQ!@#$%*+|()";
    }
}
