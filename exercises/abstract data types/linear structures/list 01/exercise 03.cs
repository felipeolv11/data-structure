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
            Pilha queue = new Pilha();

            Console.WriteLine("Digite um número inteiro N: ");
            int n = int.Parse(Console.ReadLine());

            int a = 0; int b = 1;

            queue.Push(a);
            queue.Push(b);

            for (int i = 2; i < n; i++)
            {
                int c = a + b;

                queue.Push(c);

                a = b;
                b = c;
            }

            Console.WriteLine("Ordem inversa da sequência de Fibonacci:");
            int num = 0;

            for (int i = n; i > 0; i--)
            {
                num = queue.Pop();

                Console.Write(num + " ");
            }

            Console.ReadLine();
        }
    }

    class Pilha
    {
        private int[] array;
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
            this.array = new int[tamanho];
            this.topo = 0;
        }

        public void Push(int x)
        {
            if (topo >= array.Length)
                throw new Exception("Erro!");

            array[topo] = x;
            topo++;
        }

        public int Pop()
        {
            if (topo == 0)
                throw new Exception("Erro!");

            topo = topo - 1;

            return array[topo];
        }
    }
}
