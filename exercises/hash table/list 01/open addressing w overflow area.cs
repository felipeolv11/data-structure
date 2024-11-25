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
                            Console.WriteLine("Valor {0} removido com sucesso!", resp);
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
        private int tamReserva;
        private int numReserva;

        public int[] Array
        {
            get { return arr; }
            set { arr = value; }
        }

        public int TamTabela
        {
            get { return tamTabela; }
            set { tamTabela = value; }
        }

        public int TamReserva 
        {
            get { return tamReserva; }
            set { tamReserva = value; }
        }

        public HashTable(int tam)
        {
            tamReserva = 3;
            arr = new int[tam + tamReserva];
            tamTabela = tam;
            numReserva = 0;
        }

        public int Hash(int x)
        {
            return x % tamTabela;
        }

        public void Inserir(int x)
        {
            int i = Hash(x);

            if (x == 0)
            {
                throw new Exception("Erro!");
            }

            else if (arr[i] == 0)
            {
                arr[i] = x;
            }

            else if (numReserva < tamReserva)
            {
                arr[tamTabela + numReserva] = x;
                numReserva++;
            }

            else
            {
                throw new Exception("Erro!");
            }
        }

        public bool Pesquisar(int x)
        {
            int i = Hash(x);

            if (x == arr[i])
            {
                return true;
            }

            else
            {
                for (int j = 0; j < numReserva; j++)
                {
                    if (x == arr[tamTabela + numReserva])
                        return true;
                }
            }

            return false;
        }

        public int Remover(int x)
        {
            int i = Hash(x);
            int resp = -1;

            if (x == arr[i])
            {
                resp = arr[i];
                arr[i] = 0;

            }

            else
            {
                for (int j = 0; j < numReserva; j++)
                {
                    if (x == arr[tamTabela + numReserva])
                        resp = arr[tamTabela + numReserva];

                    arr[tamTabela + numReserva] = -1;
                }
            }

            return resp;
        }

        public void Mostrar()
        {
            Console.Write("[ ");
            for (int i = 0; i < tamTabela + tamReserva; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine("]");
        }
    }
}
