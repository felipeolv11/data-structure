using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio03
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[100];

            Random rand = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(1, 10);
            }

            Console.WriteLine("Digite um número de 1 a 10: ");
            int x = int.Parse(Console.ReadLine());

            int qtd = BuscaSequencial(arr, x);

            if (qtd != 0)
                Console.WriteLine("Este número aparece '{0}' vezes no array.", qtd);

            else
                Console.WriteLine("O número não se encontra no array.");

            Console.WriteLine("Deseja ver o array? (sim/nao)");
            string resp = Console.ReadLine();

            if (resp == "sim")
                Mostrar(arr);

            Console.ReadLine();
        }

        static int BuscaSequencial(int[] arr, int x)
        {
            int count = 0;

            for (int i = 0; i < arr.Length; ++i)
            {
                if (arr[i] == x)
                    count++;
            }

            return count;
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
