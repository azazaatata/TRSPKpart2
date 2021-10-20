using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LabRab
{
	class Program
	{
		static void Main(string[] args)
		{
			FileStream file1 = new FileStream("F:\\test.txt", FileMode.Open); //создаем файловый поток
			StreamReader reader = new StreamReader(file1); // создаем «потоковый читатель» и связываем его с файловым потоком
			Console.WriteLine(reader.ReadLine()); //считываем все данные с потока и выводим на экран
			reader.Close(); //закрываем поток
			Console.ReadLine();
		}
	}
}
