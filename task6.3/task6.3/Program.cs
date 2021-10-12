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
			switch ((Days) c)
			{
				case Days.Понедельник:
					day = Days.Понедельник;
					Console.WriteLine(day);
					break;
				case Days.Вторник:
					day = Days.Вторник;
					Console.WriteLine(day);
					break;
				case Days.Среда:
					day = Days.Среда;
					Console.WriteLine(day);
					break;
				case Days.Четверг:
					day = Days.Четверг;
					Console.WriteLine(day);
					break;
				case Days.Пятница:
					day = Days.Пятница;
					Console.WriteLine(day);
					break;
				case Days.Суббота:
					day = Days.Суббота;
					Console.WriteLine(day);
					break;
				case Days.Воскресенье:
					day = Days.Воскресенье;
					Console.WriteLine(day);
					break;
				default:
					Console.WriteLine("Вы нажали неизвестную кнопку.");
					break;
			}
		}
	}
}
