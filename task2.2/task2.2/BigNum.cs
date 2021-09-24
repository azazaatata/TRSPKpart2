using System;
using System.Collections.Generic;
using System.Text;

namespace task2._2
{
    class BigNum
    {
        private string[] num = new string[100];
        private bool[] posit = new bool[100];
        int count = 0;

        public BigNum()//конструктор элемента класса
        {
            Console.WriteLine("Big Numbers created.");
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
            bool FLong = false;
            if (num[Fnum].Length > num[Snum].Length)
            {
                FLong = true;
            }
            if (!FLong)
            {
                int temp = Fnum;
                Fnum = Snum;
                Snum = Fnum;
            }
            int Fsyllable;//Разряд первого слогаемого
            int Ssyllable;//Разряд второго слогаемого
            int Sum;
            string Otv = null;
            int NextDischarge = 0;//Переход в следующий разряд
            for (int i = 0; i < num[Fnum].Length; i++)
            {
                Fsyllable = Convert.ToInt32(num[num[Fnum].Length - i - 1]);
                Ssyllable = Convert.ToInt32(num[num[Snum].Length - i - 1]);
                Sum = Fsyllable + Ssyllable + NextDischarge;
                Otv.Insert(0, (Sum % 10).ToString());
                NextDischarge = Sum / 10;
            }
            if (FLong)//Работа с числами когда одно больше другого
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
            bool FLong = false;
            if (num[Fnum].Length > num[Snum].Length)
            {
                FLong = true;
            }
            if (!FLong)
            {
                int temp = Fnum;
                Fnum = Snum;
                Snum = Fnum;
            }
            int FirstNum = 0;
            int SecondNum = 0;
            int NextDigit = 0;//То что мы будем занимать в след. разряде
            int Sum = 0;
            for (int i = 0; i < num[Fnum].Length; i++)
            {
                FirstNum = Convert.ToInt32(num[num[Fnum].Length - i - 1]);
                SecondNum = Convert.ToInt32(num[num[Snum].Length - i - 1]);
                Sum = FirstNum - SecondNum + NextDigit;
                if (Sum < 0)
                {
                    NextDigit = -1;
                    Sum = 10 - Sum;
                }
                Otv.Insert(0, Sum.ToString());
            }
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
            if ((posit[Fnum]) && (!posit[Snum]))
            {
                outp = minus(Snum, Fnum);
                if (num[Fnum].Length >= num[Snum].Length) { Console.WriteLine(outp); }
                else { Console.WriteLine("-" + outp); }
                return;
            }
            if ((!posit[Fnum]) && (posit[Snum]))
            {
                outp = minus(Snum, Fnum);
                if (num[Fnum].Length >= num[Snum].Length) { Console.WriteLine("-" + outp); }
                else { Console.WriteLine(outp); }
                return;
            }
             outp = plus(Fnum, Snum);
             Console.WriteLine("-"+outp);
        }

        public void subtr(int Fnum, int Snum)//Определение функции, которую необходимо вызвать при вычитани
        {
            string outp;
            if ((posit[Fnum]) && (posit[Snum]))
            {
                outp = minus(Fnum, Snum);
                if(num[Fnum].Length >= num[Snum].Length) { Console.WriteLine(outp);}
                else { Console.WriteLine("-" + outp);}
                return;
            }
            if ((!posit[Fnum])&&(!posit[Snum]))
            {
                outp = minus(Fnum, Snum);
                if (num[Fnum].Length >= num[Snum].Length) { Console.WriteLine("-" + outp);}
                else { Console.WriteLine(outp);}
                return;
            }
            if((posit[Fnum])&&(!posit[Snum]))
            {
                outp = plus(Fnum, Snum);
                Console.WriteLine(outp);
                return;
            }
            outp = plus(Fnum, Snum);
            Console.WriteLine("-" + outp);
        }

        public void proizv(int Fnum, int Snum)//Функция умножения
        {
            int FirstNum = 0;
            int SecondNum = 0;
            int Proiz = 1;
            int mnoj = 1;//переход по разрядам
            int NextDigit = 0;
            string Otv = null;
            string Sum1 = null;
            string Sum2 = null;
            SecondNum = Convert.ToInt32(num[num[Snum].Length - 1]);
            for (int i = 0; i <num[Fnum].Length;i++)
            {
                FirstNum = Convert.ToInt32(num[num[Fnum].Length - i - 1]);
                Proiz = ((FirstNum * SecondNum) + NextDigit);
                NextDigit = Proiz / 10;
                Sum1.Insert(0, (Proiz%10).ToString());
            }
            for(int i = 1; i < num[Snum].Length-1; i++)
            {
                SecondNum = Convert.ToInt32(num[num[Snum].Length - i - 1]);
                for (int j = 0; j < num[Fnum].Length; j++)
                {
                    FirstNum = Convert.ToInt32(num[num[Fnum].Length - i - 1]);
                    Proiz = ((FirstNum * SecondNum) + NextDigit);
                    Sum2.Insert(0, Proiz.ToString());
                    Sum1
                }
            }
        }
        
        public void multiplic(int Fnum, int Snum)//Функция вывода значения после умножения
        {

        }
    }
}
