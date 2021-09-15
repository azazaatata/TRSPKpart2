using System;
using System.Collections.Generic;
using System.Text;

namespace task1._1
{
    class StringList
    {
        private string[] Str = new string[100];
        int k = 0;
        public StringList()
        {
            Console.WriteLine("Массив строк создан.");
        }
        public int Insert(string ins)
        {
            int num = 0;
            if ((k == 0) && (Str[0] == null))
            { 
                Str[k] = ins;
            }
            else if(k==99)
            {
                num = -1;
            }
            else
            {
                Str[k + 1] = ins;
                k++;
                num = k;
            }
            return num;
        }
        public void Delete(int del)
        {
            if ((k == 0) && (Str[0] == null))
            {
                Console.WriteLine("Массив уже пустой.");
            }
            else if((del>99)||(del<0))
            {
                Console.WriteLine("Вы вышли за предел массива.");
            }
            else if(Str[del]==null)
            {
                Console.WriteLine("Элемент пустой.");
            }
            else
            {
                if (k > del)
                {
                    Str[del] = Str[del + 1];
                    Delete(del + 1);
                }
                else
                {
                    k--;
                    Str[del] = null;
                }
                Console.WriteLine("Элемент удален.");
            }
        }
        public int Search(string ser)
        {
            int ret = -1;
            bool ok = false;
            if ((k == 0) && (Str[0] == null))
            {
                ret = -2;
            }
            else
            {
                foreach (string k in Str)
                {
                    if (k == ser)
                    {
                        ok = true;
                        break;
                    }
                    ret++;
                }
            }
            if (ok == false)
            {
                ret = -1;
            }
            return ret;
        }
        public void Update(int up, string ch)
        {
            if ((k == 0) && (Str[0] == null))
            {
                Console.WriteLine("Массив пустой.");
            }
            else if (up <= k)
            {
                Str[up] = ch;
                Console.WriteLine("Элемент обновлен.");
            }
            else
            {
                Console.WriteLine("Указанный индекс находится за границами массива или элмент пустой.");
            }
        }
        public void GetAt(int ou)
        {
            if((k == 0) && (Str[0] == null))
            {
                Console.WriteLine("Массив пустой.");
            }
            else if ((ou > 99) || (ou < 0))
            {
                Console.WriteLine("Указанный индекс находится за границами массива.");
            }
            else if (ou > k)
            {
                Console.WriteLine("Элемент, который вы хотите вывести пустой.");
            }
            else
            {
                Console.WriteLine("Элемент под индексом{0}, содержит следующую строку: "+Str[ou], ou);
            }
        }
    }
}
