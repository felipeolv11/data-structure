using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio05
{
    class Program
    {
        static int MDC(int x, int y)
        {
            if (y == 0)
            {
                return x;
            }

            else
            {
                return MDC(y, x % y);
            }
        }

        static void Main(string[] args)
        {
            int resultado = MDC(12, 24);

            Console.WriteLine(resultado);

            Console.ReadLine();
        }
    }
}
