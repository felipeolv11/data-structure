using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio03
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> bolsas_ic = new Queue<int>();
            Queue<int> bolsas_mestrado = new Queue<int>();

            int aluno = 0;
            int ex_aluno = 0;
            int primeiro_fila = 0;

            int opcao = 0;

            while (opcao != 11)
            {
                Console.WriteLine("UNIVERSIDADE ACME");
                Console.WriteLine("=================");
                Console.WriteLine("1 - Inserir um aluno na fila de espera de bolsas de Iniciação Científica");
                Console.WriteLine("2 - Inserir um aluno na fila de espera de bolsas de Mestrado");
                Console.WriteLine("3 - Remover um aluno da fila de bolsas de Iniciação Científica");
                Console.WriteLine("4 - Remover um aluno da fila de bolsas de Mestrado");
                Console.WriteLine("5 - Mostrar fila de espera de bolsas de Iniciação Científica");
                Console.WriteLine("6 - Mostrar fila de espera de bolsas de Mestrado");
                Console.WriteLine("7 - Pesquisar aluno na fila de espera de bolsas de Iniciação Científica");
                Console.WriteLine("8 - Pesquisar aluno na fila de espera de bolsas de Mestrado");
                Console.WriteLine("9 - Mostrar qual o aluno que está no início da fila de espera de bolsas de Iniciação Científica");
                Console.WriteLine("10 - Mostrar qual o aluno que está no início da fila de espera de bolsas de Mestrado");
                Console.WriteLine("11- Encerrar o programa");
                opcao = int.Parse(Console.ReadLine());


                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Digite o codigo do aluno: ");
                        aluno = int.Parse(Console.ReadLine());

                        InserirAlunoFila(ref bolsas_ic, aluno);

                        Console.WriteLine("O aluno foi inserido na fila de espera de bolsas de Iniciação Científica.");

                        break;

                    case 2:
                        Console.WriteLine("Digite o codigo do aluno: ");
                        aluno = int.Parse(Console.ReadLine());

                        InserirAlunoFila(ref bolsas_mestrado, aluno);

                        Console.WriteLine("O aluno foi inserido na fila de espera de bolsas de Mestrado.");

                        break;

                    case 3:
                        aluno = RemoverAlunoFila(ref bolsas_ic);

                        Console.WriteLine("O aluno {0} foi removido da fila de espera de bolsas de Iniciação Científica.", aluno);

                        break;

                    case 4:
                        aluno = RemoverAlunoFila(ref bolsas_mestrado);

                        Console.WriteLine("O aluno {0} foi removido da fila de espera de bolsas de Mestrado.", aluno);

                        break;

                    case 5:
                        Console.WriteLine("Fila de espera de bolsas de Iniciação Científica:");

                        MostrarFila(ref bolsas_ic);

                        break;

                    case 6:
                        Console.WriteLine("Fila de espera de bolsas de Mestrado:");

                        MostrarFila(ref bolsas_mestrado);

                        break;

                    case 7:
                        Console.WriteLine("Digite o codigo do aluno: ");
                        aluno = int.Parse(Console.ReadLine());

                        if (PesquisarAluno(ref bolsas_ic, aluno))
                        {
                            Console.WriteLine("O aluno {0} está na fila de Iniciação Científica.", aluno);
                        }

                        else
                        {
                            Console.WriteLine("O aluno {0} não está na fila de Mestrado.", aluno);
                        }

                        break;

                    case 8:
                        Console.WriteLine("Digite o codigo do aluno: ");
                        aluno = int.Parse(Console.ReadLine());

                        if (PesquisarAluno(ref bolsas_mestrado, aluno))
                        {
                            Console.WriteLine("O aluno {0} está na fila de Iniciação Científica.", aluno);
                        }

                        else
                        {
                            Console.WriteLine("O aluno {0} não está na fila de Mestrado.", aluno);
                        }

                        break;

                    case 9:
                        aluno = PrimeiroDaFila(ref bolsas_ic);

                        Console.WriteLine("O aluno {0} é o primeiro da fila de Iniciação Científica.", aluno);

                        break;

                    case 10:
                        aluno = PrimeiroDaFila(ref bolsas_mestrado);

                        Console.WriteLine("O aluno {0} é o primeiro da fila de Mestrado.", aluno);

                        break;

                    case 11:
                        Console.WriteLine("FIM!");

                        break;

                    default:
                        Console.WriteLine("Opção inválida!");

                        break;
                }
            }

            Console.ReadLine();
        }

        static void InserirAlunoFila(ref Queue<int> q, int aln)
        {
            q.Enqueue(aln);
        }

        static int RemoverAlunoFila(ref Queue<int> q)
        {
            return q.Dequeue();
        }

        static void MostrarFila(ref Queue<int> q)
        {
            foreach (int hash in q)
            {
                Console.WriteLine("- " + hash);
            }
        }

        static bool PesquisarAluno(ref Queue<int> q, int aln)
        {
            return q.Contains(aln);
        }

        static int PrimeiroDaFila(ref Queue<int> q)
        {
            return q.Peek();
        }
    }
}
