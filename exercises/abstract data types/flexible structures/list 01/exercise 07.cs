﻿using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio07
{
    class Program
    {
        static void Main(string[] args)
        {
            ListaDupla lista = new ListaDupla();

            lista.InserirFim(1);
            lista.InserirFim(2);
            lista.InserirFim(3);
            lista.InserirFim(4);
            lista.InserirFim(5);

            Console.WriteLine("Lista:");
            lista.Mostrar();

            Inverter(lista);

            Console.WriteLine("Lista invertida:");
            lista.Mostrar();

            Console.ReadLine();
        }

        static void Inverter(ListaDupla lista)
        {
            ListaDupla tmp = new ListaDupla();
            while (lista.Tamanho() > 0)
            {
                tmp.InserirFim(lista.RemoverFim());
            }

            while (tmp.Tamanho() > 0)
            {
                lista.InserirInicio(tmp.RemoverFim());
            }
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

        public CelulaDupla Primero
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
                for (int j = 0; j < pos; j++, i = i.Prox);
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
            {
                tam++;
            }

            return tam;
        }
    }
}
