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
            Console.WriteLine("Digite o tamanho do array: ");
            int tam = int.Parse(Console.ReadLine());
            
            int[] arr = new int[tam];

            Random rand = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(1, 100);
            }

            Console.WriteLine("Digite o alvo que deseja procurar: ");
            int x = int.Parse(Console.ReadLine());

            int index = BuscaSequencial(arr, x);

            if (index != -1)
                Console.WriteLine("O alvo foi encontrado na posição: {0}", index);
            
            else
                Console.WriteLine("O alvo não se encontra no array.");

            Console.ReadLine();
        }

        static int BuscaSequencial(int[] arr, int x)
        {
            for (int i = 0; i < arr.Length; ++i)
            {
                if(arr[i] == x)
                    return i;
            }

            return -1;
        }
    }
}
