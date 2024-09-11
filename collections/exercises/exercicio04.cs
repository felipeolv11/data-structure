using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq.Expressions;

namespace exericico04
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Digite o caminho do arquivo: ");
                string caminho_do_arquivo = Console.ReadLine();

                int opcao = 0;

                while (opcao != 4)
                {
                    Console.WriteLine("Escolha uma das opções abaixo:");
                    Console.WriteLine("1 - Verificar se uma determinada palavra consta no dicionário;");
                    Console.WriteLine("2 - Quantas palavras distintas constam no dicionário;");
                    Console.WriteLine("3 - Imprimir todas as palavras e suas respectivas frequências de ocorrências.");
                    Console.WriteLine("4 - Encerrrar o programa.");
                    opcao = int.Parse(Console.ReadLine());

                    switch (opcao)
                    {
                        case 1:
                            Console.WriteLine("Qual a palavra? ");
                            string palavra = Console.ReadLine();

                            if (VerificarPalavra(caminho_do_arquivo, palavra))
                            {
                                Console.WriteLine("A palavra '{0}' está no dicionário", palavra);
                            }

                            else
                            {
                                Console.WriteLine("A palavra '{0}' não está no dicionário", palavra);
                            }

                            break;

                        case 2:
                            int count = PalavrasDistintas(caminho_do_arquivo);

                            Console.WriteLine("Existem {0} palavras distintas no dicionário.", count);

                            break;

                        case 3:
                            ImprimirTodasPalavras(caminho_do_arquivo);

                            break;

                        case 4:
                            Console.WriteLine("FIM!");

                            break;

                        default:
                            Console.WriteLine("Opção Inválida!");

                            break;
                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Mensagem de Erro: " + e.Message);
            }

            Console.ReadLine();
        }

        static bool VerificarPalavra(string caminho_do_arquivo, string palavra_pesquisa)
        {
            string texto = File.ReadAllText(caminho_do_arquivo);

            string[] palavras = texto.Split(' ', '.', ',', ';', ':', '!', '?', '"');

            Dictionary<string, int> contagem = new Dictionary<string, int>();
            
            foreach (string palavra in palavras)
            {
                string palavraMinuscula = palavra.ToLower();

                if (contagem.ContainsKey(palavraMinuscula))
                {
                    contagem[palavraMinuscula]++;
                }

                else
                {
                    contagem[palavraMinuscula] = 1;
                }
            }

            return contagem.ContainsKey(palavra_pesquisa);
        }

        static int PalavrasDistintas(string caminho_do_arquivo)
        {
            string texto = File.ReadAllText(caminho_do_arquivo);

            string[] palavras = texto.Split(' ', '.', ',', ';', ':', '!', '?', '"');

            Dictionary<string, int> contagem = new Dictionary<string, int>();

            int count = 0;

            foreach (string palavra in palavras)
            {
                string palavraMinuscula = palavra.ToLower();

                if (!contagem.ContainsKey(palavraMinuscula))
                {
                    contagem[palavraMinuscula] = 1;
                    count++;
                }
            }

            return count;
        }

        static void ImprimirTodasPalavras(string caminho_do_arquivo)
        {
            string texto = File.ReadAllText(caminho_do_arquivo);

            string[] palavras = texto.Split(' ', '.', ',', ';', ':', '!', '?', '"');

            Dictionary<string, int> contagem = new Dictionary<string, int>();

            foreach (string palavra in palavras)
            {
                string palavraMinuscula = palavra.ToLower();

                if (contagem.ContainsKey(palavraMinuscula))
                {
                    contagem[palavraMinuscula]++;
                }

                else
                {
                    contagem[palavraMinuscula] = 1;
                }
            }

            foreach (KeyValuePair<string, int> entrada in contagem)
            {
                Console.WriteLine("Palavra: {0} | Count: {1}", entrada.Key, entrada.Value);
            }
        }
    }
}
