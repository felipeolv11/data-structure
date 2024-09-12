using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio05
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedList<int, string> ranking_de_jogadores = new SortedList<int, string>();

            int opcao = 0;

            while (opcao != 5)
            {
                Console.WriteLine("RANKING");
                Console.WriteLine("========");
                Console.WriteLine("1 - Adicionar um novo jogador e sua pontuação;");
                Console.WriteLine("2 - Verificar a pontuação de um jogador em específico;");
                Console.WriteLine("3 - Remover um jogador, bem como sua pontuação;");
                Console.WriteLine("4 - Exibir o ranking de pontuação de forma crescente;");
                Console.WriteLine("5 - Encerrar o programa.");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Digite o nome e o rank do jogador, nesta ordem: ");
                        string jogador = Console.ReadLine();
                        int rank = int.Parse(Console.ReadLine());

                        AddJogador(ref ranking_de_jogadores, rank, jogador);

                        break;

                    case 2:
                        Console.WriteLine("Digite o nome e o rank do jogador, nesta ordem: ");
                        jogador = Console.ReadLine();
                        rank = int.Parse(Console.ReadLine());

                        if (VerificarRank(ref ranking_de_jogadores, rank, jogador))
                        {
                            Console.WriteLine("O jogador '{0}' possui o rank {1}.", jogador, rank);
                        }

                        else
                        {
                            Console.WriteLine("O jogador '{0}' não possui o rank {1}, ou não está no ranking.", jogador, rank);
                        }

                        break;

                    case 3:
                        Console.WriteLine("Digite o nome e o rank do jogador, nesta ordem: ");
                        jogador = Console.ReadLine();
                        rank = int.Parse(Console.ReadLine());

                        RemoverJogador(ref ranking_de_jogadores, rank, jogador);

                        break;

                    case 4:
                        Console.WriteLine("Ranking:");

                        RankingPts(ref ranking_de_jogadores);

                        break;

                    case 5:
                        Console.WriteLine("FIM!");

                        break;

                    default:
                        Console.WriteLine("Opção Inválida!");

                        break;
                }
            }

            Console.ReadLine();
        }

        static void AddJogador(ref SortedList<int, string> ranking, int rank, string jogador)
        {
            if (ranking.ContainsKey(rank))
            {
                Console.WriteLine("Já existe um jogador com este rank.");
            }

            else
            {
                ranking.Add(rank, jogador);

                Console.WriteLine("O jogador '{0}' foi adicionado ao rank {1}.", jogador, rank);
            }
        }

        static bool VerificarRank(ref SortedList<int, string> ranking, int rank, string jogador)
        {
            if (ranking.ContainsKey(rank))
            {
                if (ranking[rank] == jogador)
                    return true;
            }

            return false;
        }

        static void RemoverJogador(ref SortedList<int, string> ranking, int rank, string jogador)
        {
            if (ranking.ContainsKey(rank))
            {
                if (ranking[rank] == jogador)
                    ranking.Remove(rank);

                Console.WriteLine("Jogador '{0}' foi removido do ranking.", jogador);
            }

            else
            {
                Console.WriteLine("Jogador '{0}' não encontrado.", jogador);
            }
        }

        static void RankingPts(ref SortedList<int, string> ranking)
        {
            foreach (KeyValuePair<int, string> jogador in ranking)
            {
                Console.WriteLine("- " + jogador.Value + " | Rank: " + jogador.Key);
            }
        }
    }
}
