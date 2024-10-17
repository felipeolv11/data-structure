using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metodo_selecao
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ordem_crescente = new int[1000];
            int[] ordem_decrescente = new int[1000];
            int[] ordem_aleatoria = new int[1000];

            int[] copia_cresc = new int[1000];
            int[] copia_decresc = new int[1000];
            int[] copia_aleat = new int[1000];

            long[] tempo_cresc = new long[10];
            long[] tempo_decresc = new long[10];
            long[] tempo_aleat = new long[10];

            int num_movimentacao = 0;
            int num_comparacao = 0;

            Random rnd = new Random();
            Stopwatch sw = new Stopwatch();

            for (int i = 0; i < ordem_crescente.Length; i++)
            {
                ordem_crescente[i] = i + 1;
                copia_cresc[i] = ordem_crescente[i];
            }

            for (int i = 0; i < ordem_decrescente.Length; i++)
            {
                ordem_decrescente[i] = ordem_decrescente.Length - i;
                copia_decresc[i] = ordem_decrescente[i];
            }

            for (int i = 0; i < ordem_aleatoria.Length; i++)
            {
                ordem_aleatoria[i] = rnd.Next(1, 1000);
                copia_aleat[i] = ordem_aleatoria[i];
            }


            // Ordem Crescente
            for (int i = 0; i < tempo_cresc.Length; i++)
            {
                int tempo_mov = 0;
                int tempo_comp = 0;

                sw.Start();
                Selecao(copia_cresc, ref tempo_mov, ref tempo_comp);
                sw.Stop();

                tempo_cresc[i] = sw.ElapsedMilliseconds;

                if (num_movimentacao < tempo_mov)
                    num_movimentacao = tempo_mov;

                if (num_comparacao < tempo_comp)
                    num_comparacao = tempo_comp;
            }

            long tempoTotal_cresc = 0;

            for (int i = 0; i < tempo_cresc.Length; ++i)
            {
                tempoTotal_cresc += tempo_cresc[i];
            }

            long media_cresc = tempoTotal_cresc / tempo_cresc.Length;

            Console.WriteLine("Metódo: Seleção | Tipo: Crescente | Tamanho: {0} | Tempo: {1}ms | Movimentações: {2} | Comparações: {3}", ordem_crescente.Length, media_cresc, num_movimentacao, num_comparacao);

            Console.WriteLine("Deseja ver o antes de depois do vetor?");
            string resp = Console.ReadLine();

            if (resp == "sim")
            {
                Console.WriteLine("Antes:");
                Mostrar(ordem_crescente);

                Console.WriteLine();

                Console.WriteLine("Depois:");
                Mostrar(copia_cresc);
            }

            else
            {
                Console.WriteLine("Continuando...");
            }

            // Ordem Decrescente
            for (int i = 0; i < tempo_decresc.Length; i++)
            {
                int tempo_mov = 0;
                int tempo_comp = 0;

                sw.Start();
                Selecao(copia_decresc, ref tempo_mov, ref tempo_comp);
                sw.Stop();

                tempo_decresc[i] = sw.ElapsedMilliseconds;

                if (num_movimentacao < tempo_mov)
                    num_movimentacao = tempo_mov;

                if (num_comparacao < tempo_comp)
                    num_comparacao = tempo_comp;
            }

            long tempoTotal_decresc = 0;

            for (int i = 0; i < tempo_decresc.Length; ++i)
            {
                tempoTotal_decresc += tempo_decresc[i];
            }

            long media_decresc = tempoTotal_decresc / tempo_decresc.Length;

            Console.WriteLine("Metódo: Seleção | Tipo: Decrescente | Tamanho: {0} | Tempo: {1}ms | Movimentações: {2} | Comparações: {3}", ordem_decrescente.Length, media_decresc, num_movimentacao, num_comparacao);

            Console.WriteLine("Deseja ver o antes de depois do vetor?");
            resp = Console.ReadLine();

            if (resp == "sim")
            {
                Console.WriteLine("Antes:");
                Mostrar(ordem_decrescente);

                Console.WriteLine();

                Console.WriteLine("Depois:");
                Mostrar(copia_decresc);
            }

            else
            {
                Console.WriteLine("Continuando...");
            }

            // Ordem Aleatória
            for (int i = 0; i < tempo_aleat.Length; i++)
            {
                int tempo_mov = 0;
                int tempo_comp = 0;

                sw.Start();
                Selecao(copia_aleat, ref tempo_mov, ref tempo_comp);
                sw.Stop();

                tempo_aleat[i] = sw.ElapsedMilliseconds;

                if (num_movimentacao < tempo_mov)
                    num_movimentacao = tempo_mov;

                if (num_comparacao < tempo_comp)
                    num_comparacao = tempo_comp;
            }

            long tempoTotal_aleat = 0;

            for (int i = 0; i < tempo_aleat.Length; ++i)
            {
                tempoTotal_aleat += tempo_aleat[i];
            }

            long media_aleat = tempoTotal_aleat / tempo_aleat.Length;

            Console.WriteLine("Metódo: Seleção | Tipo: Aleatório | Tamanho: {0} | Tempo: {1}ms | Movimentações: {2} | Comparações: {3}", ordem_aleatoria.Length, media_aleat, num_movimentacao, num_comparacao);

            Console.WriteLine("Deseja ver o antes de depois do vetor?");
            resp = Console.ReadLine();

            if (resp == "sim")
            {
                Console.WriteLine("Antes:");
                Mostrar(ordem_aleatoria);

                Console.WriteLine();

                Console.WriteLine("Depois:");
                Mostrar(copia_aleat);
            }

            else
            {
                Console.WriteLine("FIM!");
            }

            Console.ReadLine();
        }

        static void Selecao(int[] arr, ref int mov, ref int comp)
        {
            int n = arr.Length;
            for (int i = 0; i < (n - 1); i++)
            {
                int menor = i;
                for (int j = (i + 1); j < n; j++)
                {
                    if (arr[menor] > arr[j])
                    {
                        menor = j;
                    }
                    comp++;
                }

                int temp = arr[menor];
                arr[menor] = arr[i];
                arr[i] = temp;
                mov += 3;
            }
        }

        static void Mostrar(int[] arr)
        {
            Console.Write("[ ");
            for(int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine("]");
        }
    }
}
