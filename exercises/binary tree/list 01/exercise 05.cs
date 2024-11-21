﻿using System;
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
            ArvoreBinaria ab = new ArvoreBinaria();

            ab.Inserir(10);
            ab.Inserir(5);
            ab.Inserir(15);
            ab.Inserir(2);
            ab.Inserir(7);
            ab.Inserir(12);
            ab.Inserir(17);

            bool ehCompleta = ab.EhCompleta();
            Console.WriteLine("A árvore é completa? " + ehCompleta);

            Console.ReadLine();
        }
    }

    class ArvoreBinaria
    {
        private No raiz;
        public ArvoreBinaria() { raiz = null; }

        public void Inserir(int x)
        {
            raiz = Inserir(x, raiz);
        }

        private No Inserir(int x, No i)
        {
            if (i == null)
            {
                i = new No(x);
            }

            else if (x < i.Elemento)
            {
                i.Esq = Inserir(x, i.Esq);
            }

            else if (x > i.Elemento)
            {
                i.Dir = Inserir(x, i.Dir);
            }

            else
            {
                throw new Exception("Erro!");
            }

            return i;
        }

        public bool Pesquisar(int x)
        {
            return Pesquisar(x, raiz);
        }

        private bool Pesquisar(int x, No i)
        {
            bool resp;
            if (i == null)
            {
                resp = false;
            }

            else if (x == i.Elemento)
            {
                resp = true;
            }

            else if (x < i.Elemento)
            {
                resp = Pesquisar(x, i.Esq);
            }

            else
            {
                resp = Pesquisar(x, i.Dir);
            }

            return resp;
        }

        public void CaminharCentral()
        {
            CaminharCentral(raiz);
        }

        private void CaminharCentral(No i)
        {
            if (i != null)
            {
                CaminharCentral(i.Esq);
                Console.Write(i.Elemento + " ");
                CaminharCentral(i.Dir);
            }
        }

        public void CaminharPre()
        {
            CaminharPre(raiz);
        }

        private void CaminharPre(No i)
        {
            if (i != null)
            {
                Console.Write(i.Elemento + " ");
                CaminharPre(i.Esq);
                CaminharPre(i.Dir);
            }
        }

        public void CaminharPos()
        {
            CaminharPos(raiz);
        }

        private void CaminharPos(No i)
        {
            CaminharPos(i.Esq);
            CaminharPos(i.Dir);
            Console.Write(i.Elemento + " ");
        }

        public void Remover(int x)
        {
            raiz = Remover(x, raiz);
        }

        private No Remover(int x, No i)
        {
            if (i == null) { throw new Exception("Erro!"); }

            else if (x < i.Elemento)
            {
                i.Esq = Remover(x, i.Esq);
            }

            else if (x > i.Elemento)
            {
                i.Dir = Remover(x, i.Dir);
            }

            else if (i.Dir == null)
            {
                i = i.Esq;
            }

            else if (i.Esq == null)
            {
                i = i.Dir;
            }

            else
            {
                i.Esq = MaiorEsq(i, i.Esq);
            }

            return i;
        }

        No MaiorEsq(No i, No j)
        {
            if (j.Dir == null)
            {
                i.Elemento = j.Elemento;
                j = j.Esq;
            }

            else
            {
                j.Dir = MaiorEsq(i, j.Dir);
            }

            return j;
        }

        public bool EhCompleta()
        {
            if (raiz == null) return true;

            Queue<No> fila = new Queue<No>();
            fila.Enqueue(raiz);

            bool encontrouFolha = false;

            while (fila.Count > 0)
            {
                No noAtual = fila.Dequeue();

                if (noAtual.Esq != null)
                {
                    if (encontrouFolha) return false;
                    fila.Enqueue(noAtual.Esq);
                }

                else
                {
                    encontrouFolha = true;
                }

                if (noAtual.Dir != null)
                {
                    if (encontrouFolha) return false;
                    fila.Enqueue(noAtual.Dir);
                }

                else
                {
                    encontrouFolha = true;
                }
            }

            return true;
        }
    }

    class No
    {
        private int elemento;
        private No esq;
        private No dir;

        public No(int elemento)
        {
            this.elemento = elemento;
            esq = null;
            dir = null;
        }

        public No(int elemento, No esq, No dir)
        {
            this.elemento = elemento;
            this.esq = esq;
            this.dir = dir;
        }

        public int Elemento
        {
            get { return elemento; }
            set { elemento = value; }
        }

        public No Esq
        {
            get { return esq; }
            set { esq = value; }
        }

        public No Dir
        {
            get { return dir; }
            set { dir = value; }
        }
    }
}