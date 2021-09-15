using System;

namespace task1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool Generated = false;
            while (true)
            {
                int ch = 0;
                Console.WriteLine("Программа предназначена для работы с массивом(списком) строк.");
                Console.WriteLine("Введите одну из цифр указаных ниже для выполнения дейстий с массивом(списком).");
                Console.WriteLine("1. Создать массив(список) строк.");
                Console.WriteLine("2. Вставить элемент в конец массива(список).");
                Console.WriteLine("3. Удалить элемент с определенным индексом в массиве(списке).");
                Console.WriteLine("4. Поиск по содержанию элемента в массиве(списке).");
                Console.WriteLine("5. Обновить содержание элемента с определенным индексом.");
                Console.WriteLine("6. Вывести элемент массива(списка) с определенным индексом.");
                Console.WriteLine("7. Вывести весь массив(список).");
                if ((ch == 1)&&(Generated == false))
                {
                    StringList a = new StringList();
                    Console.WriteLine("Массив(список) строк размером в 100 элементов создан.");
                }
                else if((ch == 1)&&(Generated == true))
                {
                    Console.WriteLine("Массив(список) уже создан.");
                }

            }
        }
    }
}
