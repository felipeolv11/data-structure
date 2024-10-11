using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio08
{
    class Program
    {
        static void Main(string[] args)
        {
            Lista lista = new Lista();
            ListaDupla lista_dupla = new ListaDupla();

            Random rnd = new Random();

            int pos = 0;
            int elem = 0;

            for(int i = 0; i < 10; i++)
                lista.InserirInicio(rnd.Next(1, 100));

            Console.WriteLine("Lista");
            lista.Mostrar();

            if (lista.MaiorValor(ref pos, ref elem))
                Console.WriteLine("Maior: {0}, Posição: {1}", elem, pos);

            else
                Console.WriteLine("Erro!");

            Console.WriteLine();

            for (int i = 0; i < 10; i++)
                lista_dupla.InserirInicio(rnd.Next(1, 100));

            Console.WriteLine("Lista Dupla");
            lista_dupla.Mostrar();

            if (lista_dupla.MaiorValor(ref pos, ref elem))
                Console.WriteLine("Maior: {0}, Posição: {1}", elem, pos);

            else
                Console.WriteLine("Erro!");

            Console.ReadLine();
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

    class Lista
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

        public Lista()
        {
            primeiro = new Celula();
            ultimo = primeiro;
        }

        public void InserirInicio(int x)
        {
            Celula tmp = new Celula(x);
            tmp.Prox = primeiro.Prox;
            if (primeiro == ultimo)
                ultimo = tmp;
            primeiro.Prox = tmp;
            tmp = null;
        }

        public void InserirFim(int x)
        {
            ultimo.Prox = new Celula(x);
            ultimo = ultimo.Prox;
        }

        public int RemoverInicio()
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

        public int RemoverFim()
        {
            if (primeiro == ultimo)
                throw new Exception("Erro!");

            Celula i;
            for (i = primeiro; i.Prox != ultimo; i = i.Prox) ;
            int elemento = ultimo.Elemento;
            ultimo = i;
            i = ultimo.Prox = null;

            return elemento;
        }

        public void Inserir(int x, int pos)
        {
            int tamanho = Tamanho();
            if (pos < 0 || pos > tamanho)
                throw new Exception("Erro!");
            else if (pos == 0)
                InserirInicio(x);
            else if (pos == tamanho)
                InserirFim(x);
            else
            {
                Celula i = primeiro;
                for (int j = 0; j < pos; j++, i = i.Prox) ;
                Celula tmp = new Celula(x);
                tmp.Prox = i.Prox;
                i.Prox = tmp;
                tmp = i = null;
            }
        }

        public int Remover(int pos)
        {
            int elemento, tamanho = Tamanho();
            if (primeiro == ultimo || pos < 0 || pos >= tamanho)
                throw new Exception("Erro!");
            else if (pos == 0)
                elemento = RemoverInicio();
            else if (pos == tamanho - 1)
                elemento = RemoverFim();
            else
            {
                Celula i = primeiro;
                for (int j = 0; j < pos; j++, i = i.Prox) ;
                Celula tmp = i.Prox;
                elemento = tmp.Elemento;
                i.Prox = tmp.Prox;
                tmp.Prox = null;
                i = tmp = null;
            }

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

        public int Tamanho()
        {
            int tam = 0;
            for (Celula i = primeiro.Prox; i != null; i = i.Prox)
                tam++;
            return tam;
        }

        public bool MaiorValor(ref int pos, ref int elem)
        {
            pos = -1;

            int cont = 0;
            int maior = int.MinValue;
            for (Celula i = primeiro.Prox; i != null; i = i.Prox)
            {
                cont++;
                if (i.Elemento > maior)
                {
                    maior = i.Elemento;

                    pos = cont;
                    elem = maior;
                }
            }

            if (pos == -1)
                return false;

            else
                return true;
        }
    }

    class CelulaDupla
    {
        private int elemento;
        private CelulaDupla prox, ant;

        public CelulaDupla()
        {
            this.elemento = 0;
            this.prox = null;
            this.ant = null;
        }

        public CelulaDupla(int elemento)
        {
            this.elemento = elemento;
            this.prox = null;
            this.ant = null;
        }

        public int Elemento
        {
            get { return elemento; }
            set { elemento = value; }
        }

        public CelulaDupla Prox
        {
            get { return prox; }
            set { prox = value; }
        }

        public CelulaDupla Ant
        {
            get { return ant; }
            set { ant = value; }
        }
    }

    class ListaDupla
    {
        private CelulaDupla primeiro, ultimo;

        public CelulaDupla Primeiro
        {
            get { return primeiro; }
            set { primeiro = value; }
        }
        public CelulaDupla Ultimo
        {
            get { return ultimo; }
            set { ultimo = value; }
        }

        public ListaDupla()
        {
            primeiro = new CelulaDupla();
            ultimo = primeiro;
        }

        public void InserirInicio(int x)
        {
            CelulaDupla tmp = new CelulaDupla(x);
            tmp.Ant = primeiro;
            tmp.Prox = primeiro.Prox;
            primeiro.Prox = tmp;
            if (primeiro == ultimo)
                ultimo = tmp;
            else
            {
                tmp.Prox.Ant = tmp;
            }
            tmp = null;
        }

        public void InserirFim(int x)
        {
            ultimo.Prox = new CelulaDupla(x);
            ultimo.Prox.Ant = ultimo;
            ultimo = ultimo.Prox;
        }

        public int RemoverInicio()
        {
            if (primeiro == ultimo)
                throw new Exception("Erro!");

            CelulaDupla tmp = primeiro;
            primeiro = primeiro.Prox;
            int elemento = primeiro.Elemento;
            tmp.Prox = primeiro.Ant = null;
            tmp = null;

            return elemento;
        }

        public int RemoverFim()
        {
            if (primeiro == ultimo)
                throw new Exception("Erro!");

            int elemento = ultimo.Elemento;
            ultimo = ultimo.Ant;
            ultimo.Prox.Ant = null;
            ultimo.Prox = null;

            return elemento;
        }

        public void Inserir(int x, int pos)
        {
            int tamanho = Tamanho();
            if (pos < 0 || pos > tamanho)
                throw new Exception("Erro!");
            else if (pos == 0)
                InserirInicio(x);
            else if (pos == tamanho)
                InserirFim(x);
            else
            {
                CelulaDupla i = primeiro;
                for (int j = 0; j < pos; j++, i = i.Prox) ;
                CelulaDupla tmp = new CelulaDupla(x);
                tmp.Ant = i;
                tmp.Prox = i.Prox;
                tmp.Ant.Prox = tmp.Prox.Ant = tmp;
                tmp = i = null;
            }
        }

        public int Remover(int pos)
        {
            int elemento, tamanho = Tamanho();
            if (primeiro == ultimo || pos < 0 || pos >= tamanho)
                throw new Exception("Erro!");
            else if (pos == 0)
                elemento = RemoverInicio();
            else if (pos == tamanho - 1)
                elemento = RemoverFim();
            else
            {
                CelulaDupla i = primeiro;
                for (int j = 0; j < pos; j++, i = i.Prox) ;
                i.Ant.Prox = i.Prox;
                i.Prox.Ant = i.Ant;
                elemento = i.Elemento;
                i.Prox = i.Ant = null;
                i = null;
            }

            return elemento;
        }

        public void Mostrar()
        {
            Console.Write("[ ");
            for (CelulaDupla i = primeiro.Prox; i != null; i = i.Prox)
            {
                Console.Write(i.Elemento + " ");
            }
            Console.WriteLine("]");
        }

        public int Tamanho()
        {
            int tam = 0;
            for (CelulaDupla i = primeiro.Prox; i != null; i = i.Prox)
                tam++;
            return tam;
        }

        public bool MaiorValor(ref int pos, ref int elem)
        {
            pos = -1;

            int cont = 0;
            int maior = int.MinValue;
            for (CelulaDupla i = primeiro.Prox; i != null; i = i.Prox)
            {
                cont++;
                if (i.Elemento > maior)
                {
                    maior = i.Elemento;

                    pos = cont;
                    elem = maior;
                }
            }

            if (pos == -1)
                return false;

            else
                return true;
        }
    }
}
