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
            List<string> lista_de_filmes = new List<string>();

            int opcao = 0;

            while (opcao != 9)
            {
                Console.WriteLine("LISTA DE FILMES");
                Console.WriteLine("===============");
                Console.WriteLine("1 - Inserir um filme no final da lista");
                Console.WriteLine("2 - Inserir um filme em uma posição específica da lista");
                Console.WriteLine("3 - Remover um filme da lista");
                Console.WriteLine("4 - Remover um filme em uma posição específica da lista");
                Console.WriteLine("5 - Pesquisar se um filme consta na lista");
                Console.WriteLine("6 - Listar todos os filmes da lista");
                Console.WriteLine("7 - Inverter a ordem dos filmes presentes na lista");
                Console.WriteLine("8 - Ordenar a lista de filmes");
                Console.WriteLine("9 - Encerrar o programa");
                opcao = int.Parse(Console.ReadLine());


                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Digite o nome do filme: ");
                        string filme = Console.ReadLine();

                        InserirFilmeFinal(ref lista_de_filmes, filme);

                        Console.WriteLine("O filme '{0}' foi adicionado.", filme);

                        break;

                    case 2:
                        Console.WriteLine("Digite o nome do filme e a posicao, nesta ordem: ");
                        filme = Console.ReadLine();
                        int posicao = int.Parse(Console.ReadLine());

                        InserirFilmePosicao(ref lista_de_filmes, filme, posicao);

                        Console.WriteLine("O filme '{0}' foi adicionado na posicao {1}.", filme, posicao);

                        break;

                    case 3:
                        Console.WriteLine("Qual filme deseja remover: ");
                        filme = Console.ReadLine();

                        RemoverFilme(ref lista_de_filmes, filme);

                        Console.WriteLine("O filme '{0}' foi removido.", filme);

                        break;

                    case 4:
                        Console.WriteLine("Qual filme deseja remover e a posicao, nesta ordem: ");
                        filme = Console.ReadLine();
                        posicao = int.Parse(Console.ReadLine());

                        RemoverFilmePosicao(ref lista_de_filmes, posicao);

                        Console.WriteLine("O filme '{0}' foi removido na posicao {1}.", filme, posicao);

                        break;

                    case 5:
                        Console.WriteLine("Digite o nome do filme: ");
                        filme = Console.ReadLine();

                        if (FilmeEstaNaLista(ref lista_de_filmes, filme))
                        {
                            Console.WriteLine("O livro {0} esta na lista.", filme);
                        }

                        else
                        {
                            Console.WriteLine("O livro {0} nao esta na lista.", filme);
                        }

                        break;

                    case 6:
                        Console.WriteLine("Lista de filmes:");

                        ListarFilmes(ref lista_de_filmes);

                        break;

                    case 7:
                        ReverterOrdemFilmes(ref lista_de_filmes);

                        Console.WriteLine("A lista foi invertida.");

                        break;

                    case 8:
                        OrdernarOrdemFilmes(ref lista_de_filmes);

                        Console.WriteLine("A lista foi ordenada.");

                        break;

                    case 9:
                        Console.WriteLine("FIM!");

                        break;

                    default:
                        Console.WriteLine("Opcao invalida!");

                        break;
                }
            }

            Console.ReadLine();
        }

        static void InserirFilmeFinal(ref List<string> lista, string filme)
        {
            lista.Add(filme);
        }

        static void InserirFilmePosicao(ref List<string> lista, string filme, int posicao)
        {
            lista.Insert(posicao, filme);
        }

        static void RemoverFilme(ref List<string> lista, string filme)
        {
            lista.Remove(filme);
        }

        static void RemoverFilmePosicao(ref List<string> lista, int posicao)
        {
            lista.RemoveAt(posicao);
        }

        static bool FilmeEstaNaLista(ref List<string> lista, string filme)
        {
            return lista.Contains(filme);
        }

        static void ListarFilmes(ref List<string> lista)
        {
            foreach (string filme in lista)
            {
                Console.WriteLine(filme);
            }
        }

        static void ReverterOrdemFilmes(ref List<string> lista)
        {
            lista.Reverse();
        }

        static void OrdernarOrdemFilmes(ref List<string> lista)
        {
            lista.Sort();
        }
    }
}
