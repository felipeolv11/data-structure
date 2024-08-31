using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio04
{
    class Program
    {
        static int Pell(int n)
        {
            if (n == 0)
            {
                return 0;
            }
    
            else if (n == 1)
            {
                return 1;
            }

            else
            {
                return 2 * Pell(n - 1) + Pell(n - 2);
            }
        }

        static void Main(string[] args)
        {
            int resultado = Pell(8);

            Console.WriteLine(resultado);

            Console.ReadLine();
        }
    }
}
