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
            SortedList<string, List<string>> dicionario = new SortedList<string, List<string>>();

            int opcao = 0;

            while (opcao != 4)
            {
                Console.WriteLine("1 - Adicionar nova palavra e seus sinônimos");
                Console.WriteLine("2 - Pesquisar sinônimos de uma palavra específica");
                Console.WriteLine("3 - Exibir dicionário em ordem alfabética");
                Console.WriteLine("4 - Encerra o programa");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Qual palavra deseja adicionar? ");
                        string palavra = Console.ReadLine();

                        AdicionarPalavraESinonimo(ref dicionario, palavra);

                        break;

                    case 2:
                        Console.WriteLine("Qual palavra deseja procurar os sinônimos? ");
                        palavra = Console.ReadLine();

                        PesquisarSinonimos(ref dicionario, palavra);

                        break;

                    case 3:
                        ExibirDicionario(ref dicionario);

                        break;

                    case 4:
                        Console.WriteLine("FIM!");

                        break;

                    default:
                        Console.WriteLine("Opção inválida!");

                        break;
                }
            }

            Console.ReadLine();
        }

        static void AdicionarPalavraESinonimo(ref SortedList<string, List<string>> dicionario, string palavra)
        {
            Console.WriteLine("Quantos sinônimos irá adicionar?");
            int qtd = int.Parse(Console.ReadLine());

            string sinonimo;

            if (!dicionario.ContainsKey(palavra))
            {
                dicionario[palavra] = new List<string>();
            }

            for (int i = 0; i < qtd; i++)
            {
                Console.WriteLine($"Digite o sinônimo n{i + 1}:");
                sinonimo = Console.ReadLine();

                if (!dicionario[palavra].Contains(sinonimo))
                {
                    dicionario[palavra].Add(sinonimo);

                    Console.WriteLine("Sinônimo adicionado.");
                }

                else
                {
                    Console.WriteLine("Este sinônimo já está adicionado à lista");
                }
            }
        }

        static void PesquisarSinonimos(ref SortedList<string, List<string>> dicionario, string palavra)
        {
            if (dicionario.ContainsKey(palavra))
            {
                Console.WriteLine("Sinônimos da palavra '{0}':", palavra);

                foreach (string sinonimo in dicionario[palavra])
                {
                    Console.WriteLine("- {0}", sinonimo);
                }
            }

            else
            {
                Console.WriteLine("Esta palavra não está no dicionário");
            }
        }

        static void ExibirDicionario(ref SortedList<string, List<string>> dicionario)
        {
            if (dicionario.Count > 0)
            {
                Console.WriteLine("Dicionário em ordem alfabetica:");

                foreach(string palavra in dicionario.Keys)
                {
                    Console.WriteLine("-> {0}", palavra);
                }
            }

            else
            {
                Console.WriteLine("Dicionário ainda está vazio");
            }
        }
    }
}
