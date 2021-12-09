using System;

namespace task6._3
{
	class Program
	{
		public enum Days
		{
		Понедельник = 1,
		Вторник,
		Среда,
		Четверг,
		Пятница,
		Суббота,
		Воскресенье
		}
		static void Main(string[] args)
		{
			Console.WriteLine("Введите порядковый номер дня недели:");
			int c = Convert.ToInt32(Console.ReadLine());
			Days day;
			if (c>7 || c<1)
				Console.WriteLine("Неверный день недели");
			else
			{
				day = (Days)c;
				Console.WriteLine(day);
			}
		}
	}
}
