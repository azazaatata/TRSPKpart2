using System;
using System.Collections.Generic;

namespace ExamTRSPK
{
    
    internal class Program
    {
        static List<string> memo = new List<string>();
        static int N;
        

        static void Read()
        {
            for (int i = 0; i < N; i++)
            {
                memo.Add(Console.ReadLine());
            }
            Processing();
        }

        static void Processing()
        {
            string proc;
            double[,] quad = new double[N, N];
            double[] temp;
            for (int i = 0; i < N; i++)
            {
                proc = memo[i];
                temp = ProcessingStr(proc);
                for(int j = 0; j < N; j++)
                {
                    quad[i, j] = temp[j];
                }
            }
            MatrixProc(quad);
        }

        static void MatrixProc(double[,] matrix)
        {
            double[,] transp = new double[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    transp[i, j] = matrix[j, i];
                }
            }
            double[] max = new double[N];
            for (int i = 0; i < N; i++)
            {
                max[i] = transp[i, 0];
                for (int j = 0; j < N; j++)
                {
                    if(matrix[i, j] < max[i])
                    {
                        max[i] = transp[i, j];
                    }
                }
            }
            Console.WriteLine("Исходная матрица:");
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(memo[i]);
            }
            Console.WriteLine("Транспонированная матрица:");
            PrintMatrix(transp);
            Console.WriteLine("Минимумы по столбцам исходной матрицы:");
            for (int i = 0; i < N; i++)
            {
                Console.Write(max[i] + " ");
            }
        }

        static void PrintMatrix(double[,] matrix)
        {
            for (int i = 0; i< N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static double[] ProcessingStr(string inp)
        {
            double[] ret = new double[N];
            int startInd = 0;
            int endInd;
            double conv;
            for (int i = 0; i < N - 1; i++)
            {
                endInd = inp.IndexOf(":");
                conv = Convert.ToDouble(inp.Substring(startInd, endInd));
                ret[i] = conv;
                inp = inp.Substring(endInd+1);
            }
            ret[N-1] = Convert.ToDouble(inp);
            return ret;
        }

        static void start()
        {
            Console.WriteLine("Введите размерность матрицы:");
            N = Convert.ToInt32(Console.ReadLine());
            Read();
        }


        static void Main(string[] args)
        {
            start();
        }
    }
}
