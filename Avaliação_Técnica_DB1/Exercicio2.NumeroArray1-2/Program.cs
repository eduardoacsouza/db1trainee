using System;
using System.Linq;

namespace Exercicio2.NumeroArray1_2
{
    class Program
    {
        static void Main()
        {
            int[] primeiroArray = { 1, 3, 7, 29, 42, 98, 234, 93 };
            int[] segundoArray = { 4, 6, 93, 7, 55, 32, 3 };

            // interseção dos arrays
            var intersecaoArray =
                primeiroArray.Except(segundoArray);

            // retornar no console
            foreach (var item in intersecaoArray)
            {
                Console.WriteLine("{0,1}", item);
            }

            Console.ReadKey();
        }
    }
}
