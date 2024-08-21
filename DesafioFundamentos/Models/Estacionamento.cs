using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial;
        private decimal precoPorHora;
        private List<string> veiculos;

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
            this.veiculos = new List<string>();
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();

            if (ValidarPlaca(placa))
            {
                veiculos.Add(placa.ToUpper());
                Console.WriteLine($"O veículo com a placa {placa} foi adicionado ao estacionamento.");
            }
            else
            {
                Console.WriteLine("Placa inválida. Certifique-se de que a placa está no formato correto.");
            }
        }

        public void RemoverVeiculo()
        {
            ListarVeiculos();

            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            if (ValidarPlaca(placa))
            {
                string placaFormatada = placa.ToUpper();
                if (veiculos.Contains(placaFormatada))
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                    int horas;
                    while (!int.TryParse(Console.ReadLine(), out horas) || horas < 0)
                    {
                        Console.WriteLine("Entrada inválida. Digite um número inteiro positivo para as horas:");
                    }

                    decimal valorTotal = precoInicial + precoPorHora * horas;
                    veiculos.Remove(placaFormatada);

                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal:F2}");
                }
                else
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
                }
            }
            else
            {
                Console.WriteLine("Placa inválida. Certifique-se de que a placa está no formato correto.");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        private bool ValidarPlaca(string placa)
        {
            string padraoPlaca = @"^([A-Z]{3}-\d{4}|[A-Z]{3}\d[A-Z]\d{2})$";
            return Regex.IsMatch(placa.Trim(), padraoPlaca, RegexOptions.IgnoreCase);
        }
    }
}