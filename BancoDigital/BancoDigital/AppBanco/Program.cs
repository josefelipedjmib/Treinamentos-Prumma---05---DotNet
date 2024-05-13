using AppBanco;
using BancoUtils.Entidade;
using BancoUtils.Service;

internal class Program
{
    private static PessoaService _pessoaService { get; set; }
    private static void Main(string[] args)
    {
        _pessoaService = new PessoaService();
        try
        {
            string opcao = "";
            do
            {
                ColouredConsole.WriteLine("");
                ColouredConsole.WriteLine("---- Escolha a ação que deseja fazer ----");
                ColouredConsole.WriteLine("---- [S] => sair do aplicativo ----");
                ColouredConsole.WriteLine("---- [P] => Cadastrar Pessoa ----");
                opcao = Console.ReadLine().Trim().ToLower();
                try
                {
                    switch(opcao)
                    {
                        case "p":
                            CadastrarPessoa(_pessoaService);
                            MostrarPessoa(_pessoaService);
                            break;
                    }
                }
                catch (Exception e)
                {
                    ColouredConsole.WriteLine(e.Message);
                    Console.ReadLine();
                }
            } while (!opcao.Equals("s"));
            ColouredConsole.WriteLine("... Encerrando aplicação. Obrigado por utilizar.");
        }
        catch(Exception ex)
        {
            ColouredConsole.WriteLine(ex.Message);
            Console.ReadLine();
        }
    }

    private static void CadastrarPessoa(PessoaService pessoaService)
    {

        ColouredConsole.WriteLine("Digite seu nome");
        var nome = Console.ReadLine();
        ColouredConsole.WriteLine("Digite seu e-mail");
        var email = Console.ReadLine();
        ColouredConsole.WriteLine("Digite sua Data de Nascimento (dd/mm/aaaa)");
        var dataNascimento = DateTime.Parse(Console.ReadLine());
        ColouredConsole.WriteLine("Digite seu cpf");
        var cpf = Console.ReadLine();
        var pessoa = new PessoaFisica(nome, email, dataNascimento, cpf);
        pessoaService.Save(pessoa);
    }

    private static void MostrarPessoa (PessoaService pessoaService)
    {
        var pessoa = pessoaService.GetAll().FirstOrDefault();
        ColouredConsole.WriteLine("Mostrando Pessoas!");
        ColouredConsole.WriteLine("Total de Registros de Pessoas: " + _pessoaService.GetAll().Count());
        ColouredConsole.WriteLine($"ID {pessoa.ID} - Nome {pessoa.Nome} - Email {pessoa.Email} - CPF {((PessoaFisica) pessoa).CPF}");
    }
}