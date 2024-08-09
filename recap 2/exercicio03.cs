using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Livro
    {
        private string titulo;
        private string autor;
        private int anoPublicacao;
        private string genero;

        public Livro(string titulo, string autor, int anoPublicacao, string genero)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.anoPublicacao = anoPublicacao;
            this.genero = genero;
        }
        
        public string Titutlo
        {
            get
            {
                return titulo;
            }
            
            set
            {
                titulo = value;
            }
        }

        public string Autor
        {
            get
            {
                return autor;
            }

            set
            {
                autor = value;
            }
        }

        public int AnoPublicacao
        {
            get
            {
                return anoPublicacao;
            }

            set
            {
                anoPublicacao = value;
            }
        }

        public string Genero
        {
            get
            {
                return genero;
            }

            set
            {
                genero = value;
            }
        }

        public void ExibirInformacoes()
        {
            Console.WriteLine("Titulo: " + titulo);
            Console.WriteLine("Autor: " + autor);
            Console.WriteLine("Ano de publicacao: " + anoPublicacao);
            Console.WriteLine("Genero: " + genero);
        }

        public bool Ficticio()
        {
            if (genero == "Ficcao" || genero == "ficcao")
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Qual o nome do livro? ");
            string livro = Console.ReadLine();

            Console.WriteLine("Qual o nome do autor? ");
            string autor = Console.ReadLine();

            Console.WriteLine("Qual o ano da publicacao? ");
            int anoPublicacao = int.Parse(Console.ReadLine());

            Console.WriteLine("Qual o genero do livro? ");
            string genero = Console.ReadLine();

            Livro livro1 = new Livro(livro, autor, anoPublicacao, genero);

            Console.WriteLine();

            livro1.ExibirInformacoes();

            if (livro1.Ficticio() == true)
            {
                Console.WriteLine("O livro e do genero fictcio!");
            }

            else
            {
                Console.WriteLine("O livro nao e do genero fictcio!");
            }

            Console.ReadLine();
        }
    }
}
