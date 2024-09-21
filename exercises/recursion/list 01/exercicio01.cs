using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio01
{
    class Program
    {
        static public int Somar(int n)
        {
            if (n == 1)
            {
                return n;
            }

            else
            {
                return (n * n * n) + Somar(n - 1);
            }
        }

        static void Main(string[] args)
        {
            int resultado = Somar(100);

            Console.WriteLine(resultado);

            Console.ReadLine();
        }
    }
}
