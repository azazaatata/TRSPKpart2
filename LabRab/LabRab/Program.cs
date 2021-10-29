using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Train_Lab
{
	public class Programa
	{
		public static void Main(string[] args)
		{
			int[] counts = new int[6];
			FileStream file1 = new FileStream("C:\\Laborat\\Counts.txt", FileMode.Open); //создаем файловый поток
			StreamReader reader = new StreamReader(file1); // создаем «потоковый читатель» и связываем его с файловым потоком

			string str1 = reader.ReadLine(); //считываем все данные с потока и выводим на экран
			string read;
			for (int i = 0; i < counts.Length; i++)
			{
				read = reader.ReadLine();
				counts[i] = Convert.ToInt32(read);
			}

			reader.Close(); //закрываем поток

			Trip[] trips = new Trip[counts[0]];
			Station[] stations = new Station[counts[1]];
			Direction[] directions = new Direction[counts[2]];
			Passenger[] passengers = new Passenger[counts[3]];
			Ticket[] tickets = new Ticket[counts[4]];
			Route[] routes = new Route[counts[5]];

			Menu.menu(trips, stations, directions, passengers, tickets, routes, counts);
			
		}
	}
}