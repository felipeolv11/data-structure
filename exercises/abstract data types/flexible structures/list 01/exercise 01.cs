using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio01
{
    class Program
    {
        static void Main(string[] args)
        {
            Pilha pilha = new Pilha();

            pilha.Inserir(3);
            pilha.Inserir(2);
            pilha.Inserir(1);

            Console.WriteLine("Pilha:");
            pilha.Mostrar();

            pilha.Inverter();

            Console.WriteLine("Pilha invertida:");
            pilha.Mostrar();

            Console.ReadLine();
        }
    }

    class Celula
    {
        private int elemento;
        private Celula prox;

        public Celula(int elemento)
        {
            this.elemento = elemento;
            this.prox = null;
        }

        public Celula ()
        {
            this.elemento = 0;
            this.prox = null;
        }

        public Celula Prox
        {
            get { return prox; }
            set { prox = value; }
        }

        public int Elemento
        {
            get { return elemento; }
            set { elemento = value; }
        }
    }

    class Pilha
    {
        private Celula topo;

        public Celula Topo
        {
            get { return topo; }
            set { topo = value; }
        }

        public Pilha()
        {
            topo = null;
        }

        public void Inserir(int x)
        {
            Celula tmp = new Celula(x);
            tmp.Prox = topo;
            topo = tmp;
            tmp = null;
        }

        public int Remover()
        {
            if (topo == null)
                throw new Exception("Erro!");

            int elemento = topo.Elemento;
            Celula tmp = topo;
            topo = topo.Prox;
            tmp.Prox = null;
            tmp = null;

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

        public void Inverter()
        {
            Pilha temp = new Pilha();

            while (topo != null)
            {
                temp.Inserir(Remover());
            }

            topo = temp.Topo;
        }
    }
}
