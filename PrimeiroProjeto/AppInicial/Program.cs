public class Program
{
    private static void Main(string[] args)
    {
        var numero = Numero.TextoParaInteiro("15fg", 2024);
        Console.WriteLine("O número é " + numero);
        Console.ReadKey();
    }
}