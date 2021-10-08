using System;
using System.IO;

namespace task4._5
{
    class KeyboardManager
    {
        public delegate void KeyLogger(char k);
        public delegate void KeyPressed();

        public event KeyPressed ThreeKeyPressed;
        public event KeyPressed FiveKeyPressed;
        public event KeyPressed DigitKeyPressed;
        public event KeyLogger AnyKeyPressed;

        public void Pressed(char k)
        {
            AnyKeyPressed(k);
            if (k == '3')
            {
                ThreeKeyPressed();
                return;
            }
            if (k == '5')
            {
                FiveKeyPressed();
                return;
            }
            if (k>47 && k<58)
            {
                DigitKeyPressed();
                return;
            }
        }
    }

    class ThreeSubscriber
    {
        public void ThreePressed()
        {
            Console.WriteLine("[Three]");
        }
    }


    class FiveSubcriber
    {
        public void FivePressed()
        {
            Console.WriteLine("[Five]");
        }
    }

    class DigitSubscriber
    {
        public void DigitPressed()
        {
            Console.WriteLine("[Digit]");
        }
    }

    class LogSubscriber
    {
        StreamWriter sw = new StreamWriter("C:\\Users\\User\\Desktop\\log.txt");

        public void AnyPressed(char k)
        {
            if(k == '=')
            {
                sw.Close();
                return;
            }
            Console.Write("Pressed key: {0} ", k);
            sw.Write(k);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            KeyboardManager k = new();
            char key;
            ThreeSubscriber ThSu = new();

        }
    }
}
