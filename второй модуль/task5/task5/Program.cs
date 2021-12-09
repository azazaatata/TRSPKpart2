using System;

namespace task5
{
    class TrashForHeap
    {
        public int x;
        public int y;
        public int z;
        public TrashForHeap(int X, int Y, int Z)
        {
            x = X;
            y = Y;
            z = Z;
        }
        public void print()
        {
            Console.WriteLine("Координата х:{0}\nКоордината y:{1}\nКоордината z:{2}", x, y, z);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер до какого поколения хотите довести объект(максимальное поколение 2): ");
            int k = Convert.ToInt32(Console.ReadLine());
            k++;
            if (k > 3)
                k = 3;
            

            TrashForHeap trash;
            Random rand = new Random();
            int x, y, z;
            x = rand.Next(0, 10);
            y = rand.Next(0, 10);
            z = rand.Next(0, 10);

            trash = new TrashForHeap(x, y, z);

            Console.WriteLine("Объект trash имеет координаты: ");
            trash.print();
            System.Threading.Thread.Sleep(1000);
            Console.Clear();

            for (int i = 0; i < k; i++)
            {
                int gen = GC.GetGeneration(trash);
                Console.WriteLine("Поколение объекта: {0}", gen);
                Console.WriteLine();
                System.Threading.Thread.Sleep(500);
                Console.Clear();
                GC.Collect();
            }
        }
    }
}
