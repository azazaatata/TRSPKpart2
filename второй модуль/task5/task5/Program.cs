using System;
using System.Collections.Generic;

namespace task5
{
    class Test
    {
        public int k;
        public Test()
        {
            Random rnd = new Random();
            k = rnd.Next(0, 10);
        }
    }
    internal class Program
    {
        static void Punkt1()
        {
            Console.WriteLine("Введите номер до какого поколения хотите довести переменную(максимальное поколение 2): ");
            int k = Convert.ToInt32(Console.ReadLine());
            k++;
            if (k > 2)
                k = 2;
            Test f = new Test();
            int gen = GC.GetGeneration(f);
            Console.WriteLine("Поколение до чистки мусора: {0}", gen);

            System.Threading.Thread.Sleep(1000);
            Console.Clear();

            for (int i = 0; i < k; i++)
            {
                GC.Collect();
                gen = GC.GetGeneration(f);
                Console.WriteLine("Поколение объекта: {0}", gen);
                Console.WriteLine();
                System.Threading.Thread.Sleep(500);
                if (i < k - 1)
                    Console.Clear();
            }
        }

        static void Punkt2()
        {
            Console.WriteLine("Введите количество проходов цикла: ");
            int count = Convert.ToInt32(Console.ReadLine());
            Test t1 = new Test();
            for (int i = 0; i < count; i++)
            {
                int gen = GC.GetGeneration(t1);
                Console.WriteLine("Поколение переменной созданой до цикла: {0}", gen);
                Test t2 = new Test();
                gen = GC.GetGeneration(t2);
                Console.WriteLine("Поколение переменной созданой в цикле: {0}", gen);
                GC.Collect();
                System.Threading.Thread.Sleep(400);
                Console.Clear();
            }
        }

        static void Punkt3()
        {
            Console.WriteLine("Введите количество проходов цикла: ");
            int count = Convert.ToInt32(Console.ReadLine());
            Test t1 = new Test();
            List<Test> m = new List<Test>();
            for (int i = 0; i < count; i++)
            {
                int gen = GC.GetGeneration(t1);
                Console.WriteLine("Поколение переменной созданой до цикла: {0}", gen);
                Console.WriteLine();

                Test t2 = new Test();
                gen = GC.GetGeneration(t2);
                Console.WriteLine("Поколение переменной созданой в цикле: {0}", gen);
                Console.WriteLine();
                m.Add(t2);


                for (int j = 0; j < m.Count - 1; j++)
                {
                    gen = GC.GetGeneration(m[j]);
                    Console.WriteLine("{0} переменная скопированная в список имеет поколение :{1}", j + 1, gen);
                }
                GC.Collect();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Какой из абзацев выполнить?");
            int choose = Convert.ToInt32(Console.ReadLine());
            if(choose == 1)
                Punkt1();
            else if(choose == 2)
                Punkt2();
            else if(choose == 3)
                Punkt3();
        }
    }
}
