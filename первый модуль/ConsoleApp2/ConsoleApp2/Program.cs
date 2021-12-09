using System;
using System.ComponentModel;

namespace _6._4
{
	[Flags]
	public enum Numbers
	{
		One = 1,
		Two = 2,
		Three = 4,
		Four = 8,
		Five = 16,
		Six = 32,
	}
	class Program
	{
		static void Main(string[] args)
		{
			var enums = (Numbers.One | Numbers.Two | Numbers.Three |
			             Numbers.Four | Numbers.Five | Numbers.Six).ToString();

			Console.Write("Перечисление: ");
			Console.WriteLine(enums);

			Console.WriteLine("Введите число, которое хотите представить в двоичной системе(от 0 до 63):");
			var inp = Console.ReadLine();
			int check = Convert.ToInt32(inp);
			if (check < 0 || check > 63)
			{
				Console.WriteLine("Ошибка");
				return;
			}
			Console.WriteLine("Программа выведет разряды в которых должна стоять единица");
			Console.WriteLine(Enum.Parse(typeof(Numbers),inp).ToString());
		}
	}
}