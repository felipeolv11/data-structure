using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio07
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
            int[] vet = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Inverter(vet, 0, vet.Length - 1);

            foreach (int i in vet)
            {
                Console.Write(i + " ");
            }

            Console.ReadLine();
        }
    }
}
