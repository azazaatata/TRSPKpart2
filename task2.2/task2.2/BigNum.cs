using System;
using System.Collections.Generic;
using System.Text;

namespace task2._2
{
    class BigNum
    {
        private string[] num = new string[3];
        private bool[] posit = new bool[3];
        int count = 0;

        public BigNum()
        {
            Console.WriteLine("Two Big Numbers created.");
        }

        public void GivNum(string FNumber)//Ввод чисел
        {
            num[count] = FNumber;
            count++;
            Console.WriteLine("{0} number given.", count);
            positCheck();
        }

        private void positCheck()//Проверка на положительное число
        {
            string s = num[count].Substring(0,2);
            int check = Convert.ToInt32(s);
            if(check < 0) 
            { 
                posit[count] = false;
                num[count] = num[count].Substring(1);
            }
            else
            {
                posit[count] = true;
            }
        }

        private string plus(int Fnum, int Snum)//Функция сложения
        {
            int k;
            bool FLong = false;
            if (num[Fnum].Length >= num[Snum].Length)
            {
                k = num[Snum].Length;
                FLong = true;
            }
            else
            {
                k = num[Fnum].Length;
            }
            int Fsyllable;//Разряд первого слогаемого
            int Ssyllable;//Разряд второго слогаемого
            int Sum;
            string Otv = null;
            int NextDischarge = 0;//Переход в следующий разряд
            for (int i = 0; i < k; i++)
            {
                Fsyllable = Convert.ToInt32(num[num[Fnum].Length - i - 1]);
                Ssyllable = Convert.ToInt32(num[num[Snum].Length - i - 1]);
                Sum = Fsyllable + Ssyllable + NextDischarge;
                Otv.Insert(0, (Sum % 10).ToString());
                NextDischarge = Sum / 10;
            }
            if (FLong)
            {
                for (int i = num[Snum].Length; i < num[Fnum].Length; i++)
                {
                    Fsyllable = Convert.ToInt32(num[num[Fnum].Length - i - 1]) + NextDischarge;
                    Otv.Insert(0, (Fsyllable % 10).ToString());
                    NextDischarge = Fsyllable / 10;
                }
            }
            else
            {
                for (int i = num[Fnum].Length; i < num[Snum].Length; i++)
                {
                    Ssyllable = Convert.ToInt32(num[num[Snum].Length - i - 1]) + NextDischarge;
                    Otv.Insert(0, (Ssyllable % 10).ToString());
                    NextDischarge = Ssyllable / 10;
                }
            }
            return (Otv);
        }

        private string minus(int Fnum, int Snum)//Функция вычитания
        {
            string Otv = null;

            return Otv;
        }

        public void addit(int Fnum, int Snum)//Определение функции, которую необходимо вызвать при сложении
        {
            string outp = null;
            if ((posit[Fnum]) && (posit[Snum]))
            {
                outp = plus(Fnum, Snum);
                Console.WriteLine(outp);
                return;
            }
            if (((posit[Fnum]) && (!posit[Snum])) || ((!posit[Fnum]) && (posit[Snum])))
            {
                if (num[Fnum].Length > num[Snum].Length)
                {
                    subtr(Fnum, Snum);
                }
                else
                {
                    subtr(Snum, Fnum);
                }
                return;
            }
            if ((!posit[Fnum]) && (!posit[Snum]))
            {
                outp = plus(Fnum, Snum);
                Console.WriteLine(outp);
            }
        }

        public void subtr(int Fnum, int Snum)//Определение функции, которую необходимо вызвать при вычитании
        {

        }
    }
}
