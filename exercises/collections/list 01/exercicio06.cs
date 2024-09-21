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
            LinkedList<string> lista_de_filmes = new LinkedList<string>();

            int opcao = 0;

            while (opcao != 7)
            {
                Console.WriteLine("LISTA DE FILMES");
                Console.WriteLine("===============");
                Console.WriteLine("1 - Inserir um filme no final da lista");
                Console.WriteLine("2 - Inserir um filme depois de uma posição específica da lista");
                Console.WriteLine("3 - Inserir um filme antes de uma posição específica da lista");
                Console.WriteLine("4 - Remover o filme que estiver no final da lista");
                Console.WriteLine("5 - Pesquisar se um filme consta na lista");
                Console.WriteLine("6 - Listar todos os filmes da lista");
                Console.WriteLine("7 - Encerrar o programa");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Digite o nome do filme: ");
                        string filme = Console.ReadLine();

                        AddFilmeFinal(ref lista_de_filmes, filme);

                        Console.WriteLine("O filme '{0}' foi adicionado ao final da lista", filme);

                        break;

                    case 2:
                        Console.WriteLine("Digite o nome do filme e do filme na posição de referência, nesta ordem: ");
                        filme = Console.ReadLine();
                        string referencia = Console.ReadLine();

                        AddFilmeDepois(ref lista_de_filmes, filme, referencia);

                        break;

                    case 3:
                        Console.WriteLine("Digite o nome do filme e do filme na posição de referência, nesta ordem: ");
                        filme = Console.ReadLine();
                        referencia = Console.ReadLine();

                        AddFilmeAntes(ref lista_de_filmes, filme, referencia);

                        break;

                    case 4:
                        RemoverFilmeFinal(ref lista_de_filmes);

                        break;

                    case 5:
                        Console.WriteLine("Digite o nome do filme que deseja procurar: ");
                        filme = Console.ReadLine();

                        if (PesquisarFilme(ref lista_de_filmes, filme))
                        {
                            Console.WriteLine("O filme '{0}' está na lista", filme);
                        }

                        else
                        {
                            Console.WriteLine("O filme '{0}' não está na lista", filme);
                        }

                        break;

                    case 6:
                        Console.WriteLine("Lista:");

                        ListaFilmes(ref lista_de_filmes);

                        break;

                    case 7:
                        Console.WriteLine("FIM!");

                        break;

                    default:
                        Console.WriteLine("Opção Inválida!");

                        break;
                }
            }

            Console.ReadLine();
        }

        static void AddFilmeFinal(ref LinkedList<string> lista_de_filmes, string filme)
        {
            lista_de_filmes.AddLast(filme);
        }

        static void AddFilmeDepois(ref LinkedList<string> lista_de_filmes, string filme, string referencia)
        {
            LinkedListNode<string> noReferencia = lista_de_filmes.Find(referencia);

            if (noReferencia != null)
            {
                lista_de_filmes.AddAfter(noReferencia, filme);

                Console.WriteLine("O filme '{0}' foi adicionado a lista após o '{1}'", filme, referencia);
            }

            else
            {
                Console.WriteLine("Filme passado como referência não encontrado");
            }
        }

        static void AddFilmeAntes(ref LinkedList<string> lista_de_filmes, string filme, string referencia)
        {
            LinkedListNode<string> noReferencia = lista_de_filmes.Find(referencia);

            if (noReferencia != null)
            {
                lista_de_filmes.AddBefore(noReferencia, filme);

                Console.WriteLine("O filme '{0}' foi adicionado a lista antes do '{1}'", filme, referencia);
            }

            else
            {
                Console.WriteLine("Filme passado como referência não encontrado");
            }
        }

        static void RemoverFilmeFinal(ref LinkedList<string> lista_de_filmes)
        {
            if (lista_de_filmes != null)
            {
                lista_de_filmes.RemoveLast();

                Console.WriteLine("O filme do final da lista foi removido.");
            }

            else
            {
                Console.WriteLine("A lista está vazia");
            }
        }

        static bool PesquisarFilme(ref LinkedList<string> lista_de_filmes, string filme)
        {
            if (lista_de_filmes.Contains(filme))
            {
                return true;
            }

            return false;
        }

        static void ListaFilmes(ref LinkedList<string> lista_de_filmes)
        {
            foreach (string filme in lista_de_filmes)
            {
                Console.WriteLine("- " + filme);
            }

        }
    }
}
