using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class ContaBancaria
    {
        private double saldo;
        private string titular;

        public double Saldo
        {
            get
            {
                return saldo;
            }

            set
            {
                saldo = value;
            }
        }

        public string Titular
        {
            get
            {
                return titular;
            }

            set
            {
                titular = value;
            }
        }

        public ContaBancaria(double saldo, string titular)
        {
            this.saldo = saldo;
            this.titular = titular;
        }

        public void Depositar(double deposito)
        {
            saldo += deposito;
        }

        public void Sacar(double saque)
        {
            saldo -= saque;
        }

        public double ExibirSaldo()
        {
            return saldo;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o nome do titular: ");
            string titular = Console.ReadLine();

            Console.WriteLine("Digite seu saldo: ");
            double saldo = double.Parse(Console.ReadLine());

            ContaBancaria pessoa1 = new ContaBancaria(saldo, titular);


            int opcao = 0;

            while (opcao != 4)
            {
                Console.WriteLine("Deseja:");
                Console.WriteLine("1 - Sacar");
                Console.WriteLine("2 - Depositar");
                Console.WriteLine("3 = Exibir saldo");
                Console.WriteLine("4 - Sair");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Quando deseja sacar? ");
                        double saque = double.Parse(Console.ReadLine());

                        pessoa1.Sacar(saque);

                        Console.WriteLine("Saque concluido, " + pessoa1.Titular + "!");

                        break;

                    case 2:
                        Console.WriteLine("Quanto deseja depositar? ");
                        double deposito = double.Parse(Console.ReadLine());

                        pessoa1.Depositar(deposito);

                        Console.WriteLine("Deposito concluido, " + pessoa1.Titular + "!");

                        break;

                    case 3:
                        Console.WriteLine("Seu saldo atual é: " + pessoa1.ExibirSaldo());

                        break;

                    case 4:

                        break;

                    default:
                        Console.WriteLine("Opcao invalida!");

                        break;
                }
            }


            Console.ReadLine();
        }
    }
}
