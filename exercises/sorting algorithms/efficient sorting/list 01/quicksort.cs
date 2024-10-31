using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metodo_quicksort
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
                QuickSort(copia_cresc, 0, copia_cresc.Length - 1, ref tempo_mov, ref tempo_comp);
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

            Console.WriteLine("Metódo: Quicksort | Tipo: Crescente | Tamanho: {0} | Tempo: {1}ms | Movimentações: {2} | Comparações: {3}", ordem_crescente.Length, media_cresc, num_movimentacao, num_comparacao);

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
                QuickSort(copia_decresc, 0, copia_decresc.Length - 1, ref tempo_mov, ref tempo_comp);
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

            Console.WriteLine("Metódo: Quicksort | Tipo: Decrescente | Tamanho: {0} | Tempo: {1}ms | Movimentações: {2} | Comparações: {3}", ordem_decrescente.Length, media_decresc, num_movimentacao, num_comparacao);

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
                QuickSort(copia_aleat, 0, copia_aleat.Length - 1, ref tempo_mov, ref tempo_comp);
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

            Console.WriteLine("Metódo: Quicksort | Tipo: Aleatório | Tamanho: {0} | Tempo: {1}ms | Movimentações: {2} | Comparações: {3}", ordem_aleatoria.Length, media_aleat, num_movimentacao, num_comparacao);

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

        static void QuickSort(int[] array, int esq, int dir, ref long temp_mov, ref long temp_comp)
        {
            int i = esq, j = dir, pivo = array[(esq + dir) / 2];
            while (i <= j)
            {
                while (array[i] < pivo) { i++; temp_comp++; }

                while (array[j] > pivo) { j--; temp_comp++; }

                if (i <= j)
                { Trocar(array, i, j, ref temp_mov, ref temp_comp); i++; j--; temp_comp++; }
                temp_comp += 3;
            }

            if (esq < j)
                QuickSort(array, esq, j, ref temp_mov, ref temp_comp);

            if (i < dir)
                QuickSort(array, i, dir, ref temp_mov, ref temp_comp);

            temp_comp += 2;
        }

        static void Trocar(int[] array, int i, int j, ref long temp_mov, ref long temp_comp)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
            temp_mov += 3;
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