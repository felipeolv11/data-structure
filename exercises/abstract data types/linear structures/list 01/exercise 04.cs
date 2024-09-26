using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite uma palavra: ");
            string palavra = Console.ReadLine();

            char[] letras = palavra.ToCharArray();

            Pilha pilha = new Pilha();

            for (int i = 0; i < letras.Length; i++)
            {
                pilha.Push(letras[i]);
            }

            string palavra_invertida = "";

            for (int i = 0; i < letras.Length; i++)
            {
                palavra_invertida += pilha.Pop().ToString();
            }

            Console.WriteLine("Palavra invertida:");
            Console.WriteLine(palavra_invertida);

            Console.ReadLine();
        }
    }

    class Pilha
    {
        private char[] array;
        private int topo;

        public Pilha()
        {
            inicializar(100);
        }

        public Pilha(int tamanho)
        {
            inicializar(tamanho);
        }

        private void inicializar(int tamanho)
        {
            this.array = new char[tamanho];
            this.topo = 0;
        }

        public void Push(char x)
        {
            if (topo >= array.Length)
                throw new Exception("Erro!");

            array[topo] = x;
            topo++;
        }

        public char Pop()
        {
            if (topo == 0)
                throw new Exception("Erro!");

            topo = topo - 1;

            return array[topo];
        }
    }
}