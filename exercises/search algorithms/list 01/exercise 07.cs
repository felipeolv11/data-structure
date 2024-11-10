using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio07
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[100];
            Random rnd = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(1, 10);
            }

            Console.WriteLine("Digite o alvo que deseja buscar os indíces no array: ");
            int x = int.Parse(Console.ReadLine());

            int[] r = BuscaSequencial(arr, x);

            if (r.Length > 0)
            {
                Console.WriteLine("O alvo se encontra nos seguintes indíces:");

                Console.Write("[ ");
                for (int i = 0; i < r.Length; i++)
                {
                    if (r[i] != 0)
                    {
                        Console.Write(r[i] + " ");
                    }
                }
                Console.WriteLine("]");

                Console.WriteLine("Deseja ver o array? (sim/nao)");
                string resp = Console.ReadLine();

                if (resp == "sim")
                {
                    Console.Write("[ ");
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (arr[i] != 0)
                        {
                            Console.Write(arr[i] + " ");
                        }
                    }
                    Console.WriteLine("]");
                }
            }

            else
            {
                Console.WriteLine("O alvo não se encontra dentro do array.");
            }

            Console.ReadLine();
        }

        static int[] BuscaSequencial(int[] arr, int x)
        {
            int[] r = new int[arr.Length];
            int j = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (x == arr[i])
                {   
                    r[j] = i;
                    j++;
                }
            }

            return r;
        }
    }
}
