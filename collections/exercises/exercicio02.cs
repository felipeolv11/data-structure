using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio02
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            bool maiorque3 = false;
            
            do
            {
                Console.WriteLine("Digite um numero N: ");
                n = int.Parse(Console.ReadLine());

                if (n >= 3)
                {
                    maiorque3 = true;
                }

                else
                {
                    Console.WriteLine("O numero precisa ser maior ou igual a tres.");
                }

            } while (!maiorque3);

            Stack<int> s = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                s.Push(Fibonacci(i));
            }

            foreach (int num in s)
            {
                Console.Write(num + " ");
            }

            Console.ReadLine();
        }
        static int Fibonacci(int n)
        {
            if (n <= 1)
            {
                return n;
            }

            else
            {
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }
        }
    }
}
