using System;
using System.Collections.Generic;

namespace Factoring
{
    class Program
    {
        static void Main(string[] args)
        {
             int number;

            Console.WriteLine("Digite um número inteiro positivo:");
            number = int.Parse(Console.ReadLine());
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

            Console.ReadKey();
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
    }
}

