using System;

namespace abc
{
    class Program
    {
        static bool Check(int[] arr)//Проверка на упорядоченность
        {
            bool sorted = false;
            for(int i = 0; i < arr.Length - 1 ;i++)
            {
                if(arr[i]<arr[i+1])
                    sorted = true;
                else
                {
                    sorted = false;
                    break;
                }
            }
            return sorted;
        }
        static void MonteCarlo(int[] arr)//Сортировка массива методом Монте-Карло
        {
            Random rand = new Random();
            while(true)
            {
                int one = rand.Next(0, arr.Length);
                int two = rand.Next(0, arr.Length);
                if(one != two)
                {
                    int temp = arr[one];
                    arr[one] = arr[two];
                    arr[two] = temp;
                    break;
                }
                else
                {
                    one = rand.Next(0, arr.Length);
                    two = rand.Next(0, arr.Length);
                }
            }
            
        }

        static void LasVegas(int[] arr)//Сортировка массива методом Лас-Вегаса
        {
            bool OK = false;
            while(!OK)
            {
                MonteCarlo(arr);
                OK = Check(arr);
            }
        }

        static void Vvod(int[] arr)//Ввод массива с клавиатуры
        {
            for (int i = 0; i < arr.Length; i++)
                arr[i] = Convert.ToInt32(Console.ReadLine());
        }

        static void RandInput(int[] arr)//Заполнение массива случайными числами
        {
            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++)
                arr[i] = rand.Next(-30, 30);
        }

        static void PrintArr(int[] arr)//Вывод массива
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int len;
            Console.WriteLine("Введите длинну массива:");
            len = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[len];
            Console.Clear();
            Console.WriteLine("Как хотите заполнить массив?");
            Console.WriteLine("1.Рандомно");
            Console.WriteLine("2.С клавиатуры");
            int ch = Convert.ToInt32(Console.ReadLine());
            if (ch == 1)
                RandInput(array);
            else if (ch == 2)
                Vvod(array);
            else
            {
                Console.WriteLine("Введено неверное значение");
                return;
            }
                
            Console.Clear();
            Console.WriteLine("Как хотите отсортировать массив?");
            Console.WriteLine("1.Методом Монте-Карло");
            Console.WriteLine("2.Методом Лас-Вегаса");
            ch = Convert.ToInt32(Console.ReadLine());
            if (ch == 1)
            {
                MonteCarlo(array);
                bool sorted = false;
                sorted = Check(array);
                if (!sorted)
                {
                    Console.WriteLine("Не удалось отсортировать массив");
                }

            }
                
            else if (ch == 2)
                LasVegas(array);
            else
            {
                Console.WriteLine("Введено неверное значение");
                return;
            }
            Console.WriteLine("Массив после выполнения алгоритма:");
            PrintArr(array);
            Console.WriteLine("Спасибо за использование нашей программы.");
        }
    }
}
