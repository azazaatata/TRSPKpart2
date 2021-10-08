using System;
using System.IO;

namespace task4._5
{
    

    class Program
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
                if (k > 47 && k < 58)
                {
                    DigitKeyPressed();
                    return;
                }
                Console.WriteLine();
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
            StreamWriter log = new StreamWriter("C:\\Users\\azaza\\Desktop\\log.txt");

            public void AnyPressed(char k)
            {
                if (k == '-')
                {
                    log.Close();
                    return;
                }
                Console.Write("Pressed key: {0} ", k);
                log.Write(k);
            }
        }

        static void Main(string[] args)
        {
            KeyboardManager k = new();
            ThreeSubscriber ThSu = new();
            k.ThreeKeyPressed += ThSu.ThreePressed;
            FiveSubcriber FiSu = new();
            k.FiveKeyPressed += FiSu.FivePressed;
            DigitSubscriber DiSu = new();
            k.DigitKeyPressed += DiSu.DigitPressed;
            LogSubscriber LoSu = new();
            k.AnyKeyPressed += LoSu.AnyPressed;

            char key;
            while(true)
            {
                key = Console.ReadKey(true).KeyChar;
                k.Pressed(key);
                if (key == '-')
                    break;
            }

        }
    }
}
