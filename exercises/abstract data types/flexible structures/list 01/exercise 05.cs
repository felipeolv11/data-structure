using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio05
{
    class Program
    {
        static void Main(string[] args)
        {
            Fila fila = new Fila();
            Pilha pilha = new Pilha();

            fila.Inserir(1);
            fila.Inserir(2);
            fila.Inserir(3);

            Console.WriteLine("Fila:");
            fila.Mostrar();

            InverterFila(fila, pilha);

            Console.WriteLine("Fila invertida:");
            fila.Mostrar();

            Console.ReadLine();
        }

        static void InverterFila(Fila f, Pilha p)
        {
            while (f.Primeiro.Prox != null)
            {
                p.Inserir(f.Remover());
            }

            while (p.Topo != null)
            {
                f.Inserir(p.Remover());
            }
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

        public Celula()
        {
            this.elemento = 0;
            this.prox = null;
        }

        public int Elemento
        {
            get { return this.elemento; }
            set { this.elemento = value; }
        }

        public Celula Prox
        {
            get { return this.prox; }
            set { this.prox = value; }
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
            this.topo = null;
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
    }

    class Fila
    {
        private Celula primeiro, ultimo;

        public Fila()
        {
            primeiro = new Celula();
            ultimo = primeiro;
        }

        public Celula Primeiro
        {
            get { return primeiro; }
            set { primeiro = ultimo; }
        }

        public Celula Ultimo
        {
            get { return ultimo; }
            set { ultimo = value; }
        }

        public void Inserir(int x)
        {
            ultimo.Prox = new Celula(x);
            ultimo = ultimo.Prox;
        }

        public int Remover()
        {
            if (primeiro == ultimo)
                throw new Exception("Erro!");

            Celula tmp = primeiro;
            primeiro = primeiro.Prox;
            int elemento = primeiro.Elemento;
            tmp.Prox = null;
            tmp = null;

            return elemento;
        }

        public void Mostrar()
        {
            Console.Write("[ ");
            for (Celula i = primeiro.Prox; i != null; i = i.Prox)
            {
                Console.Write(i.Elemento + " ");
            }
            Console.WriteLine("]");
        }
    }
}
