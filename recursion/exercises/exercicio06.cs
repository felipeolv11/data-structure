using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio06
{
    class Program
    {
        static int Fatorial(int n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }

            else
            {
                return n * Fatorial(n - 1);
            }
        }

        static int SF(int n)
        {
            if (n == 1)
            {
                return 1;
            }

            else
            {
                return Fatorial(n) * SF(n - 1);
            }
        }

        static void Main(string[] args)
        {
            int resultado = SF(4);

            Console.WriteLine(resultado);

            Console.ReadLine();
        }
    }
}
