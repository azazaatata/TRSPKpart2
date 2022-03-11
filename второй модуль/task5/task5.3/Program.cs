using System;

namespace Task_5_3
{
    internal class Program
    {
        class Murder
        {
            string name = "";
            public int killed = 0;
            decimal[] sru = new decimal[10000];
            public Murder(string n, int k)
            {
                Console.WriteLine("Вызван конструктор убийцы");
                name = n;
                killed = k;
            }
            public void Eat(int i)
            {
                
            }
            ~Murder()
            {
                Console.WriteLine("Убили полисмены");
            }
        }

        static void Main(string[] args)
        {
            string name = "Alan";
            int killed = 15;
            
            //Murder killer = new Murder(name, killed);

            for (int i = 0; i < 1000000; i++)
            {
                Murder killer = new Murder(name, killed);
                GC.Collect();
            }
        }
    }
}