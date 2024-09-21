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
            List<Contato> agenda_de_contatos = new List<Contato>();

            int opcao = 0;

            while (opcao != 5)
            {
                Console.WriteLine("AGENDA DE CONTATOS");
                Console.WriteLine("==================");
                Console.WriteLine("1 - Adicionar um novo contato com nome, telefone e e-mail");
                Console.WriteLine("2 - Atualizar informações de um contato existente");
                Console.WriteLine("3 - Excluir um contato da agenda");
                Console.WriteLine("4 - Listar todos os contatos na agenda");
                Console.WriteLine("5 - Encerrar programa");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Digite o NOME, EMAIL e TELEFONE do contato que deseja adicionar, nesta ordem: ");
                        string nome = Console.ReadLine();
                        string email = Console.ReadLine();
                        int telefone = int.Parse(Console.ReadLine());

                        AdicionarContato(ref agenda_de_contatos, nome, email, telefone);

                        Console.WriteLine("O contato foi adicionado.");

                        break;

                    case 2:
                        Console.WriteLine("Digite o NOME, EMAIL e TELEFONE do contato que deseja atualizar, nesta ordem: ");
                        nome = Console.ReadLine();
                        email = Console.ReadLine();
                        telefone = int.Parse(Console.ReadLine());

                        AtualizarContato(ref agenda_de_contatos, nome, email, telefone);

                        break;

                    case 3:
                        Console.WriteLine("Digite o NOME, EMAIL e TELEFONE do contato que deseja remover, nesta ordem: ");
                        nome = Console.ReadLine();
                        email = Console.ReadLine();
                        telefone = int.Parse(Console.ReadLine());

                        ExcluirContato(ref agenda_de_contatos, nome, email, telefone);

                        break;

                    case 4:
                        if (agenda_de_contatos.Count > 0)
                        {
                            ListarContatos(ref agenda_de_contatos);
                        }

                        else
                        {
                            Console.WriteLine("A agenda ainda não possui contatos.");
                        }

                        break;

                    case 5:
                        Console.WriteLine("FIM!");

                        break;

                    default:
                        Console.WriteLine("Opção inválida!");

                        break;
                }
            }

            Console.ReadLine();
        }

        static void AdicionarContato(ref List<Contato> agenda_de_contatos, string nome, string email, int telefone)
        {
            Contato contato = new Contato(nome, email, telefone);

            agenda_de_contatos.Add(contato);
        }

        static void AtualizarContato(ref List<Contato> agenda_de_contatos, string nome, string email, int telefone)
        {
            int indice = IndiceContato(ref agenda_de_contatos, nome, email, telefone);

            if (indice != -1)
            {
                Console.WriteLine("Agora, o NOME, EMAIL e TELEFONE atualizados: ");
                string novo_nome = Console.ReadLine();
                string novo_email = Console.ReadLine();
                int novo_telefone = int.Parse(Console.ReadLine());

                agenda_de_contatos[indice] = new Contato(novo_nome, novo_email, novo_telefone);

                Console.WriteLine("Os dados foram atualizados.");
            }

            else
            {
                Console.WriteLine("Contato não encontrado.");
            }
        }

        static void ExcluirContato(ref List<Contato> agenda_de_contatos, string nome, string email, int telefone)
        {
            int indice = IndiceContato(ref agenda_de_contatos, nome, email, telefone);

            if (indice != -1)
            {
                agenda_de_contatos.RemoveAt(indice);

                Console.WriteLine("O contato foi removido da lista.");
            }

            else
            {
                Console.WriteLine("Contato não encontrado.");
            }
        }

        static void ListarContatos(ref List<Contato> agenda_de_contatos)
        {
            Console.WriteLine("Lista de contatos:");

            foreach (Contato contato in agenda_de_contatos)
            {
                Console.WriteLine("- Nome: {0}, Email: {1}, Telefone: {2}", contato.Nome, contato.Email, contato.Telefone);
            }
        }

        static int IndiceContato(ref List<Contato> agenda_de_contatos, string nome, string email, int telefone)
        {
            foreach (Contato contato in agenda_de_contatos)
            {
                if (contato.Nome == nome && contato.Email == email && contato.Telefone == telefone)
                {
                    return agenda_de_contatos.IndexOf(contato);
                }
            }

            return -1;
        }
    }

    class Contato
    {
        private string nome;
        private string email;
        private int telefone;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public int Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }

        public Contato(string nome, string email, int telefone)
        {
            this.nome = nome;
            this.email = email;
            this.telefone = telefone;
        }
    }
}
