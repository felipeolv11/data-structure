using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio02
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 4, 8, 13, 24, 32, 61, 79, 88 };

            Console.WriteLine("Digite um alvo:");
            int x = int.Parse(Console.ReadLine());

            int index = PesquisaBinaria(arr, arr.Length, x);

            if (index != -1)
                Console.WriteLine("O indíce do alvo no array é: {0}", index);

            else
                Console.WriteLine("O alvo não se encontra no array.");

            Console.ReadLine();
        }

        static int PesquisaBinaria(int[] arr, int n, int x)
        {
            int resp = -1;
            int dir = n - 1, esq = 0, meio;

            while (esq <= dir)
            {
                meio = (esq + dir) / 2;
                if (x == arr[meio])
                {
                    resp = meio + 1;
                    esq = n;
                }

                else if (x > arr[meio])
                {
                    esq = meio + 1;
                }

                else
                {
                    dir = meio - 1;
                }
            }

            return resp;
        }
    }
}
