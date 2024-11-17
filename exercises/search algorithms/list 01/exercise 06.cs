using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio06
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 2, 5, 8, 12, 14, 23, 32 };
            int x = 13;

            int val = ValorMaisProx(arr, arr.Length, x);

            Console.WriteLine("O valor mais próximo de '{0}' no array é: '{1}'", x, val);

            Console.ReadLine();
        }

        static int ValorMaisProx(int[] arr, int n, int x)
        {
            int dir = n - 1, esq = 0, meio;

            int maisProximo = arr[0];

            while (esq <= dir)
            {
                meio = (esq + dir) / 2;
                int atual = arr[meio];

                int diferencaAtual = atual - x;
                if (diferencaAtual < 0)
                {
                    diferencaAtual = diferencaAtual * -1;
                }

                int diferencaMaisProx = maisProximo - x;
                if (diferencaMaisProx < 0)
                {
                    diferencaMaisProx = diferencaMaisProx * -1;
                }

                if (diferencaAtual < diferencaMaisProx || (diferencaAtual == diferencaMaisProx && atual < maisProximo))
                {
                    maisProximo = atual;
                }

                if (atual < x)
                    esq = meio + 1;

                else if (atual > x)
                    dir = meio - 1;
                    
                else
                    return atual;
            }

            return maisProximo;
        }
    }
}
