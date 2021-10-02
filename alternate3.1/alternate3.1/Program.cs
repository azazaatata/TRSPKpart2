using System;

namespace alternate3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");
            int izm = Convert.ToInt32(Console.ReadLine());
            int[] UpperBounds = new int[izm];
            int[] LowerBounds = new int[izm];
            int[] len = new int[izm];
            for(int i = 0; i < izm; i++)
            {
                Console.WriteLine("");
                UpperBounds[i] = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");
                LowerBounds[i] = Convert.ToInt32(Console.ReadLine());
                len[i] = UpperBounds[i] - LowerBounds[i];
            }
            Random rand = new Random();
            Array arr = Array.CreateInstance(typeof(int), len, LowerBounds);
        }
    }
}
