using AppBanco;
using BancoDigital.Service.Service;
using BancoUtils.Entidade;
using System.Text.Json;
using Utils;

internal class Program
{
    private static PessoaService _pessoaService;
    private static ContaService _contaService;
    private static TransferenciaService _transferenciaService;
    private static void Main(string[] args)
    {
        _pessoaService = new PessoaService();
        _contaService = new ContaService();
        _transferenciaService = new TransferenciaService(_contaService);

        try
        {
            string opcao = "";
            do
            {
                ColouredConsole.WriteLine("");
                ColouredConsole.WriteLine("---- Escolha a ação que deseja fazer ----");
                ColouredConsole.WriteLine("---- [S] => sair do aplicativo ----");
                ColouredConsole.WriteLine("---- [I] => Importar Dados ----");
                ColouredConsole.WriteLine("---- [E] => Exportar Dados ----");
                ColouredConsole.WriteLine("---- [P] => Cadastrar Pessoa ----");
                ColouredConsole.WriteLine("---- [LP] => Listar Pessoa ----");
                ColouredConsole.WriteLine("---- [EP] => Editar Pessoa ----");
                ColouredConsole.WriteLine("---- [RP] => Remover Pessoa ----");
                ColouredConsole.WriteLine("---- [C] => Cadastrar Conta ----");
                ColouredConsole.WriteLine("---- [LC] => Listar Conta ----");
                ColouredConsole.WriteLine("---- [EC] => Editar Conta ----");
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
                        case "i":
                            ImportarDados();
                            break;
                        case "e":
                            ExportarDados();
                            break;
                        case "lp":
                            MostrarPessoa(_pessoaService);
                            break;
                        case "ep":
                            EditarPessoa(_pessoaService);
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
                        case "ec":
                            EditarConta(_contaService);
                            break;
                        case "rc":
                            RemoverConta(_contaService);
                            break;
                        case "t":
                            CadastrarTransferencia(_transferenciaService, _contaService);
                            MostrarTransferencia(_transferenciaService);
                            break;
                        case "lt":
                            MostrarTransferencia(_transferenciaService);
                            break;
                        case "rt":
                            RemoverTranasferencia(_transferenciaService);
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

    private static void ExportarDados()
    {
        var contextos = new Dictionary<string, string>();
        contextos.Add("conta", JsonSerializer.Serialize(_contaService.GetAll()));
        contextos.Add("pessoa", JsonSerializer.Serialize(_pessoaService.GetAll()));
        contextos.Add("transferencia", JsonSerializer.Serialize(_transferenciaService.GetAll()));
        Arquivo.Salvar(JsonSerializer.Serialize(contextos));
    }

    private static void ImportarDados()
    {
        var texto = Arquivo.Ler();
        var contextos = JsonSerializer.Deserialize<Dictionary<string, string>>(texto);
        if(contextos != null)
        {
            var valor = "";
            if (contextos.TryGetValue("conta", out valor))
            {
                //_contaService.Import(JsonSerializer.Deserialize<List<ContaBancaria>>(valor));
            }
            valor = "";
            if (contextos.TryGetValue("pessoa", out valor))
            {
                var lista = JsonSerializer.Deserialize<List<PessoaFisica>>(valor);
                foreach (var dado in lista)
                {
                    _pessoaService.Save(dado);
                }
            }
            valor = "";
            if (contextos.TryGetValue("transferencia", out valor))
            {
                //_transferenciaService.Import(JsonSerializer.Deserialize<List<Transferencia>>(valor));
            }
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
        var pessoa = new PessoaFisica()
        {
            Nome = nome,
            Email = email,
            DataNascimento = dataNascimento,
            CPF = cpf
        };
        pessoaService.Save(pessoa);
    }

    private static void EditarPessoa(PessoaService pessoaService)
    {
        var pessoa = (PessoaFisica?) EscolherPessoaAlterar(pessoaService);
        if (pessoa != null)
        {
            var texto = "";
            ColouredConsole.WriteLine("Nome: " + pessoa.Nome);
            ColouredConsole.WriteLine("Digite outro valor para alterar, ou deixar em branco para manter.");
            texto = Console.ReadLine();
            if (!string.IsNullOrEmpty(texto))
                pessoa.Nome = texto;
            ColouredConsole.WriteLine("E-mail: " + pessoa.Email);
            ColouredConsole.WriteLine("Digite outro valor para alterar, ou deixar em branco para manter.");
            texto = Console.ReadLine();
            if (!string.IsNullOrEmpty(texto))
                pessoa.Email = texto;
            ColouredConsole.WriteLine("Data de Nascimento: " + pessoa.DataNascimento);
            ColouredConsole.WriteLine("Digite outro valor para alterar, ou deixar em branco para manter.");
            texto = Console.ReadLine();
            if (!string.IsNullOrEmpty(texto))
                pessoa.DataNascimento = DateTime.Parse(texto);
            ColouredConsole.WriteLine("CPF: " + pessoa.CPF);
            ColouredConsole.WriteLine("Digite outro valor para alterar, ou deixar em branco para manter.");
            texto = Console.ReadLine();
            if (!string.IsNullOrEmpty(texto))
                pessoa.CPF = texto;
            pessoaService.Save(pessoa);
            ColouredConsole.WriteLine($"Pessoa ID - {pessoa.ID} - nome {pessoa.Nome} - alterada com sucesso!");
        }
        else
        {
            ColouredConsole.WriteLine("ID de pessoa inexistente.");
        }

    }

    private static void RemoverPessoa(PessoaService pessoaService)
    {
        var pessoa = EscolherPessoaAlterar(pessoaService);
        if(pessoa != null)
        {
            pessoaService.Remove(pessoa);
            ColouredConsole.WriteLine($"Pessoa ID - {pessoa.ID} - nome {pessoa.Nome} - removido com sucesso!");
        }
        else
        {
            ColouredConsole.WriteLine("ID de pessoa inexistente.");
        }
    }

    private static Pessoa? EscolherPessoaAlterar(PessoaService pessoaService)
    {
        MostrarPessoa(pessoaService);
        ColouredConsole.WriteLine("Digite o ID  que gostaria de alterar.");
        var id = Console.ReadLine();
        return pessoaService.Get(Numero.TextoParaInt(id));
    }

    private static void MostrarPessoa (PessoaService pessoaService)
    {
        var pessoas = pessoaService.GetAll();
        ColouredConsole.WriteLine("Mostrando Pessoas!");
        ColouredConsole.WriteLine("Total de Registro" + (pessoas.Count() > 1 ? "s" : "") + " de Pessoas: " + pessoas.Count());
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
        ColouredConsole.WriteLine("Total de Registro" + (contas.Count() > 1 ? "s" : "") + " de Contas: " + contas.Count());
        foreach(var conta in contas)
        {
            ColouredConsole.WriteLine($"ID {conta.ID} - Nome do Titular {conta.Pessoa.Nome} - Valor {conta.Valor}");
        }
    }

    private static ContaBancaria EscolherContaAlterar(ContaService contaService)
    {
        MostrarConta(contaService);
        ColouredConsole.WriteLine("Digite o ID  que gostaria de alterar.");
        var id = Console.ReadLine();
        return contaService.Get(Numero.TextoParaInt(id)); ;
    }

    private static void EditarConta(ContaService contaService)
    {
        var conta = (ContaPoupanca?)EscolherContaAlterar(contaService);
        if (conta != null)
        {
            var texto = "";
            ColouredConsole.WriteLine("Tipo: " + conta.Tipo);
            ColouredConsole.WriteLine("Digite outro valor para alterar, ou deixar em branco para manter.");
            texto = Console.ReadLine();
            if (!string.IsNullOrEmpty(texto))
                conta.Tipo = Numero.TextoParaInt(texto);
            ColouredConsole.WriteLine("Valor: " + conta.Valor);
            ColouredConsole.WriteLine("Digite outro valor para alterar, ou deixar em branco para manter.");
            texto = Console.ReadLine();
            if (!string.IsNullOrEmpty(texto))
                conta.Valor = Numero.TextoParaDecimal(texto);  
            contaService.Save(conta);
            ColouredConsole.WriteLine($"Conta ID - {conta.ID} - Nome {conta.Pessoa.Nome} - alterada com sucesso!");
        }
        else
        {
            ColouredConsole.WriteLine("ID de conta inexistente.");
        }
    }

    private static void RemoverConta(ContaService contaService)
    {
        var contaDelete = EscolherContaAlterar(contaService);
        if (contaDelete != null)
        {
            contaService.Remove(contaDelete);
            ColouredConsole.WriteLine($"Conta ID - {contaDelete.ID} - Nome {contaDelete.Pessoa.Nome} - removido com sucesso!");
        }
        else
        {
            ColouredConsole.WriteLine("ID de conta inexistente.");
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
        ColouredConsole.WriteLine("Total de Registro" + (transferencias.Count() > 1 ? "s" : "") + " de Transferências: " + transferencias.Count());
        foreach(var transferencia in transferencias)
        {
            ColouredConsole.WriteLine($"ID {transferencia.ID} - Nome do Remetente {transferencia.Remetente.Pessoa.Nome} - Nome Destinatário {transferencia.Destinatario.Pessoa.Nome} - Valor {transferencia.Valor} - Tipo {transferencia.Tipo}");
        }
    }

    private static Transferencia EscolherTransferenciaAlterar(TransferenciaService transferenciaService)
    {
        MostrarTransferencia(transferenciaService);
        ColouredConsole.WriteLine("Digite o ID  que gostaria de alterar.");
        var id = Console.ReadLine();
        return transferenciaService.Get(Numero.TextoParaInt(id)); ;
    }

    private static void EditarTranasferencia(TransferenciaService transferenciaService)
    {
        var transferencia = EscolherTransferenciaAlterar(transferenciaService);
        if (transferencia != null)
        {
            var texto = "";
            ColouredConsole.WriteLine("Tipo: ");
            ColouredConsole.WriteLine("Digite outro valor para alterar, ou deixar em branco para manter.");
            texto = Console.ReadLine();
            if (!string.IsNullOrEmpty(texto)) { }
        }
        else
        {
            ColouredConsole.WriteLine("ID de transferencia inexistente.");
        }
    }

    private static void RemoverTranasferencia(TransferenciaService transferenciaService)
    {
        var transferencia = EscolherTransferenciaAlterar(transferenciaService);
        if (transferencia != null)
        {
            transferenciaService.Remove(transferencia);
            ColouredConsole.WriteLine($"Transferencia ID - {transferencia.ID} - Remetente {transferencia.Remetente.Pessoa.Nome} - Destinatário {transferencia.Destinatario.Pessoa.Nome}");
        }
        else
        {
            ColouredConsole.WriteLine("ID da transnferência inexistente.");
        }
    }
}
