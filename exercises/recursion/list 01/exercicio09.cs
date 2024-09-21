using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio09
{
    class Program
    {
        static void Inverter(int[] vet, int inicio, int fim)
        {
            if (inicio >= fim)
            {
                return;
            }

            else
            {
                int temp = vet[inicio];
                vet[inicio] = vet[fim];
                vet[fim] = temp;

                Inverter(vet, inicio + 1, fim - 1);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Escolha a quantidade de casas do vetor: ");
            int qtd = int.Parse(Console.ReadLine());

            int[] vet = new int [qtd];

            Random random = new Random();

            for (int i = 0; i < qtd; i++)
            {
                vet[i] = random.Next(1, 10);
            }

            Console.WriteLine("Vetor:");

            foreach (int i in vet)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Vetor invertido:");

            Inverter(vet, 0, qtd - 1);

            foreach (int i in vet)
            {
                Console.Write(i + " ");
            }

            Console.ReadLine();
        }
    }
}
