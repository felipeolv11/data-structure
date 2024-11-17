using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio09
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matriz = {
            { 1, 6, 8, 11 },
            { 14, 16, 20, 25 },
            { 28, 33, 34, 51 },
            { 62, 73, 81, 89 }};

            Console.WriteLine("Digite o alvo que deseja encontrar na matriz: ");
            int x = int.Parse(Console.ReadLine());

            int linha = -1, coluna = -1;

            LocalizarValor(matriz, x, ref linha, ref coluna);

            if (linha != -1 && coluna != -1)
                Console.WriteLine("Valor encontrado na posição ({0}, {1})", linha, coluna);

            else
                Console.WriteLine("Valor não encontrado.");

            Console.ReadLine();
        }


        static void LocalizarValor(int[,] matriz, int x, ref int linha, ref int coluna)
        {
            int linhas = matriz.GetLength(0);
            int colunas = matriz.GetLength(1);

            for (int i = 0; i < linhas; i++)
            {
                int[] linhaAtual = new int[colunas];

                for (int j = 0; j < colunas; j++)
                {
                    linhaAtual[j] = matriz[i, j];
                }

                int posicao = PesquisaBinaria(linhaAtual, colunas, x);

                if (posicao != -1)
                {
                    linha = i;
                    coluna = posicao - 1;
                    return;
                }
            }

            linha = -1;
            coluna = -1;
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