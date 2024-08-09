using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Aluno
    {
        private string nome;
        private int matricula;
        private double[] notas;

        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }

        public int Matricula
        {
            get
            {
                return matricula;
            }

            set
            {
                matricula = value;
            }
        }

        public double[] Notas
        {
            get
            {
                return notas;
            }

            set
            {
                notas = value;
            }
        }

        public Aluno(string nome, int matricula, double[] notas)
        {
            this.nome = nome;
            this.matricula = matricula;
            this.notas = notas;
        }

        public double CalcularMedia()
        {
            double total = 0;

            for (int i = 0; i < notas.Length; i++)
            {
                total += notas[i];
            }

            return total / notas.Length;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Qual o nome do aluno? ");
            string nome = Console.ReadLine();

            Console.WriteLine("Qual a matricula? ");
            int matricula = int.Parse(Console.ReadLine());

            Console.WriteLine("Quantas notas deseja enviar? ");
            int qtdNotas = int.Parse(Console.ReadLine());

            double[] notas = new double[qtdNotas];
            
            for (int i = 0; i < qtdNotas; i++)
            {
                Console.WriteLine($"Qual a {i + 1} nota? ");
                notas[i] = double.Parse(Console.ReadLine());
            }

            Aluno aluno = new Aluno(nome, matricula, notas);

            Console.WriteLine($"A media do {aluno.Nome}, {aluno.Matricula} e: {aluno.CalcularMedia()}.");

            Console.ReadLine();
        }
    }
}
