using System;
using System.Collections.Generic;
using System.Text;

namespace task2._2
{
    class BigNum
    {
        private string num = null;
        private bool posit = false;
        int count = 0;

        public BigNum()//конструктор элемента класса
        {
            num = "";
            posit = false;
        }

        public BigNum(BigNum a)
        {
            num = a.num;
            posit = a.posit;
        }

        private bool positCheck(string number)//Проверка на положительное число
        {
            string s =number.Substring(0,2);
            bool pos;
            int check = Convert.ToInt32(s);
            if(check < 0) 
            { 
                pos = false;
                num = num.Substring(1);
            }
            else
            {
                pos = true;
            }
            return pos;
        }
        
        public void ReadBN(string number)
        {
            num = number;
            posit = positCheck(num);
        }

        public void CopyBN(BigNum a)
        {
            num = a.num;
            posit = a.posit;
        }

        public void PrintBN(BigNum print)
        {
            if (posit) { Console.WriteLine(print.num); }
            else { Console.WriteLine("-"+print.num); }
        }
        public static BigNum operator +(BigNum num1, BigNum num2)
        {
            string outp = null;
            string Fnum = num1.num;
            string Snum = num2.num;
            BigNum otv = new BigNum();
            if ((num1.posit) && (num2.posit))
            {
                otv.num = plus(Fnum, Snum);
                otv.posit = num1.posit;
                return otv;
            }
            if ((num1.posit) && (!num2.posit))
            {
                otv.num = minus(Snum, Fnum);
                if (Fnum.Length >= Snum.Length) { otv.posit = num1.posit; }
                else { otv.posit = num2.posit; }
                return otv;
            }
            if ((!num1.posit) && (num2.posit))
            {
                outp = minus(Snum, Fnum);
                if (Fnum.Length >= Snum.Length) { otv.posit = num1.posit; }
                else { otv.posit = num2.posit; }
                return otv;
            }
            otv.num = plus(Fnum, Snum);
            otv.posit = num1.posit;
            return otv;
        }

        public static BigNum operator -(BigNum num1, BigNum num2)
        { 
            BigNum otv = new BigNum();
            if ((num1.posit) && (num2.posit))
            {
                otv.num = minus(num1.num, num2.num);
                if (num1.num.Length >= num2.num.Length) { otv.posit = num1.posit;}
                else { otv.posit = false; }
                return otv;
            }
            if ((!num1.posit) && (!num2.posit))
            {
                otv.num = minus(num1.num, num2.num);
                if (num1.num.Length >= num2.num.Length) { otv.posit = num1.posit; }
                else { otv.posit = true; }
                return otv;
            }
            if ((num1.posit) && (!num2.posit))
            {
                otv.num = plus(num1.num, num2.num);
                otv.posit = num1.posit;
                return otv;
            }
            otv.num = plus(num1.num, num2.num);
            otv.posit = num1.posit;
            return otv;
        }

        public static BigNum operator *(BigNum num1, BigNum num2)
        {
            BigNum otv = new BigNum();
            if((num1.posit)&&(num2.posit))
            {
                otv.num = proizv(num1.num, num2.num);
                otv.posit = num1.posit;
                return otv;
            }
            otv.num = proizv(num1.num, num2.num);
            otv.posit = false;
            return otv;
        }

        public static bool operator ==(BigNum num1, BigNum num2)
        {
            if ((num1.num == num2.num)&&(num1.posit == num2.posit))
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(BigNum num1, BigNum num2)
        {
            if (num1.num != num2.num)
            {
                return true;
            }
            return false;
        }

        private static string plus(string Fnum, string Snum)//Функция сложения
        {
            bool FLong = false;
            if (Fnum.Length > Snum.Length)
            {
                FLong = true;
            }
            if (!FLong)
            {
                string temp = Fnum;
                Fnum = Snum;
                Snum = Fnum;
            }
            int Fsyllable;//Разряд первого слогаемого
            int Ssyllable;//Разряд второго слогаемого
            int Sum;
            string Otv = null;
            int NextDischarge = 0;//Переход в следующий разряд
            for (int i = 0; i < Fnum.Length; i++)
            {
                Fsyllable = Convert.ToInt32(Fnum[Fnum.Length - i - 1]);
                Ssyllable = Convert.ToInt32(Snum[Snum.Length - i - 1]);
                Sum = Fsyllable + Ssyllable + NextDischarge;
                Otv.Insert(0, (Sum % 10).ToString());
                NextDischarge = Sum / 10;
            }
            if (FLong)//Работа с числами когда одно больше другого
            {
                for (int i = Snum.Length; i < Fnum.Length; i++)
                {
                    Fsyllable = Convert.ToInt32(Fnum[Fnum.Length - i - 1]) + NextDischarge;
                    Otv.Insert(0, (Fsyllable % 10).ToString());
                    NextDischarge = Fsyllable / 10;
                }
            }
            else
            {
                for (int i = Fnum.Length; i < Snum.Length; i++)
                {
                    Ssyllable = Convert.ToInt32(Snum[Snum.Length - i - 1]) + NextDischarge;
                    Otv.Insert(0, (Ssyllable % 10).ToString());
                    NextDischarge = Ssyllable / 10;
                }
            }
            return (Otv);
        }

        private static string minus(string Fnum, string Snum)//Функция вычитания
        {
            string Otv = null;
            bool FLong = false;
            if (Fnum.Length > Snum.Length)
            {
                FLong = true;
            }
            if (!FLong)
            {
                string temp = Fnum;
                Fnum = Snum;
                Snum = Fnum;
            }
            int FirstNum = 0;
            int SecondNum = 0;
            int NextDigit = 0;//То что мы будем занимать в след. разряде
            int Sum = 0;
            for (int i = 0; i < Fnum.Length; i++)
            {
                FirstNum = Convert.ToInt32(Fnum[Fnum.Length - i - 1]);
                SecondNum = Convert.ToInt32(Snum[Snum.Length - i - 1]);
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

        public static string proizv(string Fnum, string Snum)//Функция умножения
        {
            int FirstNum = 0;
            int SecondNum = 0;
            int Proiz = 1;
            int NextDigit = 0;
            string Sum1 = null;
            string Sum2 = null;
            SecondNum = Convert.ToInt32(Snum[Snum.Length - 1]);
            for (int i = 0; i < Fnum.Length; i++)
            {
                FirstNum = Convert.ToInt32(Fnum[Fnum.Length - i - 1]);
                Proiz = ((FirstNum * SecondNum) + NextDigit);
                NextDigit = Proiz / 10;
                Sum1.Insert(0, (Proiz % 10).ToString());
            }
            for (int i = 1; i < Snum.Length - 1; i++)
            {
                SecondNum = Convert.ToInt32(Snum[Snum.Length - i - 1]);
                for (int j = 0; j < Fnum.Length; j++)
                {
                    for(int k = 1; k < i; i++)
                    {
                        Sum2.Insert(0, "0");
                    }
                    FirstNum = Convert.ToInt32(Fnum[Fnum.Length - i - 1]);
                    Proiz = ((FirstNum * SecondNum) + NextDigit);
                    Sum2.Insert(0, Proiz.ToString());
                }
                Sum1 = plus(Sum1, Sum2);
            }
            return Sum1;
        }
    }
}
