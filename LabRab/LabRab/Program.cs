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

			//string str1 = reader.ReadLine(); //считываем все данные с потока и выводим на экран
			string read;
			for (int i = 0; i < counts.Length; i++)
			{
				read = reader.ReadLine();
				counts[i] = Convert.ToInt32(read);
			}

			reader.Close(); //закрываем поток

			Trip[] trips = new Trip[counts[0]];

			for (int i = 0; i < trips.Length; i++)
				trips[i] = new Trip();

			Station[] stations = new Station[counts[1]];

			for (int i = 0; i < stations.Length; i++)
				stations[i] = new Station();

			Direction[] directions = new Direction[counts[2]];

			for (int i = 0; i < directions.Length; i++)
				directions[i] = new Direction();
				
			Passenger[] passengers = new Passenger[counts[3]];

			for (int i = 0; i < passengers.Length; i++)
				passengers[i] = new Passenger();

			Ticket[] tickets = new Ticket[counts[4]];

			for (int i = 0; i < tickets.Length; i++)
				tickets[i] = new Ticket();

			Console.WriteLine(counts[5]);
			Route[] routes = new Route[counts[5]];

			for (int i = 0; i < routes.Length; i++)
				routes[i] = new Route();


			Console.WriteLine(trips.Length);
			Menu.menu(trips, stations, directions, passengers, tickets, routes, counts);
			
		}
	}
}