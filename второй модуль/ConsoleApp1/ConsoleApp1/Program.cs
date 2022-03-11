using System;

namespace ConsoleApplication1
{
    class FinalizeObject
    {
        public int id { get; set; }

        public FinalizeObject(int id)
        {
            this.id = id;
        }

        // Создадим специальный деструктор
        ~FinalizeObject()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Объект №{0} уничтожен", id);
            Console.Beep();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Read();
            // После того как будет нажата клавиша Enter (выход из программы)
            // все последующие объекты будут уничтожены

            FinalizeObject[] obj = new FinalizeObject[100];
            for (int i = 0; i < 100; i++)
                obj[i] = new FinalizeObject(i);
        }
    }
}