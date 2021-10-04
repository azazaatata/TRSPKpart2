using System;


namespace Task4
{
    class Program
    {
        class NumberArray
        {
            int[] numbers = new int[] { 20, 4, 76, 3, -6, 12 };
            public int[] Numbers
            {
                get
                {
                    return numbers;
                }
                set
                {
                    numbers = value;
                }

            }

        }
        static void PrintArr(NumberArray number)
        {
            int[] printy = number.Numbers;
            for (int i = 0; i < printy.Length; i++)
            {
                Console.WriteLine(printy[i] + "   ");
            }

        }
        static void Sort1(NumberArray number) //bubblesort 
        {
            int[] arr = number.Numbers;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        int t = arr[i];
                        arr[i] = arr[j];
                        arr[j] = t;
                    }
                }
            }

            number.Numbers = arr;
        }


        static void Sort2(NumberArray number)//InsertionSort
        {
            int[] arr = number.Numbers;

            for (int i = 1; i < arr.Length; i++)
            {
                int curr = arr[i];
                int j = i;
                while (j > 0 && curr < arr[j - 1])
                {
                    arr[j] = arr[j - 1];
                    j--;
                }
                arr[j] = curr;

            }
            number.Numbers = arr;
        }



        void Sort3(NumberArray number) //PiraSort
        {

            int[] arr = number.Numbers;








        }

        static void Main(string[] args) //лиза не тереби дао
        {
            NumberArray a = new NumberArray();
            Sort2(a);
            PrintArr(a);
            Console.ReadKey();


        }
    }


}