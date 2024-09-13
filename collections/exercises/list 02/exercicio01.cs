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
            List<int> lista_de_numeros = new List<int>();

            int opcao = 0;

            while (opcao != 9)
            {
                Console.WriteLine("LISTA DE NUMEROS");
                Console.WriteLine("================");
                Console.WriteLine("1 - Inserir um número na lista");
                Console.WriteLine("2 - Verificar se um número se encontra na lista");
                Console.WriteLine("4 - Exibir a soma de todos os números na lista");
                Console.WriteLine("5 - Exibir o maior número na lista");
                Console.WriteLine("5 - Exibir o menor número na lista");
                Console.WriteLine("6 - Remover todos os números pares da lista");
                Console.WriteLine("7 - Exibir os números que estão na lista");
                Console.WriteLine("8 - Inverter os elementos da lista");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Digite o número que deseja adicionar: ");
                        int n = int.Parse(Console.ReadLine());


                        InserirNumero(ref lista_de_numeros, n);

                        Console.WriteLine("O número {0} foi adicionado a lista", n);

                        break;

                    case 2:
                        Console.WriteLine("Digite o número que deseja verificar: ");
                        n = int.Parse(Console.ReadLine());

                        if (VerificarNumero(ref lista_de_numeros, n))
                        {
                            Console.WriteLine("O número {0} está na lista", n);
                        }

                        else
                        {
                            Console.WriteLine("O número {0} não está na lista", n);
                        }

                        break;

                    case 3:
                        int soma = SomaTotal(ref lista_de_numeros);

                        Console.WriteLine("A soma total dos números na lista deu: {0}", soma);

                        break;

                    case 4:
                        int maior = MaiorNumero(ref lista_de_numeros);

                        Console.WriteLine("Maior número da lista é: {0}", maior);

                        break;

                    case 5:
                        int menor = MenorNumero(ref lista_de_numeros);

                        Console.WriteLine("Menor número da lista é: {0}", menor);

                        break;

                    case 6:
                        RemoverNumerosPares(ref lista_de_numeros);

                        Console.WriteLine("Todos os números pares foram removidos");

                        break;

                    case 7:
                        ExibirLista(ref lista_de_numeros);

                        break;

                    case 8:
                        InverterOrdem(ref lista_de_numeros);

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

        static void InserirNumero(ref List<int> lista_de_inteiros, int n)
        {
            lista_de_inteiros.Add(n);
        }

        static bool VerificarNumero(ref List<int> lista_de_inteiros, int n)
        {
            return lista_de_inteiros.Contains(n);
        }

        static int SomaTotal(ref List<int> lista_de_inteiros)
        {
            int soma = 0;

            foreach (int numero in lista_de_inteiros)
            {
                soma += numero;
            }

            return soma;
        }

        static int MaiorNumero(ref List<int> lista_de_inteiros)
        {
            int maior = lista_de_inteiros[0];

            foreach (int numero in lista_de_inteiros)
            {
                if (numero > maior)
                {
                    maior = numero;
                }
            }

            return maior;
        }

        static int MenorNumero(ref List<int> lista_de_inteiros)
        {
            int menor = lista_de_inteiros[0];

            foreach (int numero in lista_de_inteiros)
            {
                if (numero < menor)
                {
                    menor = numero;
                }
            }

            return menor;
        }

        static void RemoverNumerosPares(ref List<int> lista_de_inteiros)
        {
            for (int i = lista_de_inteiros.Count - 1; i >= 0; i--)
            {
                if (lista_de_inteiros[i] % 2 == 0)
                {
                    lista_de_inteiros.RemoveAt(i);
                }
            }
        }

        static void ExibirLista(ref List<int> lista_de_inteiros)
        {
            Console.WriteLine("Lista:");

            for (int i = 0; i < lista_de_inteiros.Count(); i++)
            {
                Console.WriteLine("- " + lista_de_inteiros[i]);
            }
        }

        static void InverterOrdem(ref List<int> lista_de_inteiros)
        {
            lista_de_inteiros.Reverse();
        }
    }
}
