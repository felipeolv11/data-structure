using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio03
{
    class Program
    {
        static int FatorialDuplo(int n)
        {
            if (n % 2 == 0)
            {
                Console.WriteLine("O numero precisa ser impar!");
                
                return -1;
            }

            else
            {
                if (n == 1)
                {
                    return n;
                }

                else
                {
                    return n * FatorialDuplo(n - 2);
                }
            }
        }

        static void Main(string[] args)
        {
            int resultado = FatorialDuplo(9);

            Console.WriteLine(resultado);

            Console.ReadLine();
        }
    }
}
