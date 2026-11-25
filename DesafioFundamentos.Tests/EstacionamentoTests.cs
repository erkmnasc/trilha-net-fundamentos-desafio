using DesafioFundamentos.Models;

namespace DesafioFundamentos.Tests;

// O Estacionamento lê e escreve no Console. Os testes trocam a entrada e a
// saída do Console por strings para simular o que o usuário digita.
// Por isso ficam todos nesta classe, que o xUnit executa em sequência.
public class EstacionamentoTests : IDisposable
{
    private readonly TextReader _entradaOriginal = Console.In;
    private readonly TextWriter _saidaOriginal = Console.Out;
    private readonly StringWriter _saida = new();

    public EstacionamentoTests()
    {
        Console.SetOut(_saida);
    }

    public void Dispose()
    {
        Console.SetIn(_entradaOriginal);
        Console.SetOut(_saidaOriginal);
    }

    private static void Digitar(params string[] linhas)
    {
        Console.SetIn(new StringReader(string.Join(Environment.NewLine, linhas) + Environment.NewLine));
    }

    private string Saida => _saida.ToString();

    [Theory]
    [InlineData("ABC-1234")]
    [InlineData("abc-1234")]
    [InlineData("BRA2E19")]
    public void AdicionarVeiculo_ComPlacaValida_AdicionaNaLista(string placa)
    {
        var estacionamento = new Estacionamento(5, 2);

        Digitar(placa);
        estacionamento.AdicionarVeiculo();
        estacionamento.ListarVeiculos();

        Assert.Contains("foi adicionado ao estacionamento", Saida);
        Assert.Contains(placa.ToUpper(), Saida);
    }

    [Theory]
    [InlineData("")]
    [InlineData("AB-123")]
    [InlineData("ABCD1234")]
    [InlineData("1234-ABC")]
    public void AdicionarVeiculo_ComPlacaInvalida_NaoAdiciona(string placa)
    {
        var estacionamento = new Estacionamento(5, 2);

        Digitar(placa);
        estacionamento.AdicionarVeiculo();
        estacionamento.ListarVeiculos();

        Assert.Contains("Placa inválida", Saida);
        Assert.Contains("Não há veículos estacionados.", Saida);
    }

    [Fact]
    public void RemoverVeiculo_CalculaPrecoInicialMaisHoras()
    {
        var estacionamento = new Estacionamento(5, 2);

        Digitar("ABC-1234", "ABC-1234", "3");
        estacionamento.AdicionarVeiculo();
        estacionamento.RemoverVeiculo();

        // 5 + 2 x 3 = 11
        var valorEsperado = $"R$ {11m:F2}";
        Assert.Contains($"O veículo ABC-1234 foi removido e o preço total foi de: {valorEsperado}", Saida);
    }

    [Fact]
    public void RemoverVeiculo_PedeHorasDeNovoQuandoEntradaInvalida()
    {
        var estacionamento = new Estacionamento(10, 1);

        Digitar("ABC-1234", "ABC-1234", "abc", "-1", "2");
        estacionamento.AdicionarVeiculo();
        estacionamento.RemoverVeiculo();

        Assert.Contains("Entrada inválida", Saida);
        Assert.Contains($"R$ {12m:F2}", Saida);
    }

    [Fact]
    public void RemoverVeiculo_QueNaoEstaEstacionado_InformaQueNaoEncontrou()
    {
        var estacionamento = new Estacionamento(5, 2);

        Digitar("XYZ-9999");
        estacionamento.RemoverVeiculo();

        Assert.Contains("esse veículo não está estacionado aqui", Saida);
    }

    [Fact]
    public void RemoverVeiculo_TiraOVeiculoDaLista()
    {
        var estacionamento = new Estacionamento(5, 2);

        Digitar("ABC-1234", "ABC-1234", "1");
        estacionamento.AdicionarVeiculo();
        estacionamento.RemoverVeiculo();
        _saida.GetStringBuilder().Clear();
        estacionamento.ListarVeiculos();

        Assert.Equal("Não há veículos estacionados.", Saida.Trim());
    }
}
