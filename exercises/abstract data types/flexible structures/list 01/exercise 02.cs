using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace exercicio02
{
    class Program
    {
        static void Main(string[] args)
        {
            Pilha p = new Pilha();

            Console.WriteLine("Digite o tamanho da palavra: ");
            int tam = int.Parse(Console.ReadLine());

            for (int i = 0; i < tam; i++)
            {
                Console.WriteLine($"Digite a {i+1} letra:");
                char letra = char.Parse(Console.ReadLine());

                p.Inserir(letra);
            }

            if (EhPalindromo(p))
                Console.WriteLine("A palavra é um palindromo");
            else
                Console.WriteLine("A palavra não é um palindromo");

            Console.ReadLine();
        }

        static bool EhPalindromo(Pilha p)
        {
            Pilha temp = new Pilha();
            Pilha restaurar = new Pilha();

            char[] letras = new char[10];
            int count = 0;

            while (p.Topo != null)
            {
                char letra = p.Remover();
                letras[count] = letra;
                count++;

                restaurar.Inserir(letra);
            }

            while (restaurar.Topo != null)
            {
                p.Inserir(restaurar.Remover());
            }

            int inicio = 0;
            int fim = count - 1;
            while (inicio < fim)
            {
                if (letras[inicio] != letras[fim])
                {
                    return false;
                }
                inicio++;
                fim--;
            }

            return true;
        }
    }

    class Celula
    {
        private char elemento;
        private Celula prox;

        public Celula()
        {
            this.prox = null;
        }

        public Celula(char elemento)
        {
            this.elemento = elemento;
            this.prox = null;
        }

        public Celula Prox
        {
            get { return prox; }
            set { prox = value; }
        }

        public char Elemento
        {
            get { return elemento; }
            set { elemento = value; }
        }
    }

    class Pilha
    {
        private Celula topo;

        public Pilha()
        {
            this.topo = null;
        }

        public Celula Topo
        {
            get { return topo; }
            set { topo = value; }
        }

        public void Inserir(char x)
        {
            Celula temp = new Celula(x);
            temp.Prox = topo;
            topo = temp;
            temp = null;
        }

        public char Remover()
        {
            if (topo == null)
                throw new Exception("Erro!");

            char elemento = topo.Elemento;

            Celula temp = topo;
            topo = topo.Prox;
            temp.Prox = null;
            temp = null;

            return elemento;
        }

        public void Mostrar()
        {
            Console.Write("[ ");
            for (Celula i = topo; i != null; i = i.Prox)
            {
                Console.Write(i.Elemento + " ");
            }
            Console.WriteLine("]");
        }
    }
}
