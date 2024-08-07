using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio07
{
    internal class Program
    {
        static void AumentarSalario(ref double salario, int percentual)
        {
            salario += salario * (percentual / 100.0);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Digite o salário: ");
            double salario = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o percentual: ");
            int percentual = int.Parse(Console.ReadLine());

            AumentarSalario(ref salario, percentual);

            Console.WriteLine($"O novo salário é: {salario}R$");
            Console.ReadLine();
        }
    }
}
