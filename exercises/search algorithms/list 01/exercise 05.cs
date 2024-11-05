using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio05
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            if (EhOrdenado(arr1))
                Console.WriteLine("O array está ordenado.");

            else
                Console.WriteLine("O array não está ordenado");

            Console.WriteLine();

            int[] arr2 = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            if (EhOrdenado(arr2))
                Console.WriteLine("O array está ordenado.");

            else
                Console.WriteLine("O array está desordenado.");

            Console.ReadLine();
        }

        static bool EhOrdenado(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
