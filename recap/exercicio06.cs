using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio06
{
    internal class Program
    {
        static string[,] ConverterCSVParaMatriz(string CSV)
        {
            string[] linhas = CSV.Split('\n');

            int numLinhas = linhas.Length;
            int numColunas = linhas[0].Split(',').Length;

            string[,] matriz = new string[numLinhas, numColunas];

            for (int i = 0; i < numLinhas; i++)
            {
                string[] colunas = linhas[i].Split(',');

                for (int j = 0; j < numColunas; j++)
                {
                    matriz[i, j] = colunas[j];
                }
            }

            return matriz;
        }

        static void Main(string[] args)
        {
            string CSV = "nome,idade,sexo\nAna,25,F\nJoao,30,M\nMaria,22,F";

            string[,] resultado = ConverterCSVParaMatriz(CSV);

            for (int i = 0; i < resultado.GetLength(0); i++)
            {
                for (int j = 0; j < resultado.GetLength(1); j++)
                {
                    Console.Write(resultado[i, j] + " ");
                }

                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
