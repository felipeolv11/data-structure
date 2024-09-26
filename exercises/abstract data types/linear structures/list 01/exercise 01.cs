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
            Console.WriteLine("Informe o tamanho da lista: ");
            int tam = int.Parse(Console.ReadLine());

            Lista lista_de_numeros = new Lista(tam);

            int opcao = 0;

            while (opcao != 8)
            {
                Console.WriteLine("1 - Inserir um filme no final da lista");
                Console.WriteLine("2 - Inserir um filme em uma posição específica da lista");
                Console.WriteLine("3 - Remover um filme da lista");
                Console.WriteLine("4 - Remover um filme em uma posição específica da lista");
                Console.WriteLine("5 - Pesquisar se um filme consta na lista");
                Console.WriteLine("6 - Listar todos os filmes da lista");
                Console.WriteLine("7 - Inverter a ordem dos filmes presentes na lista");
                Console.WriteLine("8 - Encerrar o programa");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Digite o nome do filme: ");
                        string filme = Console.ReadLine();

                        lista_de_filmes.InserirFinal(filme);

                        Console.WriteLine("O filme '{0}' foi inserido", filme);
                        break;

                    case 2:
                        Console.WriteLine("Digite o nome do filme e a posição, nesta ordem: ");
                        filme = Console.ReadLine();
                        int pos = int.Parse(Console.ReadLine());

                        lista_de_filmes.Inserir(filme, pos);

                        Console.WriteLine("O filme '{0}' foi inserido na posição {1}", filme, pos);
                        break;

                    case 3:
                        Console.WriteLine("Digite o nome do filme: ");
                        filme = Console.ReadLine();

                        string filme_removido = lista_de_filmes.Remover(filme);

                        Console.WriteLine("O filme '{0}' foi removido", filme_removido);

                        break;

                    case 4:
                        Console.WriteLine("Digite a posição do filme: ");
                        pos = int.Parse(Console.ReadLine());

                        filme_removido = lista_de_filmes.RemoverNo(pos);

                        Console.WriteLine("O filme '{0}' foi removido da posição {1}", filme_removido, pos);
                        break;

                    case 5:
                        Console.WriteLine("Digite o nome do filme: ");
                        filme = Console.ReadLine();

                        if (lista_de_filmes.Pesquisar(filme))
                            Console.WriteLine("O filme está na lista");

                        else
                            Console.WriteLine("O filme não está na lista");

                        break;

                    case 6:
                        Console.WriteLine("Lista de Filmes:");

                        lista_de_filmes.Mostrar();
                        break;

                    case 7:
                        lista_de_filmes.Inverter();

                        Console.WriteLine("Ordem de filmes foi invertida");
                        break;

                    case 8:
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

    class Lista
    {
        private string[] array;
        private int n;

        public Lista()
        {
            inicializar(10);
        }

        public Lista(int tamanho)
        {
            inicializar(tamanho);
        }

        private void inicializar(int tamanho)
        {
            this.array = new string[tamanho];
            this.n = 0;
        }

        public void InserirFinal(string x)
        {
            if (n >= array.Length)
                throw new Exception("Erro!");

            array[n] = x;
            n++;
        }

        public void Inserir(string x, int pos)
        {
            if (n >= array.Length || pos < 0 || pos > n)
                throw new Exception("Erro!");

            for (int i = n; i > pos; i--)
            {
                array[i] = array[i - 1];
            }

            array[pos] = x;
            n++;
        }

        public string Remover(string x)
        {
            int pos = 0;

            for (int i = n; i > 0; i--)
            {
                if (array[i] == x)
                {
                    pos = i;
                }
            }

            if (n == 0 || pos < 0 || pos >= n)
                throw new Exception("Erro!");


            string resp = array[pos];
            n--;

            for (int i = pos; i < n; i++)
            {
                array[i] = array[i + 1];
            }

            return resp;
        }

        public string RemoverNo(int pos)
        {
            if (n == 0 || pos < 0 || pos > n)
                throw new Exception("Erro!");

            string resp = array[pos];
            n--;

            for (int i = pos; i < n; i++)
            {
                array[i] = array[i + 1];
            }

            return resp;
        }

        public bool Pesquisar(string x)
        {
            for (int i = 0; i < n; i++)
            {
                if (array[i] == x)
                {
                    return true;
                }
            }

            return false;
        }

        public void Mostrar()
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(" - " + array[i]);
            }
        }

        public void Inverter()
        {
            if (n == 0)
                throw new Exception("Erro!");

            string temp = null;

            int fim = n - 1;

            for (int i = 0; i < fim; i++)
            {
                temp = array[i];
                array[i] = array[fim];
                array[fim] = temp;

                fim--;
            }
        }
    }
}
