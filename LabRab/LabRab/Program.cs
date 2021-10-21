using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LabRab
{
	class Train
	{
		int id { get; set; }
		int RouteId { get; set; }
		int StartStation { get; set; }
		int FinishStation { get; set; }
		int TimeStart { get; set; }

		public void CreateTrain()
        {
			id = 
        }
    }

	class Station
    {
		int id;
		string Name;
		int RouteId;
    }

	class Route
    {
        int id;
		int Name;
    }

	class Passenger
    {
		int id;
		int Name;
		int Age;
		int TicketId;
    }

	class Ticket
    {
		int id;
		int PassId;
		int StartStation;
		int FinishStation;
		int TrainId;
    }
	class Program
	{
		void zapolnenie()
        {
			FileStream file1 = new FileStream("C:\\Laborat\\Train.txt", FileMode.Open); //создаем файловый поток
			StreamReader reader = new StreamReader(file1); // создаем «потоковый читатель» и связываем его с файловым потоком
			string str1 = reader.ReadLine(); //считываем все данные с потока и выводим на экран
			int count = Convert.ToInt32(str1);
			Train[] trains = new Train[count];
			Train t = new Train();
			reader.Close(); //закрываем поток



			file1 = new FileStream("C:\\Laborat\\Station.txt", FileMode.Open); //создаем файловый поток
			reader = new StreamReader(file1); // создаем «потоковый читатель» и связываем его с файловым потоком
			str1 = reader.ReadLine(); //считываем все данные с потока и выводим на экран
			reader.Close(); //закрываем поток
			count = Convert.ToInt32(str1);

			file1 = new FileStream("C:\\Laborat\\Passenger.txt", FileMode.Open); //создаем файловый поток
			reader = new StreamReader(file1); // создаем «потоковый читатель» и связываем его с файловым потоком
			str1 = reader.ReadLine(); //считываем все данные с потока и выводим на экран
			reader.Close(); //закрываем поток
			count = Convert.ToInt32(str1);

			file1 = new FileStream("C:\\Laborat\\Ticket.txt", FileMode.Open); //создаем файловый поток
			reader = new StreamReader(file1); // создаем «потоковый читатель» и связываем его с файловым потоком
			str1 = reader.ReadLine(); //считываем все данные с потока и выводим на экран
			reader.Close(); //закрываем поток
			count = Convert.ToInt32(str1);

			file1 = new FileStream("C:\\Laborat\\Route.txt", FileMode.Open); //создаем файловый поток
			reader = new StreamReader(file1); // создаем «потоковый читатель» и связываем его с файловым потоком
			str1 = reader.ReadLine(); //считываем все данные с потока и выводим на экран
			reader.Close(); //закрываем поток
			count = Convert.ToInt32(str1);

		}

		static void Main(string[] args)
		{
			FileStream file1 = new FileStream("C:\\test.txt", FileMode.Open); //создаем файловый поток
			StreamReader reader = new StreamReader(file1); // создаем «потоковый читатель» и связываем его с файловым потоком
			string str1 = reader.ReadLine(); //считываем все данные с потока и выводим на экран
			reader.Close(); //закрываем поток
            Console.WriteLine(str1);
			Console.ReadLine();
		}
	}
}
