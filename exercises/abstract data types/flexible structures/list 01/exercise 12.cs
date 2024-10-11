using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio12
{
    class Program
    {
        static void Main(string[] args)
        {
            ListaDupla Agenda = new ListaDupla();

            int opcao = 0;

            while (opcao != 5)
            {
                Console.WriteLine("AGENDA");
                Console.WriteLine("======");
                Console.WriteLine("1 - Adicionar um contato com nome, telefone e e-mail.");
                Console.WriteLine("2 - Atualizar informações de um contato existente.");
                Console.WriteLine("3 - Excluir um contato da agenda.");
                Console.WriteLine("4 - Listar todos os contatos na agenda.");
                Console.WriteLine("5 - Encerrar o programa.");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Digite o nome, e-mail e o telefone do contato, nesta ordem.");
                        string nome = Console.ReadLine();
                        string email = Console.ReadLine();
                        int telefone = int.Parse(Console.ReadLine());

                        Contato contato = new Contato(nome, email, telefone);

                        Agenda.InserirFim(contato);

                        Console.WriteLine("O contato foi inserido na agenda.", nome);
                        break;

                    case 2:
                        Console.WriteLine("Qual o nome do contato?");
                        nome = Console.ReadLine();

                        if (Agenda.Verificar(nome))
                        {
                            Console.WriteLine("O que deseja atualizar?");
                            Console.WriteLine("1 - Nome");
                            Console.WriteLine("2 - E-mail");
                            Console.WriteLine("3 - Telefone");
                            int opcao_atualizar = int.Parse(Console.ReadLine());

                            switch (opcao_atualizar)
                            {
                                case 1:
                                    Console.WriteLine("Digite o novo nome:");
                                    string novoNome = Console.ReadLine();

                                    for (CelulaDupla i = Agenda.Primeiro.Prox; i != null; i = i.Prox)
                                    {
                                        if (i.Elemento.Nome == nome)
                                        {
                                            i.Elemento.Nome = novoNome;
                                            Console.WriteLine("Nome atualizado com sucesso.");

                                            break;
                                        }
                                    }

                                    break;

                                case 2:
                                    Console.WriteLine("Digite o novo E-mail:");
                                    string novoEmail = Console.ReadLine();

                                    for (CelulaDupla i = Agenda.Primeiro.Prox; i != null; i = i.Prox)
                                    {
                                        if (i.Elemento.Nome == nome)
                                        {
                                            i.Elemento.Email = novoEmail;
                                            Console.WriteLine("E-mail atualizado com sucesso.");

                                            break;
                                        }
                                    }

                                    break;

                                case 3:
                                    Console.WriteLine("Digite o novo Telefone:");
                                    int novoTelefone = int.Parse(Console.ReadLine());

                                    for (CelulaDupla i = Agenda.Primeiro.Prox; i != null; i = i.Prox)
                                    {
                                        if (i.Elemento.Nome == nome)
                                        {
                                            i.Elemento.Telefone = novoTelefone;
                                            Console.WriteLine("Telefone atualizado com sucesso.");

                                            break;
                                        }
                                    }

                                    break;

                                default:
                                    Console.WriteLine("Opção inválida!");
                                    break;
                            }
                        }

                        else
                        {
                            Console.WriteLine("Contato não encontrado na agenda.");
                        }

                        break;

                    case 3:
                        Console.WriteLine("Digite o nome do contato que deseja excluir:");
                        nome = Console.ReadLine();

                        if (Agenda.Verificar(nome))
                        {
                            int cont = 0;

                            for (CelulaDupla i = Agenda.Primeiro.Prox; i != null; i = i.Prox)
                            {
                                cont++;
                                
                                if (i.Elemento.Nome == nome)
                                {
                                    Agenda.Remover(cont - 1);

                                    Console.WriteLine("O contato foi removido da agenda");
                                    break;
                                }
                            }
                        }

                        else
                        {
                            Console.WriteLine("Contato não encontrado na agenda.");
                        }

                        break;

                    case 4:
                        Console.WriteLine("Agenda:");
                        Agenda.Mostrar();

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

    class CelulaDupla
    {
        private Contato elemento;
        private CelulaDupla prox, ant;

        public CelulaDupla()
        {
            this.elemento = null;
            this.prox = null;
            this.ant = null;
        }

        public CelulaDupla(Contato elemento)
        {
            this.elemento = elemento;
            this.prox = null;
            this.ant = null;
        }

        public Contato Elemento
        {
            get { return elemento; }
            set { elemento = value; }
        }

        public CelulaDupla Prox
        {
            get { return prox; }
            set { prox = value; }
        }

        public CelulaDupla Ant
        {
            get { return ant; }
            set { ant = value; }
        }
    }

    class ListaDupla
    {
        private CelulaDupla primeiro, ultimo;

        public CelulaDupla Primeiro
        {
            get { return primeiro; }
            set { primeiro = value; }
        }
        public CelulaDupla Ultimo
        {
            get { return ultimo; }
            set { ultimo = value; }
        }

        public ListaDupla()
        {
            primeiro = new CelulaDupla();
            ultimo = primeiro;
        }

        public void InserirInicio(Contato x)
        {
            CelulaDupla tmp = new CelulaDupla(x);
            tmp.Ant = primeiro;
            tmp.Prox = primeiro.Prox;
            primeiro.Prox = tmp;
            if (primeiro == ultimo)
                ultimo = tmp;
            else
            {
                tmp.Prox.Ant = tmp;
            }
            tmp = null;
        }

        public void InserirFim(Contato x)
        {
            ultimo.Prox = new CelulaDupla(x);
            ultimo.Prox.Ant = ultimo;
            ultimo = ultimo.Prox;
        }

        public Contato RemoverInicio()
        {
            if (primeiro == ultimo)
                throw new Exception("Erro!");

            CelulaDupla tmp = primeiro.Prox;
            Contato elemento = tmp.Elemento;
            primeiro.Prox = tmp.Prox;

            if (primeiro.Prox != null)
                primeiro.Prox.Ant = primeiro;

            if (tmp == ultimo)
                ultimo = primeiro;

            tmp.Prox = tmp.Ant = null;

            return elemento;
        }

        public Contato RemoverFim()
        {
            if (primeiro == ultimo)
                throw new Exception("Erro!");

            Contato elemento = ultimo.Elemento;
            ultimo = ultimo.Ant;
            ultimo.Prox = null;

            return elemento;
        }

        public void Inserir(Contato x, int pos)
        {
            int tamanho = Tamanho();
            if (pos < 0 || pos > tamanho)
                throw new Exception("Erro!");
            else if (pos == 0)
                InserirInicio(x);
            else if (pos == tamanho)
                InserirFim(x);
            else
            {
                CelulaDupla i = primeiro;
                for (int j = 0; j < pos; j++, i = i.Prox) ;
                CelulaDupla tmp = new CelulaDupla(x);
                tmp.Ant = i;
                tmp.Prox = i.Prox;
                tmp.Ant.Prox = tmp.Prox.Ant = tmp;
                tmp = i = null;
            }
        }

        public Contato Remover(int pos)
        {
            int tamanho = Tamanho();
            if (primeiro == ultimo || pos < 0 || pos >= tamanho)
                throw new Exception("Erro!");
            else if (pos == 0)
                return RemoverInicio();
            else if (pos == tamanho - 1)
                return RemoverFim();
            else
            {
                CelulaDupla i = primeiro;
                for (int j = 0; j < pos; j++, i = i.Prox) ;
                i.Ant.Prox = i.Prox;
                i.Prox.Ant = i.Ant;
                Contato elemento = i.Elemento;
                i.Prox = i.Ant = null;
                i = null;

                return elemento;
            }
        }

        public void Mostrar()
        {
            for (CelulaDupla i = primeiro.Prox; i != null; i = i.Prox)
            {
                Console.WriteLine("Nome: {0} | E-mail: {1} | Telefone {2} ", i.Elemento.Nome, i.Elemento.Email, i.Elemento.Telefone);
            }
        }

        public int Tamanho()
        {
            int tam = 0;
            for (CelulaDupla i = primeiro.Prox; i != null; i = i.Prox)
                tam++;
            return tam;
        }

        public bool Verificar(string nome)
        {
            for (CelulaDupla i = primeiro.Prox; i != null; i = i.Prox)
            {
                if (i.Elemento.Nome == nome)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
