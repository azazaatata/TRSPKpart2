using System;

namespace task_1._2
{
    class Math
    {
        public const double Pi = 3.14;//Константа, изменить ее нельзя
        public const double e = 2.72;//Константа, изменить ее нельзя
        public readonly int degree = 2;//Поле для чтения, значение задается при создании
        public Math(int k)
        {
            degree = k;
        }
        public double Circle(double rad)
        {
            double S;
            S = Pi * rad * rad;
            return S;
        }
        public double ChangeCon(double ch)
        {
            //Pi = ch; - Невозможно
            return Pi;
        }
        public int deg(int k)
        {
            int ret = 1;
            for(int i = 0; i<k; k++)
            {
                ret *= k;
            }
            return ret;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите желаемое значение: ");
            int k = Convert.ToInt32(Console.ReadLine());
            Math ex1 = new Math(k);
            Console.WriteLine(ex1.degree);
        }
    }
}
