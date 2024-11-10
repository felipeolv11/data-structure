using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio08
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 3, 4, 7, 11, 18, 23, 27, 31, 48 };

            Console.WriteLine("Digite o número que deseja inserir no array: ");
            int x = int.Parse(Console.ReadLine());

            arr = InserirOrdenado(arr, x);

            Console.WriteLine("Array após inserção do '{0}':", x);
            Mostrar(arr);

            Console.ReadLine();
        }

        static int[] InserirOrdenado(int[] arr, int x)
        {
            int[] r = new int[arr.Length + 1];
            int pos = PesquisaBinaria(arr, x);

            for (int i = 0; i < pos; i++)
            {
                r[i] = arr[i];
            }

            r[pos] = x;

            for (int i = pos; i < arr.Length; i++)
            {
                r[i + 1] = arr[i];
            }

            return r;
        }

        static int PesquisaBinaria(int[] arr, int x)
        {
            int esq = 0, dir = arr.Length - 1, meio;

            while (esq <= dir)
            {
                meio = (esq + dir) / 2;
                if (x == arr[meio])
                {
                    return meio;
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

            return esq;
        }

        static void Mostrar(int[] arr)
        {
            Console.Write("[ ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine("]");
        }
    }
}
