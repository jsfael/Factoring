using System;
using System.Collections.Generic;
using System.Linq;

namespace Factoring
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Este programa verifica se um número é primo e, caso não seja, exibe seus fatores.");
                Console.WriteLine("Digite um ou mais números inteiros positivos separados por vírgula:");

                try
                {
                    var input = Console.ReadLine();
                    var numbers = input.Split(',')
                                       .Select(n => int.Parse(n.Trim()))
                                       .ToList();

                    foreach (var number in numbers)
                    {
                        if (IsPrime(number))
                        {
                            Console.WriteLine($"{number} é primo");
                        }
                        else
                        {
                            Console.WriteLine($"{number} não é primo");
                            var factors = Factorize(number);
                            Console.WriteLine($"Fatores de {number}: {string.Join(", ", factors)}");
                        }
                    }

                    if (numbers.Count > 1)
                    {
                        int mmc = CalculateMMC(numbers);
                        int mdc = CalculateMDC(numbers);
                        Console.WriteLine($"MMC dos números: {mmc}");
                        Console.WriteLine($"MDC dos números: {mdc}");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Entrada inválida. Certifique-se de digitar apenas números inteiros positivos separados por vírgula.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu um erro: {ex.Message}");
                }

                Console.WriteLine("Deseja fatorar outros números? (s/n)");
            } while (Console.ReadLine().Trim().ToLower() == "s");

            Console.WriteLine("Programa encerrado.");
        }

        static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            for (int i = 3; i <= Math.Sqrt(number); i += 2)
            {
                if (number % i == 0) return false;
            }

            return true;
        }

        static List<int> Factorize(int number)
        {
            var factors = new List<int>();
            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    factors.Add(i);
                }
            }
            return factors;
        }

        static int CalculateMDC(List<int> numbers)
        {
            return numbers.Aggregate(CalculateMDC);
        }

        static int CalculateMDC(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        static int CalculateMMC(List<int> numbers)
        {
            return numbers.Aggregate(CalculateMMC);
        }

        static int CalculateMMC(int a, int b)
        {
            return (a / CalculateMDC(a, b)) * b;
        }
    }
}
