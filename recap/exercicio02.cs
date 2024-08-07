using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] vetorX = new int[5];
            int[] vetorY = new int[5];

            int[] vetorTotal = new int[5];
            int[] vetorProduto = new int[5];
            int[] vetorSubt = new int[5];

            for (int i = 0; i < vetorX.Length; i++)
            {
                Console.WriteLine($"Preencha a posição n{i + 1} do vetor x: ");
                vetorX[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < vetorY.Length; i++)
            {
                Console.WriteLine($"Preencha a posição n{i + 1} do vetor y: ");
                vetorY[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < vetorTotal.Length; i++)
            {
                vetorTotal[i] = vetorX[i] + vetorY[i];

                Console.Write(vetorTotal[i] + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < vetorProduto.Length; i++)
            {
                vetorProduto[i] = vetorX[i] * vetorY[i];

                Console.Write(vetorProduto[i] + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < vetorSubt.Length; i++)
            {
                vetorSubt[i] = vetorX[i] - vetorY[i];

                Console.Write(vetorSubt[i] + " ");
            }

            Console.ReadLine();
        }
    }
}
