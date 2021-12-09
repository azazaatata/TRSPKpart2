using System;

class Program
{
	[Flags]
	enum team
	{
		None,
		Даня,
		Эдгар,
		Наташа,
		Валя,
		Тарас,
		Олег
	}

	static void Main()
	{
		string value;
		Console.WriteLine("Введите имя:");
		value = Console.ReadLine();
		team teammate;
		try
		{
			teammate = Enum.Parse<team>(value);
		}
		catch (Exception e)
		{
			Console.WriteLine("Ошибка");
			teammate = team.None;
		}
		
		if (teammate == team.None)
		{
			Console.WriteLine("Не член команды");
			return;
		}
		switch (teammate)
		{
			case team.Даня:
				Console.WriteLine("Капитан команды");
				break;
			case team.Олег:
				Console.WriteLine("Жаба");
				break;
			default:
				Console.WriteLine("Не капитан команды");
				break;
		}
	}
}