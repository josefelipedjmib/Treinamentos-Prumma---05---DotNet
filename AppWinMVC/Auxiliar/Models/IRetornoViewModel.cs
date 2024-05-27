namespace Auxiliar.Models
{
    public interface IRetornoViewModel
    {
        bool Valido { get; set; }
        string Status { get; set; }
        string Mensagem { get; set; }
    }
}

