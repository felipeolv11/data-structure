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
            Fila fila1 = new Fila();
            Fila fila2 = new Fila();

            fila1.Inserir(1);
            fila1.Inserir(2);
            fila1.Inserir(3);

            fila2.Inserir(3);
            fila2.Inserir(4);
            fila2.Inserir(5);

            Fila fila3 = new Fila();

            PreencherEmOrdem(fila1, fila2, fila3);

            Console.WriteLine("Fila 3:");
            fila3.Mostrar();

            Console.ReadLine();
        }

        static Fila PreencherEmOrdem(Fila f1, Fila f2, Fila f3)
        {
            while (f1.Primeiro != f1.Ultimo && f2.Primeiro != f2.Ultimo)
            {
                int f1_elemento = f1.Primeiro.Prox.Elemento;
                int f2_elemento = f2.Primeiro.Prox.Elemento;

                if (f1_elemento <= f2_elemento)
                {
                    f3.Inserir(f1.Remover());
                }

                else
                {
                    f3.Inserir(f2.Remover());
                }
            }

            while (f1.Primeiro != f1.Ultimo)
            {
                f3.Inserir(f1.Remover());
            }

            while (f2.Primeiro != f2.Ultimo)
            {
                f3.Inserir(f2.Remover());
            }

            return f3;
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
            get { return this.elemento; }
            set { this.elemento = value; }
        }

        public Celula Prox
        {
            get { return this.prox; }
            set { this.prox = value; }
        }
    }

    class Fila
    {
        private Celula primeiro, ultimo;
        
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

        public Fila()
        {
            primeiro = new Celula();
            ultimo = primeiro;
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
