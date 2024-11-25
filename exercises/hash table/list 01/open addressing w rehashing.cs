using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Qual o tamanho da tabela? ");
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
                            Console.WriteLine("O Valor foi encontrado!");
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

                        int resp = tabela_hash.Remover(num);

                        if (resp != -1)
                        {
                            Console.WriteLine("Valor foi removido com sucesso!", resp);
                        }

                        else
                        {
                            Console.WriteLine("Valor não encontrado!");
                        }

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
        private int[] arr;
        private int tamTabela;

        public int[] Arr
        {
            get { return arr; }
            set { arr = value; }
        }

        public int TamTabela
        {
            get { return tamTabela; }
            set { tamTabela = value; }
        }

        public HashTable(int tam)
        {
            arr = new int[tam];
            tamTabela = tam;
        }

        public int Hash(int x)
        {
            return x % tamTabela;
        }

        public int Rehash(int x)
        {
            return ++x % tamTabela;
        }

        public void Inserir(int x)
        {
            int i = Hash(x);
            int inicio = i;

            if (x == 0)
            {
                throw new Exception("Erro!");
            }

            while (arr[i] != 0)
            {
                i = Rehash(i);

                if (i == inicio)
                {
                    throw new Exception("Erro");
                }
            }

            arr[i] = x;
        }

        public bool Pesquisar(int x)
        {
            int i = Hash(x);
            int inicio = i;

            while (arr[i] != 0)
            {
                if (arr[i] == x)
                {
                    return true;
                }

                i = Rehash(i);

                if (i == inicio)
                {
                    break;
                }
            }

            return false;
        }

        public int Remover(int x)
        {
            int i = Hash(x);
            int inicio = i;

            while (arr[i] != 0)
            {
                if (arr[i] == x)
                {
                    int resp = arr[i];
                    arr[i] = 0;
                    return resp;
                }

                i = Rehash(i);

                if (i == inicio)
                {
                    break;
                }
            }

            return -1;
        }

        public void Mostrar()
        {
            Console.Write("[ ");
            for (int i = 0; i < tamTabela; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine("]");
        }
    }
}
