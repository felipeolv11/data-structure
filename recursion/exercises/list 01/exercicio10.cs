using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio10
{
    class Program
    {
        static string ConverterBinario(int n)
        {
            if (n == 0)
            {
                return "0";
            }

            if (n == 1)
            {
                return "1";
            }

            return ConverterBinario(n / 2) + (n % 2).ToString();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Digite um numero: ");
            int numero = int.Parse(Console.ReadLine());

            string resultado = ConverterBinario(numero);

            Console.WriteLine($"O numero {numero} em binario e: " + resultado);

            Console.ReadLine();
        }
    }
}
