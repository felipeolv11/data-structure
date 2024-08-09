using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Retangulo
    {
        private double largura;
        private double altura;

        public double Altura
        {
            get
            {
                return altura;
            }

            set
            {
                altura = value;
            }
        }

        public double Largura
        {
            get
            {
                return largura;
            }

            set
            {
                largura = value;
            }
        }

        public Retangulo(double altura, double largura)
        {
            this.altura = altura;
            this.largura = largura;
        }

        public double ObterArea()
        {
            return altura * largura;
        }

        public double ObterPerimetro()
        {
            return 2 * (altura + largura);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite a altura do retangulo: ");
            double altura = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite a largura do retangulo: ");
            double largura = double.Parse(Console.ReadLine());

            Retangulo retangulo = new Retangulo(altura, largura);

            Console.WriteLine("Area do retangulo: " + retangulo.ObterArea());
            Console.WriteLine("Perimetro do retangulo: " + retangulo.ObterPerimetro());

            Console.ReadLine();
        }
    }
}
