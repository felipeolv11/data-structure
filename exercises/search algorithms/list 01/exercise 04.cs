using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace exercicio04
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 4, 4, 4, 6, 6, 11, 12, 13, 13, 14, 14, 14 };

            Console.WriteLine("Digite um alvo:");
            int x = int.Parse(Console.ReadLine());

            int primeira_ocorrencia = FirstIndex(arr, x);
            int ultima_ocorrencia = LastIndex(arr, x);

            if (primeira_ocorrencia != -1)
            {
                Console.WriteLine("A primeira ocorrência do alvo no array foi no índice: {0}", primeira_ocorrencia);
                Console.WriteLine("A última ocorrência do alvo no array foi no índice: {0}", ultima_ocorrencia);
            }

            else
            {
                Console.WriteLine("O alvo não se encontra no array.");
            }

            Console.ReadLine();
        }

        static int FirstIndex(int[] arr, int x)
        {
            int esq = 0, dir = arr.Length - 1;
            int resp = -1;

            while (esq <= dir)
            {
                int meio = esq + (dir - esq) / 2;

                if (x == arr[meio])
                {
                    resp = meio;
                    dir = meio - 1;
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

            if (resp != -1)
                return resp + 1;
            
            return resp;
        }

        static int LastIndex(int[] arr, int x)
        {
            int esq = 0, dir = arr.Length - 1;
            int resp = -1;

            while (esq <= dir)
            {
                int meio = esq + (dir - esq) / 2;

                if (x == arr[meio])
                {
                    resp = meio;
                    esq = meio + 1;
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

            if (resp != -1)
                return resp + 1;

            return resp;
        }
    }
}