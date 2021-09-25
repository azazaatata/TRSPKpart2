using System;
using System.Collections.Generic;
using System.Text;

namespace task2._2
{
    class BigNum
    {
        private string num = null;
        private bool posit = false;

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

        public static BigNum operator /(BigNum num1, BigNum num2)
        {
            return delenie(num1, num2);
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

        public static bool operator >(BigNum num1, BigNum num2)
        {
            if (((num1.posit) && (!num2.posit)) || (((num1.posit) && (num2.posit))&&(num1.num.Length > num2.num.Length)) || (((!num1.posit) && (!num2.posit)) && (num1.num.Length < num2.num.Length)))
            {
                return true;
            }
            if ((!num1.posit) && (num2.posit)|| (((num1.posit) && (num2.posit))&&(num1.num.Length < num2.num.Length)) || (((!num1.posit) && (!num2.posit)) && (num1.num.Length > num2.num.Length)))
            {
                return false;
            }
            int Fnum = 0;
            int Snum = 0;
            bool bolshe = false;
            for(int i = 0; i<num1.num.Length;i++)
            {
                Fnum = Convert.ToInt32(num1.num[i]);
                Snum = Convert.ToInt32(num2.num[i]);
                if(Fnum>Snum)
                {
                    bolshe = true;
                    break;
                }
            }
            return bolshe;
        }

        public static bool operator <(BigNum num1, BigNum num2)
        {
            if (((num1.posit) && (!num2.posit)) || ((num1.posit) && (num2.posit) && (num1.num.Length > num2.num.Length)) || (((!num1.posit) && (!num2.posit)) && (num1.num.Length < num2.num.Length)))
            {
                return false;
            }
            if ((!num1.posit) && (num2.posit) || ((num1.posit) && (num2.posit) && (num1.num.Length < num2.num.Length)) || (((!num1.posit) && (!num2.posit)) && (num1.num.Length > num2.num.Length)))
            {
                return true;
            }
            int Fnum = 0;
            int Snum = 0;
            bool bolshe = false;
            for (int i = 0; i < num1.num.Length; i++)
            {
                Fnum = Convert.ToInt32(num1.num[i]);
                Snum = Convert.ToInt32(num2.num[i]);
                if (Fnum > Snum)
                {
                    bolshe = true;
                    break;
                }
            }
            return bolshe;
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

        private static string proizv(string Fnum, string Snum)//Функция умножения
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

        private static BigNum delenie(BigNum Fnum, BigNum Snum)
        {
            BigNum one = new BigNum();
            one.num = "1";
            one.posit = true;
            BigNum zero = new BigNum();
            zero.num = "0";
            one.posit = true;
            BigNum otvet = new BigNum();
            otvet.posit = true;
            BigNum delimoe = new BigNum();
            BigNum delitel = new BigNum();
            delitel.num = Snum.num;
            delitel.posit = Snum.posit;
            int i = delitel.num.Length;
            delimoe.num = Fnum.num.Substring(0, delitel.num.Length);
            delimoe.posit = Fnum.posit;
            BigNum counter = new BigNum();
            counter = zero;
            while (true)
            {
                if(delimoe > delitel)
                {
                    delimoe = delimoe - delitel;
                    counter = counter + one;
                }
                else if((i < Fnum.num.Length)&&(delimoe < delitel))
                {
                    delimoe.num.Insert(delimoe.num.Length, Fnum.num.Substring(i, i + 1));
                    i++;
                    otvet.num.Insert(otvet.num.Length, counter.num);
                    counter = zero;
                }
                else
                {
                    break;
                }
            }
            if (((Fnum.posit)&&(!Snum.posit))||((!Fnum.posit)&&(Snum.posit)))
            {
                otvet.posit = false;
            }
            return otvet;
        }

        public BigNum StrToBigNum(string stroka)
        {
            BigNum Str = new BigNum();
            string st = stroka;
            Str.num = stroka;
            Str.posit = positCheck(st);
            return Str;
        }

        public BigNum StrBuildToBigNum(StringBuilder stroka)
        {
            string perevod = stroka.ToString();
            BigNum StrBuild = new BigNum();
            StrBuild = StrToBigNum(perevod);
            return StrBuild;
        }

        public bool TryParse(string stroka, out BigNum chislo)
        {
            string slovar = "-01234567890";
            bool parse = false;
            BigNum tut = new BigNum();
            if((stroka[0]==slovar[0])|| (stroka[0] == slovar[1]) || (stroka[0] == slovar[2]) || (stroka[0] == slovar[3]) || (stroka[0] == slovar[4]) || (stroka[0] == slovar[5]) || (stroka[0] == slovar[6]) || (stroka[0] == slovar[7]) || (stroka[0] == slovar[8]) || (stroka[0] == slovar[9]) || (stroka[0] == slovar[10]))
            {
                for(int i = 1; i<stroka.Length;i++)
                {
                    for(int j = 1; j<slovar.Length; j++)
                    {
                        if ((stroka[i] == slovar[1]) || (stroka[i] == slovar[2]) || (stroka[i] == slovar[3]) || (stroka[i] == slovar[4]) || (stroka[i] == slovar[5]) || (stroka[i] == slovar[6]) || (stroka[i] == slovar[7]) || (stroka[i] == slovar[8]) || (stroka[i] == slovar[9]) || (stroka[i] == slovar[10]))
                        {
                            parse = true;

                        }
                        else
                        {
                            parse = false;
                        }
                    }
                }
            }
            if (parse)
            {
                tut = StrToBigNum(stroka);
                chislo = tut;
                return parse;
            }
            chislo = tut;
            return parse;
        }
    }
}
