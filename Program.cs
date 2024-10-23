using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bem-vindo ao Estacionamento!");

        // Definir o valor inicial e o valor por hora do estacionamento
        Console.Write("Por favor, insira o valor inicial do estacionamento: ");
        decimal valorInicial = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Por favor, insira o valor por hora do estacionamento: ");
        decimal valorHora = Convert.ToDecimal(Console.ReadLine());

        List<string> veiculos = new List<string>(); // Lista de veículos estacionados
        Dictionary<string, DateTime> horariosEntrada = new Dictionary<string, DateTime>(); // Armazena a hora de entrada

        bool exibirMenu = true;

        while (exibirMenu)
        {
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("1 - Cadastrar veículo");
            Console.WriteLine("2 - Remover veículo");
            Console.WriteLine("3 - Listar veículos");
            Console.WriteLine("4 - Sair");

            switch (Console.ReadLine())
            {
                case "1":
                    // Cadastrar veículo
                    Console.Write("Digite a placa do veículo para estacionar: ");
                    string placa = Console.ReadLine();
                    
                    if (veiculos.Contains(placa.ToUpper()))
                    {
                        Console.WriteLine("Este veículo já está estacionado.");
                    }
                    else
                    {
                        veiculos.Add(placa.ToUpper());
                        horariosEntrada.Add(placa.ToUpper(), DateTime.Now); // Salva o horário de entrada
                        Console.WriteLine($"Veículo {placa.ToUpper()} foi estacionado.");
                    }
                    break;

                case "2":
                    // Remover veículo
                    Console.Write("Digite a placa do veículo para remover: ");
                    string placaRemover = Console.ReadLine();

                    if (veiculos.Contains(placaRemover.ToUpper()))
                    {
                        DateTime horaEntrada = horariosEntrada[placaRemover.ToUpper()];
                        DateTime horaSaida = DateTime.Now;
                        TimeSpan tempoEstacionado = horaSaida - horaEntrada;

                        int horasEstacionadas = (int)Math.Ceiling(tempoEstacionado.TotalHours); // Arredonda para cima as horas

                        decimal valorTotal = valorInicial + (horasEstacionadas * valorHora);

                        Console.WriteLine($"O veículo {placaRemover.ToUpper()} ficou estacionado por {horasEstacionadas} hora(s) e o valor total a ser pago é: R$ {valorTotal:F2}");

                        veiculos.Remove(placaRemover.ToUpper());
                        horariosEntrada.Remove(placaRemover.ToUpper());
                    }
                    else
                    {
                        Console.WriteLine("Este veículo não está estacionado.");
                    }
                    break;

                case "3":
                    // Listar veículos
                    if (veiculos.Count > 0)
                    {
                        Console.WriteLine("Veículos estacionados:");
                        foreach (string v in veiculos)
                        {
                            Console.WriteLine(v);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Não há veículos estacionados.");
                    }
                    break;

                case "4":
                    // Sair
                    exibirMenu = false;
                    Console.WriteLine("Saindo...");
                    break;

                default:
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    break;
            }
        }
    }
}
