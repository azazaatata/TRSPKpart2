using System;
using System.IO;

namespace task5._2
{
    class Trash
    {
        static public bool[] oneByte;
        public Trash(int k)
        {
            oneByte = new bool[k];
        }
    }
    internal class Program
    {
        static void ChooseSize()
        {
            while(true)
            {
                Console.WriteLine("Введите размер в байтах для создаваемой переменной(если хотите выйти введите 0) : ");
                int count = Convert.ToInt32(Console.ReadLine());
                if(count == 0)
                    break;

                Trash check = new Trash(count);
                int gen = GC.GetGeneration(Trash.oneByte);
                Console.WriteLine("Поколение созданной переменной: ");
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
            BigTrash();
        }
    }
}
