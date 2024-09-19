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
            List<int> lista_de_numeros = new List<int>();

            Random random = new Random();

            for (int i = 0; i < 100;  i++)
            {
                lista_de_numeros.Add(random.Next(1, 100));
            }

            Dictionary<int, int> contador_de_frequencia = new Dictionary<int, int>();

            foreach (int numero in lista_de_numeros)
            {
                if (contador_de_frequencia.ContainsKey(numero))
                {
                    contador_de_frequencia[numero] += 1;
                }

                else
                {
                    contador_de_frequencia[numero] = 1;
                }
            }

            int opcao = 0;

            while (opcao != 4)
            {
                Console.WriteLine("1 - Verificar determinado número no dicionário");
                Console.WriteLine("2 - Exibir quantos número distintos têm no dicionário");
                Console.WriteLine("3 - Exibir os números e suas frequências de aparição");
                Console.WriteLine("4 - Encerrar o programa");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Digite o número que deseja verificar: ");
                        int numero = int.Parse(Console.ReadLine());

                        if (VerificarNumero(ref contador_de_frequencia, numero))
                        {
                            Console.WriteLine("O número '{0}' está no dicionário", numero);
                        }

                        else
                        {
                            Console.WriteLine("O número '{0}' não está no dicionário", numero);
                        }

                        break;

                    case 2:
                        Console.WriteLine("Quantidade de números distintos no dicionário: {0}", NumerosDistintos(ref contador_de_frequencia));

                        break;

                    case 3:
                        ImprimirNumerosEFrequencias(ref contador_de_frequencia);

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

        static bool VerificarNumero(ref Dictionary<int, int> contador_de_frequencia, int numero)
        {
            return contador_de_frequencia.ContainsKey(numero);
        }

        static int NumerosDistintos(ref Dictionary<int, int> contador_de_frequencia)
        {
            int count = 0;

            foreach (int numero in contador_de_frequencia.Keys)
            {
                count++;
            }

            return count;
        }

        static void ImprimirNumerosEFrequencias(ref Dictionary<int, int> contador_de_frequencia)
        {
            Console.WriteLine("Lista de números:");

            foreach (KeyValuePair<int, int> kv in contador_de_frequencia)
            {
                Console.WriteLine("Número: {0} | Qtd: {1}", kv.Key, kv.Value);
            }
        }
    }
}
