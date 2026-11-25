using DesafioFundamentos.Models;

Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial = 0;
decimal precoPorHora = 0;

Console.WriteLine("Seja bem vindo ao sistema de estacionamento!\n" +
                  "Digite o preço inicial:");
precoInicial = Convert.ToDecimal(Console.ReadLine());

Console.WriteLine("Agora digite o preço por hora:");
precoPorHora = Convert.ToDecimal(Console.ReadLine());

Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

string opcao = string.Empty;
bool exibirMenu = true;

while (exibirMenu)
{
    LimparTela();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");

    opcao = Console.ReadLine();

    LimparTela();

    switch (opcao)
    {
        case "1":
            es.AdicionarVeiculo();
            break;

        case "2":
            es.RemoverVeiculo();
            break;

        case "3":
            es.ListarVeiculos();
            break;

        case "4":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    if (opcao != "4")
    {
        Console.WriteLine("Pressione uma tecla para continuar");
        AguardarTecla();
    }
}
Console.WriteLine("O programa se encerrou");

// Console.Clear falha quando a saída não é um terminal (entrada redirecionada, CI)
static void LimparTela()
{
    if (!Console.IsOutputRedirected)
    {
        Console.Clear();
    }
}

// Console.ReadKey falha com a entrada redirecionada; nesse caso lê uma linha
static void AguardarTecla()
{
    if (Console.IsInputRedirected)
    {
        Console.ReadLine();
    }
    else
    {
        Console.ReadKey();
    }
}