using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio02
{
    class Program
    {
        static public int SomaSerie(int i, int j, int k)
        {
            if (i > j)
            {
                return 0;
            }

            else
            {
                return i + SomaSerie(i + k, j, k);
            }
        }

        static void Main(string[] args)
        {
            int i = 1, j = 10, k = 2;

            int resultado = SomaSerie(i, j, k);

            Console.WriteLine(resultado);

            Console.ReadLine();
        }
    }
}
