using System;

namespace task1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа предназначена для работы с массивом(списком) строк.");
            var list = new StringList();
            while (true)
            {
                int ch = 0;
                Console.WriteLine("Введите одну из цифр указаных ниже для выполнения дейстий с массивом(списком).");
                Console.WriteLine("1. Вставить элемент в конец массива(список).");
                Console.WriteLine("2. Удалить элемент с определенным индексом в массиве(списке).");
                Console.WriteLine("3. Поиск по содержанию элемента в массиве(списке).");
                Console.WriteLine("4. Обновить содержание элемента с определенным индексом.");
                Console.WriteLine("5. Вывести элемент массива(списка) с определенным индексом.");
                Console.WriteLine("6. Вывести весь массив(список).");
                Console.WriteLine("7. Exit.");
                ch = Convert.ToInt32(Console.ReadLine());
                if (ch == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Введите элемент, который хотите добавить в массив(список):");
                    string vvod = Console.ReadLine();
                    int code = list.Insert(vvod);
                    if (code == -1)
                    {
                        Console.WriteLine("Массив(список) переполнен. Удалите один из элементов.");
                    }
                    else
                    {
                        Console.WriteLine("Элемент был добавлен в массив. Его индекс : {0}", code);
                    }
                }
                else if (ch == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Введите индекс элемента, который хотите удалить: ");
                    int index = Convert.ToInt32(Console.ReadLine());
                    list.Delete(index);
                }
                else if (ch == 3)
                {
                    Console.Clear();
                    Console.WriteLine("Введите текст, который хотите найти в массиве(списке): ");
                    string sear = Console.ReadLine();
                    int code = list.Search(sear);
                    if (code == -2)
                    {
                        Console.WriteLine("Массив(список) пустой, заполните его элементами.");
                    }
                    else if (code == -1)
                    {
                        Console.WriteLine("По заданному тексту, не удалось найти элемент в массиве.");
                    }
                    else
                    {
                        Console.WriteLine("Элемент найден, его индекс: {0}", code);
                    }
                }
                else if (ch == 4)
                {
                    Console.Clear();
                    Console.WriteLine("Введите индекс элемента, который хотите изменить: ");
                    int upd = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите строку, которую хотите поместить в этот элемент: ");
                    string text = Console.ReadLine();
                    list.Update(upd, text);
                }
                else if (ch == 5)
                {
                    Console.Clear();
                    Console.WriteLine("Введите индекс элемента, который хотите вывести: ");
                    int vivod = Convert.ToInt32(Console.ReadLine());
                    list.GetAt(vivod);
                }
                else if (ch == 6)
                {
                    Console.Clear();
                    list.PrintAll();
                }
                else if (ch == 7)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Вы ввели число, которого нет в списке.");
                }    
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
