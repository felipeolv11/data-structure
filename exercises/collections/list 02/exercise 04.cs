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
            Queue<string> fila_de_clientes = new Queue<string>();
            
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

                        AdicionarCliente(ref fila_de_clientes, nome);

                        Console.WriteLine("Cliente adicionado a fila");

                        break;

                    case 2:
                        nome = AtenderCliente(ref fila_de_clientes);

                        if (nome != "")
                        {
                            Console.WriteLine("O cliente '{0}' foi atendido", nome);
                        }
                        
                        else
                        {
                            Console.WriteLine("Não há ninguém a ser atendido");
                        }

                        break;

                    case 3:
                        if (fila_de_clientes.Count > 0)
                        {
                            Console.WriteLine("Quantidade de clientes na fila: {0}", NumeroClientes(ref fila_de_clientes));
                        }
                        
                        else
                        {
                            Console.WriteLine("A fila ainda está vazia");
                        }

                        break;

                    case 4:
                        nome = ExibirProximo(ref fila_de_clientes);

                        if (nome != "")
                        {
                            Console.WriteLine("O próximo cliente a ser antendido: '{0}'", nome);
                        }

                        else
                        {
                            Console.WriteLine("Não há próximo cliente a ser atendido");
                        }
                        
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

        static void AdicionarCliente(ref Queue<string> fila_de_clientes, string nome)
        {
            fila_de_clientes.Enqueue(nome);
        }

        static string AtenderCliente(ref Queue<string> fila_de_clientes)
        {
            if (fila_de_clientes.Count > 0)
            {
                return fila_de_clientes.Dequeue();
            }

            return "";
        }

        static int NumeroClientes(ref Queue<string> fila_de_clientes)
        {
            return fila_de_clientes.Count;
        }

        static string ExibirProximo(ref Queue<string> fila_de_clientes)
        {
            if (fila_de_clientes.Count > 0)
            {
                return fila_de_clientes.Peek();
            }

            return "";
        }
    }
}
