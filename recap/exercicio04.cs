using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio04
{
    internal class Program
    {
        static int ContarCaracteres(string s, char c, int i)
        {
            int contagem = 0;

            if (i < 0 || i >= s.Length)
            {
                return 0;
            }

            for (int j = i; j < s.Length; j++)
            {
                if (s[j] == c)
                {
                    contagem++;
                }
            }

            return contagem;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Digite a palavra: ");
            string palavra = Console.ReadLine();

            Console.WriteLine("Digite o caractere: ");
            char caractere = char.Parse(Console.ReadLine());

            Console.WriteLine("Digite a posição: ");
            int posicao = int.Parse(Console.ReadLine());

            Console.WriteLine(ContarCaracteres(palavra, caractere, posicao));

            Console.ReadLine();
        }
    }
}
