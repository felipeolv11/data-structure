using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite uma palavra: ");
            string palavra = Console.ReadLine();
            
            char[] letras = palavra.ToCharArray();

            Stack<char> pilha = new Stack<char>();

            for (int i = 0; i < letras.Length; i++)
            {
                pilha.Push(letras[i]);
            }

            Queue<char> fila = new Queue<char>();

            foreach (char letra in pilha)
            {
                fila.Enqueue(letra);
            }

            string palavra_invertida = "";

            foreach(char letra in fila)
            {
                palavra_invertida += letra.ToString();
            }

            Console.WriteLine("Palavra invertida:");
            Console.WriteLine(palavra_invertida);

            Console.ReadLine();
        }
    }
}
