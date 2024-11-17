using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio10
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 5, 8, 12, 19, 23, 27, 32, 44 };

            int x = 23;

            int res = PesquisaBinariaRecursiva(array, 0, array.Length - 1, x);

            if (res != -1)
            {
                Console.WriteLine($"Valor encontrado no índice: {res}");
            }

            else
            {
                Console.WriteLine("Valor não encontrado.");
            }

            Console.ReadLine();
        }

        static int PesquisaBinariaRecursiva(int[] arr, int esq, int dir, int x)
        {
            if (esq > dir)
            {
                return -1;
            }

            int meio = (esq + dir) / 2;

            if (arr[meio] == x)
            {
                return meio;
            }

            if (arr[meio] < x)
            {
                return PesquisaBinariaRecursiva(arr, meio + 1, dir, x);
            }

            else
            {
                return PesquisaBinariaRecursiva(arr, esq, meio - 1, x);
            }
        }
    }
}
