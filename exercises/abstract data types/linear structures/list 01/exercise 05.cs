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
            Console.WriteLine("Informe o tamanho da lista: ");
            int tam = int.Parse(Console.ReadLine());

            Fila ic = new Fila(tam);
            Fila mestrado = new Fila(tam);

            int opcao = 0;
            int aluno = 0;

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

                        ic.Inserir(aluno);

                        Console.WriteLine("O aluno '{0}' foi inserido na fila de espera de bolsas de Iniciação Científica.", aluno);

                        break;

                    case 2:
                        Console.WriteLine("Digite o codigo do aluno: ");
                        aluno = int.Parse(Console.ReadLine());

                        mestrado.Inserir(aluno);

                        Console.WriteLine("O aluno '{0}' foi inserido na fila de espera de bolsas de Mestrado.", aluno);

                        break;

                    case 3:
                        aluno = ic.Remover();

                        Console.WriteLine("O aluno {0} foi removido da fila de espera de bolsas de Iniciação Científica.", aluno);

                        break;

                    case 4:
                        aluno = mestrado.Remover();

                        Console.WriteLine("O aluno {0} foi removido da fila de espera de bolsas de Mestrado.", aluno);

                        break;

                    case 5:
                        Console.WriteLine("Fila de espera de bolsas de Iniciação Científica:");

                       ic.Mostrar();

                        break;

                    case 6:
                        Console.WriteLine("Fila de espera de bolsas de Mestrado:");

                        mestrado.Mostrar();

                        break;

                    case 7:
                        Console.WriteLine("Digite o codigo do aluno: ");
                        aluno = int.Parse(Console.ReadLine());

                        if (ic.Pesquisar(aluno))
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

                        if (mestrado.Pesquisar(aluno))
                        {
                            Console.WriteLine("O aluno {0} está na fila de Iniciação Científica.", aluno);
                        }

                        else
                        {
                            Console.WriteLine("O aluno {0} não está na fila de Mestrado.", aluno);
                        }

                        break;

                    case 9:
                        aluno = ic.Peek();

                        Console.WriteLine("O aluno {0} é o primeiro da fila de Iniciação Científica.", aluno);

                        break;

                    case 10:
                        aluno = mestrado.Peek();

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
    }

    class Fila
    {
        private int[] array;
        private int primeiro, ultimo;

        public Fila()
        {
            inicializar(10);
        }

        public Fila (int tamanho)
        {
            inicializar(tamanho);
        }

        private void inicializar (int tamanho)
        {
            this.array = new int[tamanho];
            primeiro = ultimo = 0;
        }

        public void Inserir(int x)
        {
            if (((ultimo + 1) % array.Length) == primeiro)
                throw new Exception("Erro!");

            array[ultimo] = x;
            ultimo = (ultimo + 1) % array.Length;
        }

        public int Remover()
        {
            if (primeiro == ultimo)
                throw new Exception("Erro!");

            int resp = array[primeiro];
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

        public bool Pesquisar (int x)
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

        public int Peek()
        {
            if (primeiro == ultimo)
                throw new Exception("A fila está vazia!");

            return array[primeiro];
        }
    }
}
