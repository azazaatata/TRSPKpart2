using System;

namespace task_3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество измерений массива: ");
            int izm = Convert.ToInt32(Console.ReadLine());  //Кол-во измерений
            int elem_count = Convert.ToInt32(Math.Pow(izm, izm));
            int[] array = new int[elem_count];

            int[] MinRange = new int[izm];
            int[] MaxRange = new int[izm];

            for (int i = 0; i < izm; i++)   //Цикл для введения ограничений для каждого измерения
            {
                Console.WriteLine("Введите нижнюю границу для {0} измерения: ", i + 1);
                MinRange[i] = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введите верхнюю границу для {0} измерения: ", i + 1);
                MaxRange[i] = Convert.ToInt32(Console.ReadLine());

                Console.Clear();
            }
            int[] Index = new int[izm];

            Random rand = new Random();
            for (int i = 0; i < elem_count; i++)
            {
                array[i] = rand.Next(MinRange[Index[0]], MaxRange[Index[0]]);
                Index[Index.Length - 1] += 1;

                for (int j = izm - 1; j > 0; j--)
                {
                    if ((Index[j] % izm == 0)&&(Index[j] != 0))
                    {
                        Index[j] = 0;
                        Index[j - 1] += 1;
                    }
                    
                }
            }
            for (int i = 0; i < izm; i++)
            {
                Index[i] = 0;
            }
            for (int i = 0; i < elem_count; i++)
            {

                Console.Write("Элемент под индексом ");
                foreach(int k in Index)
                {
                    Console.Write("{0} ", (k + 1));
                }
                Console.WriteLine(": " + array[i]);
                Index[Index.Length - 1] += 1;
                for (int j = 1; j < izm; j++)
                {
                    if (Index[j] / izm == 1)
                    {
                        Index[j] = 0;
                        Index[j - 1] += 1;
                    }

                }
                for (int j = izm - 1; j > 0; j--)
                {
                    if ((Index[j] % izm == 0) && (Index[j] != 0))
                    {
                        Index[j] = 0;
                        Index[j - 1] += 1;
                    }

                }
            }
        }
    }
}