using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Auxiliar.Models
{
    public class RetornoViewModel<T> : PaginadoViewModel, IRetornoViewModel
    {
        [JsonPropertyName("valido")]
        public bool Valido { get; set; }
        [JsonPropertyName("statusCode")]
        public string Status { get; set; }
        [JsonPropertyName("mensagem")]
        public string Mensagem { get; set; }
        [JsonPropertyName("lista")]
        public List<T> Lista { get; set; }
        [JsonPropertyName("adminOuComercial")]
        public bool AdminOuComercial { get; set; }
    }
}

