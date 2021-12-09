using System;
using System.IO;

namespace task5._2
{
    internal class Program
    {
        static void ChooseSize()
        {
            int count = 0;
            while(true)
            {
                count++;
                Console.WriteLine("Размер переменной в байтах: {0}",count);
                bool[] trash = new bool[count];
                int gen = GC.GetGeneration(trash);
                Console.WriteLine("Поколение созданной переменной: {0}", gen);
                if (gen == 2)
                    break;
            }
        }
        static void BigTrash()
        {
            int k = 6000;
            decimal[] m = new decimal[k];

            Console.WriteLine("Сколько сборок мусора провести?");
            int count = Convert.ToInt32(Console.ReadLine());

            int gen = GC.GetGeneration(m);
            Console.WriteLine("Поколение объекта до сборки мусора: {0}", gen);

            for (int i = 0; i < count; i++)
            {
                gen = GC.GetGeneration(m);
                Console.WriteLine("Поколение после {0} сборки мусора: {1}", i + 1, gen);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите абзац:");
            int choose = Convert.ToInt32(Console.ReadLine());
            if (choose == 1)
                ChooseSize();
            else if(choose == 2)
                BigTrash();
            
        }
    }
}
