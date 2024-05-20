using AppBanco;
using BancoUtils.Data;
using BancoUtils.Entidade;
using BancoUtils.Service;
using Utils;

internal class Program
{
    private static void Main(string[] args)
    {
        var contextoPessoa = new BancoContext<Pessoa>();
        var contextoConta = new BancoContext<ContaBancaria>();
        var contextoTransferencia = new BancoContext<Transferencia>();
        var _pessoaService = new PessoaService(contextoPessoa);
        var _contaService = new ContaService(contextoConta);
        var _trasferenciaService = new TransferenciaService(contextoTransferencia, _contaService);

        try
        {
            string opcao = "";
            do
            {
                ColouredConsole.WriteLine("");
                ColouredConsole.WriteLine("---- Escolha a ação que deseja fazer ----");
                ColouredConsole.WriteLine("---- [S] => sair do aplicativo ----");
                ColouredConsole.WriteLine("---- [P] => Cadastrar Pessoa ----");
                ColouredConsole.WriteLine("---- [LP] => Listar Pessoa ----");
                ColouredConsole.WriteLine("---- [RP] => Remover Pessoa ----");
                ColouredConsole.WriteLine("---- [C] => Cadastrar Conta ----");
                ColouredConsole.WriteLine("---- [LC] => Listar Conta ----");
                ColouredConsole.WriteLine("---- [RC] => Remover Conta ----");
                ColouredConsole.WriteLine("---- [T] => Cadastrar Transferência ----");
                ColouredConsole.WriteLine("---- [LT] => Listar Transferência ----");
                ColouredConsole.WriteLine("---- [RT] => Remover Transferência ----");
                opcao = Console.ReadLine().Trim().ToLower();
                try
                {
                    switch(opcao)
                    {
                        case "p":
                            CadastrarPessoa(_pessoaService);
                            MostrarPessoa(_pessoaService);
                            break;
                        case "lp":
                            MostrarPessoa(_pessoaService);
                            break;
                        case "rp":
                            RemoverPessoa(_pessoaService);
                            break;
                        case "c":
                            CadastrarConta(_contaService, _pessoaService);
                            MostrarConta(_contaService);
                            break;
                        case "lc":
                            MostrarConta(_contaService);
                            break;
                        case "t":
                            CadastrarTransferencia(_trasferenciaService, _contaService);
                            MostrarTransferencia(_trasferenciaService);
                            break;
                        case "lt":
                            MostrarTransferencia(_trasferenciaService);
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

    private static void RemoverPessoa(PessoaService pessoaService)
    {
        MostrarPessoa(pessoaService);
        ColouredConsole.WriteLine("Digite o ID  que gostaria de remover");
        var id = Console.ReadLine();
        var pessoa = pessoaService.Get(Numero.TextoParaInt(id));
        if(pessoa != null)
        {
            pessoaService.Remove(pessoa);
        }
    }

    private static void MostrarPessoa (PessoaService pessoaService)
    {
        var pessoas = pessoaService.GetAll();
        ColouredConsole.WriteLine("Mostrando Pessoas!");
        ColouredConsole.WriteLine("Total de Registros de Pessoas: " + pessoas.Count());
        foreach(var pessoa in pessoas)
        {
            ColouredConsole.WriteLine($"ID {pessoa.ID} - Nome {pessoa.Nome} - Email {pessoa.Email} - CPF {((PessoaFisica)pessoa).CPF}");
        }
    }
    private static void CadastrarConta(ContaService contaService, PessoaService pessoaService)
    {
        ColouredConsole.WriteLine("Digite o ID da Pessoa");
        var idPessoa = Console.ReadLine();
        ColouredConsole.WriteLine("Digite o valor inicial da conta");
        var valorInicial = Console.ReadLine();
        var conta = new ContaPoupanca();
        conta.Valor = Numero.TextoParaDecimal(valorInicial);
        conta.Pessoa = pessoaService.GetAll().FirstOrDefault(p => p.ID.ToString().Equals(idPessoa));
        contaService.Save(conta);
    }

    private static void MostrarConta(ContaService contaService)
    {
        var contas = contaService.GetAll();
        ColouredConsole.WriteLine("Mostrando contas!");
        ColouredConsole.WriteLine("Total de Registros de Contas: " + contas.Count());
        foreach(var conta in contas)
        {
            ColouredConsole.WriteLine($"ID {conta.ID} - Nome do Titular {conta.Pessoa.Nome} - Valor {conta.Valor}");
        }
    }
    private static void CadastrarTransferencia(TransferenciaService transferenciaService, ContaService contaService)
    {
        ColouredConsole.WriteLine("Digite o ID da Conta Remetente");
        var idContaRemetente = Console.ReadLine();
        ColouredConsole.WriteLine("Digite o ID da Conta Destinatario");
        var idContaDestinatario = Console.ReadLine();
        ColouredConsole.WriteLine("Digite o valor da transferência");
        var valorTransferencia = Console.ReadLine();
        ColouredConsole.WriteLine("Digite o tipo de transferência");
        var tipoTransferencia = Console.ReadLine();
        var transferencia = new Transferencia();
        transferencia.Tipo = tipoTransferencia;
        transferencia.Remetente = contaService.GetAll().FirstOrDefault(p => p.ID.ToString().Equals(idContaRemetente));
        transferencia.Destinatario = contaService.GetAll().FirstOrDefault(p => p.ID.ToString().Equals(idContaDestinatario));
        transferencia.Valor = Numero.TextoParaDecimal(valorTransferencia);
        transferenciaService.Save(transferencia);
    }

    private static void MostrarTransferencia(TransferenciaService transferenciaService)
    {
        var transferencias = transferenciaService.GetAll();
        ColouredConsole.WriteLine("Mostrando transferência!");
        ColouredConsole.WriteLine("Total de Registros de Transferências: " + transferencias.Count());
        foreach(var transferencia in transferencias)
        {
            ColouredConsole.WriteLine($"ID {transferencia.ID} - Nome do Remetente {transferencia.Remetente.Pessoa.Nome} - Nome Destinatário {transferencia.Destinatario.Pessoa.Nome} - Valor {transferencia.Valor} - Tipo {transferencia.Tipo}");
        }
    }
}
