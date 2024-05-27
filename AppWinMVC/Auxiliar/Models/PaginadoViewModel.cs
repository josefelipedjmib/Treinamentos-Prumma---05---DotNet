using System.Text.Json.Serialization;

namespace Auxiliar.Models
{
    public class PaginadoViewModel : IPaginadoViewModel
    {
        [JsonPropertyName("pagina")]
        public int Pagina { get; set; }

        [JsonPropertyName("totalPaginas")]
        public int TotalPaginas { get; set; } = 0;

        [JsonPropertyName("totalItens")]
        public int TotalItens { get; set; } = 0;

        [JsonPropertyName("variavelContexto")]
        public string VariavelContexto { get; set; }


        // Configurações
        private int _paginaIntervalo = 2;
        private bool _exibirPaginaIntervalos = true;
        private bool _exibirPaginaAnteriorEProxima = true;
        private bool _exibirPrimeiraEUltimaPaginas = true;
        private bool _exibirDetalhesRegistros = true;
        private bool _exibirBotaoIrParaPagina = true;

        //Métodos

        public int Inicio()
        {
            return (GetPagina() - _paginaIntervalo) < 1
                ? 1
                : GetPagina() - _paginaIntervalo;
        }
        public int Fim()
        {
            var fim = GetPagina() + _paginaIntervalo;
            var paginasComIntervalo = PaginasComIntervalo();
            return fim >= TotalPaginas || paginasComIntervalo >= TotalPaginas
                    ? TotalPaginas
                    : fim < paginasComIntervalo
                        ? paginasComIntervalo
                        : fim;
        }
        public int Anterior()
        {
            return GetPagina() - 1;
        }
        public int Proximo()
        {
            return GetPagina() + 1;
        }
        public bool ExibirDetalhesRegistros()
        {
            return _exibirDetalhesRegistros;
        }
        public bool ExibirBotaoIrParaPagina()
        {
            return _exibirBotaoIrParaPagina;
        }
        public bool ExibirPrimeiraPagina()
        {
            return _exibirPrimeiraEUltimaPaginas && Inicio() > 1;
        }
        public bool ExibirUltimaPagina()
        {
            return _exibirPrimeiraEUltimaPaginas && Fim() < TotalPaginas;
        }
        public bool ExibirPaginaIntervaloAnterior()
        {
            return _exibirPaginaIntervalos && Inicio() > 2;
        }
        public bool ExibirPaginaIntervaloProximo()
        {
            return _exibirPaginaIntervalos && Fim() < TotalPaginas - 1;
        }
        public bool ExibirBotaoAnterior()
        {
            return _exibirPaginaAnteriorEProxima && GetPagina() > 1;
        }
        public bool ExibirBotaoProximo()
        {
            return _exibirPaginaAnteriorEProxima && GetPagina() < TotalPaginas;
        }

        public bool EhPaginaAtual(int pagina)
        {
            return pagina.Equals(GetPagina());
        }

        private int PaginasComIntervalo()
        {
            return _paginaIntervalo * 2 + 1;
        }

        private int GetPagina()
        {
            return this.Pagina < 1 ? 1 : Pagina;
        }
    }
}

