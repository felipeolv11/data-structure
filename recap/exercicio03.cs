using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] matriz = new int[4, 4];

            int linhasNulas = 0;
            int colunasNulas = 0;

            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.WriteLine($"Digite o elemento para a linha {i} e coluna {j}: ");
                    matriz[i, j] = int.Parse(Console.ReadLine());
                }
            }

            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                int contagemLinhas = 0;

                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    if (matriz[i, j] == 0)
                    {
                        contagemLinhas++;
                    }
                }

                if (contagemLinhas == 4)
                {
                    linhasNulas++;
                }
            }

            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                int contagemColunas = 0;

                for (int i = 0; i < matriz.GetLength(0); i++)
                {
                    if (matriz[i, j] == 0)
                    {
                        contagemColunas++;
                    }
                }

                if (contagemColunas == 4)
                {
                    colunasNulas++;
                }
            }

            Console.WriteLine($"Esta matriz tem {linhasNulas} linha(s) nula(s)");
            Console.WriteLine($"Esta matriz tem {colunasNulas} coluna(s) nula(s)");

            Console.ReadLine();
        }
    }
}
