using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio05
{
    internal class Program
    {
        static string CensurarTexto(string texto, string[] palavrasProibidas)
        {
            texto = texto.ToLower();

            foreach (string palavra in palavrasProibidas)
            {
                texto = texto.Replace(palavra.ToLower(), "[censurado]");
            }

            return texto;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Digite um texto: ");
            string texto = Console.ReadLine();

            string[] palavrasProibidas = new string[3];

            Console.WriteLine("Digite 3 palavras para censurar: ");

            for (int i = 0; i < palavrasProibidas.Length; i++)
            {
                palavrasProibidas[i] = Console.ReadLine();
            }

            string resultado = CensurarTexto(texto, palavrasProibidas);

            Console.WriteLine(resultado);

            Console.ReadLine();
        }
    }
}
