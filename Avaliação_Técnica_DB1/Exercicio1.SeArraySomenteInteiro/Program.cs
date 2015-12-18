using System;
using System.Linq;

namespace Exercicio1.SeArraySomenteInteiro
{
    class Program
    {
        static void Main()
        {
            int[] numeros = { 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144 };
            // encontrar números pares do array
            var verficarArray =
                from n in numeros
                where (n % 2) == 0
                select n;
            // contar quantos números pares o array possui
            var parNumeros = verficarArray.Count();
            // retornar o resultado
            if (parNumeros > 0)
                Console.WriteLine("Array possui números pares.");
            else
                Console.WriteLine("Array possui somente números ímpares.");

            Console.ReadKey();
        }
    }
}
