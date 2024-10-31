using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metodo_heapsort
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

            long num_movimentacao = 0;
            long num_comparacao = 0;

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
                long tempo_mov = 0;
                long tempo_comp = 0;

                sw.Start();
                HeapSort(copia_cresc, copia_cresc.Length - 1, ref tempo_mov, ref tempo_comp);
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

            Console.WriteLine("Metódo: Heapsort | Tipo: Crescente | Tamanho: {0} | Tempo: {1}ms | Movimentações: {2} | Comparações: {3}", ordem_crescente.Length, media_cresc, num_movimentacao, num_comparacao);

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
                long tempo_mov = 0;
                long tempo_comp = 0;

                sw.Start();
                HeapSort(copia_decresc, copia_decresc.Length - 1, ref tempo_mov, ref tempo_comp);
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

            Console.WriteLine("Metódo: Heapsort | Tipo: Decrescente | Tamanho: {0} | Tempo: {1}ms | Movimentações: {2} | Comparações: {3}", ordem_decrescente.Length, media_decresc, num_movimentacao, num_comparacao);

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
                long tempo_mov = 0;
                long tempo_comp = 0;

                sw.Start();
                HeapSort(copia_aleat, copia_aleat.Length - 1, ref tempo_mov, ref tempo_comp);
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

            Console.WriteLine("Metódo: Heapsort | Tipo: Aleatório | Tamanho: {0} | Tempo: {1}ms | Movimentações: {2} | Comparações: {3}", ordem_aleatoria.Length, media_aleat, num_movimentacao, num_comparacao);

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

        static void HeapSort(int[] array, int n, ref long temp_mov, ref long temp_comp)
        {
            int tam;
            for (tam = 2; tam <= n; tam++)
            {
                Construir(array, tam, ref temp_mov, ref temp_comp);
            }

            tam = n;

            while (tam > 1)
            {
                Trocar(array, 1, tam--, ref temp_mov, ref temp_comp);
                Reconstruir(array, tam, ref temp_mov, ref temp_comp);
                temp_comp++;
            }
        }

        static void Construir(int[] array, int tam, ref long temp_mov, ref long temp_comp)
        {
            for (int i = tam; i > 1 && array[i] > array[i / 2]; i /= 2)
            {
                Trocar(array, i, i / 2, ref temp_mov, ref temp_comp);
            }
        }

        static void Trocar(int[] array, int i, int j, ref long temp_mov, ref long temp_comp)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
            temp_mov += 3;
        }

        static void Reconstruir(int[] array, int tam, ref long temp_mov, ref long temp_comp)
        {
            int i = 1;
            while (HasFilho(i, tam, ref temp_comp) == true)
            {
                int filho = GetMaiorFilho(array, i, tam, ref temp_comp);

                if (array[i] < array[filho])
                {
                    Trocar(array, i, filho, ref temp_mov, ref temp_comp);
                    i = filho;
                }

                else
                {
                    i = tam;

                }

                temp_comp++;
            }
        }

        static bool HasFilho(int i, int tam, ref long temp_comp)
        {
            temp_comp++;
            return (i <= (tam / 2));
        }

        static int GetMaiorFilho(int[] array, int i, int tam, ref long temp_comp)
        {
            int filho;

            if (2 * i == tam || array[2 * i] > array[2 * i + 1])
            {
                filho = 2 * i;
            }

            else
            {
                filho = 2 * i + 1;
            }

            temp_comp += 2;
            return filho;
        }

        static void Mostrar(int[] arr)
        {
            Console.Write("[ ");
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine("]");
        }
    }
}