using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio06
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Informe o tamanho da fila: ");
            int tam = int.Parse(Console.ReadLine());

            Fila fila_de_atendimento = new Fila();

            int opcao = 0;

            while (opcao != 5)
            {
                Console.WriteLine("1 - Adicionar cliente à fila");
                Console.WriteLine("2 - Atender um cliente");
                Console.WriteLine("3 - Exibir número de clientes na fila");
                Console.WriteLine("4 - Exibir próximo cliente a ser atendido");
                Console.WriteLine("5 - Encerrar o programa");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Digite o nome do cliente: ");
                        string nome = Console.ReadLine();

                        fila_de_atendimento.Inserir(nome);

                        Console.WriteLine("Cliente '{0}' adicionado a fila", nome);
                        break;

                    case 2:
                        nome = fila_de_atendimento.Remover();

                        Console.WriteLine("O cliente '{0}' foi atendido", nome);
                        break;

                    case 3:
                        Console.WriteLine("Quantidade de clientes na fila: {0}", fila_de_atendimento.Count());
                        break;

                    case 4:
                        nome = fila_de_atendimento.Peek();

                        Console.WriteLine("O próximo cliente a ser antendido: '{0}'", nome);
                        break;

                    case 5:
                        Console.WriteLine("FIM!");

                        break;

                    default:
                        Console.WriteLine("Opção inválida!");

                        break;
                }
            }

            Console.ReadLine();
        }
    }

    class Fila
    {
        private string[] array;
        private int primeiro, ultimo;

        public Fila()
        {
            inicializar(10);
        }

        public Fila(int tamanho)
        {
            inicializar(tamanho);
        }

        private void inicializar(int tamanho)
        {
            this.array = new string[tamanho];
            primeiro = ultimo = 0;
        }

        public void Inserir(string x)
        {
            if (((ultimo + 1) % array.Length) == primeiro)
                throw new Exception("Erro!");

            array[ultimo] = x;
            ultimo = (ultimo + 1) % array.Length;
        }

        public string Remover()
        {
            if (primeiro == ultimo)
                throw new Exception("Erro!");

            string resp = array[primeiro];
            primeiro = (primeiro + 1) % array.Length;

            return resp;
        }

        public void Mostrar()
        {
            int i = primeiro;

            Console.Write("[ ");

            while (i != ultimo)
            {
                Console.Write(array[i] + " ");
                i = (i + 1) % array.Length;
            }

            Console.WriteLine("]");
        }

        public bool Pesquisar(string x)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == x)
                {
                    return true;
                }
            }

            return false;
        }

        public string Peek()
        {
            if (primeiro == ultimo)
                throw new Exception("A fila está vazia!");

            return array[primeiro];
        }

        public int Count()
        {
            return (ultimo - primeiro) % array.Length;
        }
    }
}