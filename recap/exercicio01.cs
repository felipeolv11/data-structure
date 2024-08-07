using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[5];

            int valorMenor = int.MaxValue;

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"Preencha a posição n{i + 1} do array: ");
                array[i] = int.Parse(Console.ReadLine());

                if (array[i] < valorMenor)
                {
                    valorMenor = array[i];
                }
            }

            int temp = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == valorMenor)
                {
                    temp = array[0];
                    array[0] = array[i];
                    array[i] = temp;
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.ReadLine();
        }
    }
}
