﻿using System;

namespace task3._6
{
    class Program
    {
        static double Pcalc(double[] cordX, double[] cordY)//Подсчет периметра многоугольника
        {
            double P = Math.Sqrt(Math.Pow((cordX[0] - cordX[cordX.Length - 1]), 2) + Math.Pow((cordY[0] - cordY[cordY.Length - 1]), 2));
            for (int i = 1; i<cordX.Length; i++)
            {
                P += Math.Sqrt(Math.Pow((cordX[i] - cordX[i-1]), 2) + Math.Pow((cordY[i] - cordY[i-1]), 2));
            }
            return P;
        }

        static double Scalc(double[] cordX, double[] cordY)//Подсчет площади многоугольника
        {
            double s = ((cordX[cordX.Length - 1] - cordX[0]) * (cordY[cordY.Length - 1] + cordY[0]));
            for(int i = 0; i < cordX.Length-1; i++)
            {
                s += ((cordX[i] - cordX[i + 1]) * (cordY[i] + cordY[i + 1]));
            }

            if(s<0)
            {
                s = s * -1;
            }
            s *= 0.5;
            return s;
        }

        static bool Ssqr(double[] cordX, double[] cordY, out double S, out double P)//Проверка координат и вызовы функций подсчета
        {
            S = Scalc(cordX, cordY);
            P = Pcalc(cordX, cordY);
            bool cordOk = true;
            for(int i = 0; i< cordX.Length; i++)
            {
                for(int j = cordX.Length-1; j > i; j--)
                {
                    if ((cordX[i] == cordX[j]) && (cordY[i] == cordY[j]))
                    {
                        cordOk = false;
                    }
                }
            }
            if(S == 0)
            {
                cordOk = false;
            }
            if (cordOk)
            {
                return true;
            }
            return false;
        }
        
        static void Main(string[] args)
        {
            int count = 4;
            //Console.WriteLine("Введите количество точек многоугольника: ");
            //count = Convert.ToInt32(Console.ReadLine());
            double[] cordX = new double[count];
            double[] cordY = new double[count];
            for(int i = 0; i<cordX.Length; i++)
            {
                Console.WriteLine("Введите координаты {0} точки:", (i+1));
                Console.Write("Точка х:");
                cordX[i] = Convert.ToDouble(Console.ReadLine());
                Console.Write("Точка y:");
                cordY[i] = Convert.ToDouble(Console.ReadLine());
                Console.Clear();
            }

            double S = 0, P = 0;
            bool OK = Ssqr(cordX, cordY, out S, out P);

            if(OK)
            {
                Console.WriteLine("Площадь: {0}; Периметр: {1};", S, P);
                return;
            }

            Console.WriteLine("Ты ошибся в координатах.");
        }
    }
}