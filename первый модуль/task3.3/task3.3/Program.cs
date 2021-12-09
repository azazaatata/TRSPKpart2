using System;

namespace _3._3
{
    class ArrEl
    {

        private string name;
        private int val;
        public string NameProperty
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int StrIndex(ArrEl[] a)
        {

            return 0;
        }

       
        public int ValProperty
        {
            get
            {
                return val;
            }
            set
            {
                val = value;
            }
        }
        //==================================================================

        public int this[int val] //indexator
        {
            set { array[val] = value; }
            get { return array[val]; }
        }
        public string this[Name] //indexator
        {
            set { array[Name] = value; }
            get { return array[Name]; }
        }


    }
}
// class Array


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
    }
}

