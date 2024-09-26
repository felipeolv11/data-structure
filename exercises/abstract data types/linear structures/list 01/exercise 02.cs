using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace exercicio02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Informe o tamanho da lista: ");
            int tam = int.Parse(Console.ReadLine());

            Lista lista_de_numeros = new Lista(tam);

            int opcao = 0;

            while (opcao != 9)
            {
                Console.WriteLine("1 - Inserir um número na lista");
                Console.WriteLine("2 - Verificar se um número está na lista");
                Console.WriteLine("3 - Exibir a soma de todos os números na lista");
                Console.WriteLine("4 - Exibir o maior número na lista");
                Console.WriteLine("5 - Exibir o menor número na lista");
                Console.WriteLine("6 - Remover todos os números pares da lista");
                Console.WriteLine("7 - Exibir os números na lista");
                Console.WriteLine("8 - Inverter os elementos da lista");
                Console.WriteLine("9 - Encerrar o programa");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Digite o número: ");
                        int x = int.Parse(Console.ReadLine());

                        lista_de_numeros.InserirFim(x);

                        Console.WriteLine("O numero '{0}' foi inserido na lista", x);
                        break;

                    case 2:
                        Console.WriteLine("Digite o número: ");
                        x = int.Parse(Console.ReadLine());

                        if (lista_de_numeros.Verificar(x))
                            Console.WriteLine("O número está na lista");

                        else
                            Console.WriteLine("O número não está na lista");

                        break;

                    case 3:
                        int qtd = lista_de_numeros.Soma();

                        Console.WriteLine("Soma total: " + qtd);
                        break;

                    case 4:
                        int maior = lista_de_numeros.ExibirMaior();

                        Console.WriteLine("Maior: " + maior);
                        break;

                    case 5:
                        int menor = lista_de_numeros.ExibirMenor();

                        Console.WriteLine("Maior: " + menor);
                        break;

                    case 6:
                        lista_de_numeros.RemoverPares();

                        Console.WriteLine("Todos os números pares foram removidos");
                        break;

                    case 7:
                        Console.WriteLine("Lista de Números:");

                        lista_de_numeros.Mostrar();
                        break;

                    case 8:
                        lista_de_numeros.Inverter();

                        Console.WriteLine("A ordem da lista foi invertida");
                        break;

                    case 9:
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
        private int[] array;
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
            this.array = new int[tamanho];
            this.n = 0;
        }

        public void InserirFim(int x)
        {
            if (n >= array.Length)
                throw new Exception("Erro!");
            
            array[n] = x;
            n++;
        }

        public bool Verificar(int x)
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

        public int Soma()
        {
            if (n == 0)
                throw new Exception("Erro!");

            int soma = 0;

            for (int i = 0; i < n; i++)
            {
                soma += array[i];
            }

            return soma;
        }

        public int ExibirMaior()
        {
            if (n == 0)
                throw new Exception("Erro!");

            int maior = array[0];

            for (int i = 1; i < n; ++i)
            {
                if (array[i] > maior)
                {
                    maior = array[i];
                }
            }

            return maior;
        }

        public int ExibirMenor()
        {
            if (n == 0)
                throw new Exception("Erro!");

            int menor = array[0];

            for (int i = 1; i < n; ++i)
            {
                if (array[i] < menor)
                {
                    menor = array[i];
                }
            }

            return menor;
        }
        public int RemoverNo(int pos)
        {
            if (n == 0 || pos < 0 || pos > n)
                throw new Exception("Erro!");

            int resp = array[pos];
            n--;

            for (int i = pos; i < n; i++)
            {
                array[i] = array[i + 1];
            }

            return resp;
        }

        public void RemoverPares()
        {
            if (n == 0)
                throw new Exception("Erro!");

            for (int i = 0; i < n; i++)
            {
                if (array[i] % 2 == 0)
                {
                    RemoverNo(i);
                }
            }
        }

        public void Mostrar()
        {
            if (n == 0)
                throw new Exception("Erro!");

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(" - " + array[i]);
            }
        }

        public void Inverter()
        {
            if (n == 0)
                throw new Exception("Erro!");

            int temp = 0;
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
