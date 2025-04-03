using System.Diagnostics.CodeAnalysis;

namespace SimuladorApp;

[ExcludeFromCodeCoverage]
class Program
{
    static void Main()
    {
        Console.WriteLine("=== Simulador de Empréstimo ===");
        Console.Write("Digite seu nome: ");
        string nome = Console.ReadLine();

        try
        {
            var resultado = EmprestimoService.SimularEmprestimo(nome);

            Console.WriteLine("\n=== Resultado da Simulação ===");
            Console.WriteLine($"Nome: {resultado.Nome}");
            Console.WriteLine($"Empréstimo Aprovado: {(resultado.EmprestimoAprovado ? "Sim" : "Não")}");

            if (resultado.EmprestimoAprovado)
            {
                Console.WriteLine($"Nível: {resultado.Nivel}");
                Console.WriteLine($"Valor Aprovado: {resultado.Valor:C}");
            }
            else
            {
                Console.WriteLine("Infelizmente, seu empréstimo não foi aprovado.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }

        Console.WriteLine("\nSimulação finalizada.");
    }
}
