using BancoUtils.Data;
using BancoUtils.Entidade;
 
internal class Program
{
    private static BancoContext _contexto { get; set; }
    private static void Main(string[] args)
    {
        _contexto = new BancoContext();

        CadastrarPessoa();
        CadastrarPessoa();
        CadastrarPessoa();

        Console.WriteLine("Total de Registros de Pessoas: " + _contexto.Pessoa.GetAll().Count());

        Console.WriteLine("Mostrando a primeira pessoa da Lista.");
        var pessoaRegistrada = _contexto.Pessoa.GetAll().First();
        MostrarPessoa(pessoaRegistrada);
        pessoaRegistrada = _contexto.Pessoa.Get(3);
        MostrarPessoa(pessoaRegistrada);
        Console.WriteLine("Fim do programa");
    }

    private static void CadastrarPessoa()
    {

        Console.WriteLine("Digite seu nome");
        var nome = Console.ReadLine();
        Console.WriteLine("Digite seu e-mail");
        var email = Console.ReadLine();
        Console.WriteLine("Digite sua Data de Nascimento (dd/mm/aaaa)");
        var dataNascimento = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Digite seu cpf");
        var cpf = Console.ReadLine();
        var pessoa = new PessoaFisica(nome, email, dataNascimento, cpf);
        _contexto.Pessoa.Salvar(pessoa);
    }

    private static void MostrarPessoa (Pessoa pessoa)
    {
        Console.WriteLine($"ID {pessoa.ID} - Nome {pessoa.Nome} - Email {pessoa.Email} - CPF {((PessoaFisica) pessoa).CPF}");
    }
}