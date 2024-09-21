using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio08
{
    class Program
    {
        static double S(int n)
        {
            if (n == 1)
            {
                return 2;
            }

            else
            {
                return (1 + Math.Pow(n, 2)) / n + S(n - 1);
            }
        }

        static void Main(string[] args)
        {
            double resultado = S(10);

            Console.WriteLine(resultado);

            Console.ReadLine();
        }
    }
}
