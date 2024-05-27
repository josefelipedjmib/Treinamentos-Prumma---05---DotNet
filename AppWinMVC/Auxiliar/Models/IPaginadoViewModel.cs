namespace Auxiliar.Models
{
    public interface IPaginadoViewModel
    {
        int Pagina { get; set; }
        int TotalPaginas { get; set; }
        int TotalItens { get; set; }
        string VariavelContexto { get; set; }
        bool ExibirDetalhesRegistros();
        bool ExibirBotaoIrParaPagina();

        int Inicio();
        int Fim();
        int Anterior();
        int Proximo();
        bool ExibirPrimeiraPagina();
        bool ExibirUltimaPagina();
        bool ExibirPaginaIntervaloAnterior();
        bool ExibirPaginaIntervaloProximo();
        bool ExibirBotaoAnterior();
        bool ExibirBotaoProximo();

        bool EhPaginaAtual(int pagina);
    }
}

