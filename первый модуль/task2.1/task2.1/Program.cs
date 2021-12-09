using System;

namespace ConsoleApp1
{
    class Man
    {
        public string name;
        public int age;
        //public void Print()
        // {
        //  Console.WriteLine(string.Format("Имя человека: " + name.ToString() + " Возраст: " + age.ToString()));
        // }

        //Методы изменения полей имя и возраст
        public void changeName(string valueName)
        {
            name = valueName;
            if (valueName.Length == 0)
            {
                Console.WriteLine("Ошибка. Имя не введено! ");
            }
        }
        public virtual void changeAge(int valueAge)
        {
            age = valueAge;
        }

        public virtual void Print()
        {
            Console.WriteLine("Человек: ");
            Console.WriteLine($"Имя : {name}");
            Console.WriteLine($"Возраст : {age}");
        }


    }
    class Teenager : Man
    {
        public string School;
        //Переопределение метода изменения поля возраст
        public override void changeAge(int valueAge)
        {
            base.changeAge(valueAge);
            if (valueAge < 13 || valueAge > 19)
            {
                Console.WriteLine("Ошибка! Ограничение по возрасту");
            }
        }
        //Переопределение метода текстового представления
        public override void Print()
        {
            base.Print();
            Console.WriteLine("Подросток: ");
            Console.WriteLine($"Имя : {name}");
            Console.WriteLine($"Возраст : {age}");
            Console.WriteLine($"Место учебы : {School}");
        }
    }

    class Worker : Man
    {
        string Place_of_work;

        //Переопределение метода изменения поля возраст
        public override void changeAge(int valueAge)
        {
            base.changeAge(valueAge);
            if (valueAge < 16 || valueAge > 70)
            {
                Console.WriteLine("Ошибка! Ограничение по возрасту");
            }
        }

        //Переопределение метода текстового представления
        public override void Print()
        {
            base.Print();
            Console.WriteLine("Работник: ");
            Console.WriteLine($"Имя : {name}");
            Console.WriteLine($"Возраст : {age}");
            Console.WriteLine($"Место работы : {Place_of_work}");
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            var Man1 = new Worker { name = "Василий", age = 20 };
            Man1.changeName("Игорь");
            Man1.changeAge(20);
            Man1.Print();

        }
    }
}