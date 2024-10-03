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
            Fila fila1 = new Fila();
            Fila fila2 = new Fila();

            fila1.Inserir(1);
            fila1.Inserir(2);
            fila1.Inserir(3);

            fila2.Inserir(4);
            fila2.Inserir(5);
            fila2.Inserir(6);

            Concatenar(fila1, fila2);

            Console.WriteLine("F1 concatenada com a F2:");
            fila1.Mostrar();

            Console.ReadLine();
        }

        static void Concatenar(Fila f1, Fila f2)
        {
            while (f2.Primeiro.Prox != null)
            {
                f1.Inserir(f2.Remover());
            }
        }
    }

    class Celula
    {
        private int elemento;
        private Celula prox;

        public Celula()
        {
            this.elemento = 0;
            this.prox = null;
        }

        public Celula(int elemento)
        {
            this.elemento = elemento;
            this.prox = null;
        }

        public int Elemento
        {
            get { return elemento; }
            set { elemento = value; }
        }

        public Celula Prox
        {
            get { return prox; }
            set { prox = value; }
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
            set { primeiro = value; }
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
            for(Celula i = primeiro.Prox; i != null; i = i.Prox)
            {
                Console.Write(i.Elemento + " ");
            }
            Console.WriteLine("]");
        }
    }
}
