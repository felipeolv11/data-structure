using System;
using System.Collections;
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
            Console.WriteLine("Qual o tamanho da tabela?");
            int tam = int.Parse(Console.ReadLine());

            HashTable tabela_hash = new HashTable(tam);

            int opcao = 0;

            while (opcao != 4)
            {
                Console.Clear();

                Console.WriteLine("Escolha uma das opções abaixo:");
                Console.WriteLine("1 - Inserir");
                Console.WriteLine("2 - Pesquisar");
                Console.WriteLine("3 - Remover");
                Console.WriteLine("4 - Sair");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Digite o valor a ser inserido:");
                        int num = int.Parse(Console.ReadLine());

                        tabela_hash.Inserir(num);
                        Console.WriteLine("Valor inserido!");

                        tabela_hash.Mostrar();

                        break;

                    case 2:
                        Console.WriteLine("Digite o valor que deseja pesquisar:");
                        num = int.Parse(Console.ReadLine());

                        if (tabela_hash.Pesquisar(num))
                        {
                            Console.WriteLine($"O Valor foi encontrado!");
                        }

                        else
                        {
                            Console.WriteLine("Valor não encontrado!");
                        }
                            
                        tabela_hash.Mostrar();

                        break;

                    case 3:
                        Console.WriteLine("Digite o valor a ser removido:");
                        num = int.Parse(Console.ReadLine());

                        tabela_hash.Remover(num);
                        tabela_hash.Mostrar();

                        break;

                    case 4:
                        Console.WriteLine("FIM!!!");

                        break;

                    default:
                        Console.WriteLine("Opção inválida!");

                        break;
                }

                Console.ReadLine();
            }
        }
    }

    class HashTable
    {
        private Lista[] arr;
        private int tamTabela;

        public HashTable(int tam)
        {
            tamTabela = tam;
            arr = new Lista[tam];
            for (int i = 0; i < arr.Length; i++)
                arr[i] = new Lista();
        }

        private int Hash(int x)
        {
            return x % tamTabela;
        }

        public void Inserir(int x)
        {
            arr[Hash(x)].InserirFim(x);
        }

        public bool Pesquisar(int x)
        {
            return arr[Hash(x)].Pesquisar(x);
        }

        public void Remover(int x)
        {
            if (arr[Hash(x)].Remover(x) != null)
            {
                Console.WriteLine($"Valor removido com sucesso!");
            }

            else
            {
                Console.WriteLine("Valor não encontrado!");
            }     
        }

        public void Mostrar()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"Posição {i}: ");
                arr[i].Mostrar();
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

    class Lista
    {
        private Celula primeiro;
        private Celula ultimo;

        public Lista()
        {
            primeiro = new Celula();
            ultimo = primeiro;
        }

        public void InserirFim(int x)
        {
            ultimo.Prox = new Celula(x);
            ultimo = ultimo.Prox;
        }

        public Celula Remover(int x)
        {
            Celula anterior = primeiro, atual = primeiro.Prox;

            while (atual != null)
            {
                if (atual.Elemento == x)
                {
                    anterior.Prox = atual.Prox;
                    if (atual == ultimo)
                        ultimo = anterior;

                    atual.Prox = null;
                    return atual;
                }

                anterior = atual;
                atual = atual.Prox;
            }

            return null;
        }

        public bool Pesquisar(int x)
        {
            for (Celula i = primeiro.Prox; i != null; i = i.Prox)
            {
                if (i.Elemento == x)
                    return true;
            }

            return false;
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