using System;
using System.IO;

namespace Train_Lab
{
	public class BuisnessLogic
	{
		Menu menu = new Menu();
		Trip trip = new Trip();
		Station station = new Station();
		Direction direction = new Direction();
		Passenger passenger = new Passenger();
		Ticket ticket = new Ticket();
		Route route = new Route();

		public static int GetRouteId(Ticket ticketets)
		{
			return ticketets.RouteId;
		}

		//Нахождение наиболее и наименее загруженных направлений

		public static void MaxMinRouteLoaded(Ticket[] tickets, Route[] routes, out int maximus, out int minimus)
		{
			maximus = -1;
			minimus = -1;
			int[] count = new int[routes.Length];
			for (int i = 0; i < tickets.Length; i++)
			{
				count[GetRouteId(tickets[i])]++;
			}

			for (int i = 0; i < count.Length; i++)
			{
				for (int j = 0; j < count.Length; j++)
				{
					if ((i != j) && (count[i] >= count[j]))
					{
						maximus = i;
					}
					else
					{
						break;
					}
				}
			}

			for (int i = 0; i < count.Length; i++)
			{
				for (int j = 0; j < count.Length; j++)
				{
					if ((i != j) && (count[i] <= count[j]))
					{
						minimus = i;
					}
					else
					{
						break;
					}
				}
			}
		}

		public static void MaxMinRouteLoadedOut(Ticket[] tickets, Route[] routes)
		{
			int maximus = 0;
			int minimus = 0;
			MaxMinRouteLoaded(tickets, routes, out maximus, out minimus);
			Console.WriteLine("Наиболее загруженное направление:");
			Menu.PrintR(routes[maximus]);
			Console.WriteLine("Наименее загруженное направление:");
			Menu.PrintR(routes[minimus]);
		}

		//Нахождение кол-ва вышедших или вошедших пассажиров
		public static void TripCountPass(Ticket[] tickets, Trip[] trips, Route[] routes)
		{
			Console.WriteLine("1.Кол-во вышедших пассажиров\n" +
							  "2.Кол-во вошедших пассажиров\n");
			int ch = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Введите id станции: ");
			int sta = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Введите id поездки: ");
			int tri = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Введите id маршрута: ");
			int roid = Convert.ToInt32(Console.ReadLine());

			int otv = 0;
			if (ch == 1)
			{
				otv = TripOutPass(tickets, trips, routes, sta, tri, roid);
			}
			if (ch == 2)
			{
				otv = TripInPass(tickets, trips, routes, sta, tri, roid);
			}
			if ((ch != 1) || (ch != 2) || (otv == -1))
			{
				Console.WriteLine("Ошибка");
				return;
			}
			Console.WriteLine(otv);
		}

		public static bool Out(Ticket T, int stat, int trip)
		{
			if ((T.FinishStation == stat) && (trip == T.TripId))
				return true;
			return false;
		}

		static int TripOutPass(Ticket[] tickets, Trip[] trips, Route[] routes, int Station, int TripId, int RoId)
		{
			int Outc = 0;
			if (!routes[RoId].StatInRouteForOut(Station))
			{
				return -1;
			}
			for (int i = 0; i < tickets.Length; i++)
			{
				if (Out(tickets[i], Station, TripId))
				{
					Outc++;
				}
			}
			return Outc;
		}

		public static bool In(Ticket T, int stat, int trip)
		{
			if ((T.StartStation == stat) && (trip == T.TripId))
				return true;
			return false;
		}

		static int TripInPass(Ticket[] tickets, Trip[] trips, Route[] routes, int Station, int TripId, int RoId)
		{
			int Inc = 0;
			if (!routes[RoId].StatInRouteForIn(Station))
			{
				return -1;
			}
			for (int i = 0; i < tickets.Length; i++)
			{
				if (In(tickets[i], Station, TripId))
				{
					Inc++;
				}
			}
			return Inc;
		}

		//Нахождение среднего кол-ва пассажиров за месяц на определенном направлении
		public static void AvgCountPassOut(Ticket[] tickets, Trip[] trips)
		{
			Console.WriteLine("Введите ID направления: ");
			int id = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Введите месяц: ");
			int mon = Convert.ToInt32(Console.ReadLine());
			Console.Clear();
			Console.WriteLine("Среднее количество пассажиров за {0} месяц: ");
			Console.WriteLine(AvgCountPass(tickets, trips, id, mon));
		}

		static int AvgCountPass(Ticket[] tickets, Trip[] trips, int DirId, int mon)
		{
			int count = 0;
			for (int i = 0; i < tickets.Length; i++)
			{
				if ((trips[tickets[i].TripId].DirectionId == DirId) && (trips[tickets[i].TripId].Month == mon))
				{
					count++;
				}
			}
			count = count / 30;
			return count;
		}

		//Расширение массивов объектов классов на 1 элемент
		public static void AddOneElemTrip(Trip[] trips)
		{
			Array.Resize(ref trips, trips.Length + 1);
		}

		public static void AddOneElemStation(Station[][] stations, int dirid)
		{
			Array.Resize(ref stations[dirid], stations.Length + 1);
		}

		public static void AddOneElemDirection(Direction[] directions)
		{
			Array.Resize(ref directions, directions.Length + 1);
		}

		public static void AddOneElemTicket(Ticket[] tickets)
		{
			Array.Resize(ref tickets, tickets.Length + 1);
		}

		public static void AddOneElemRoute(Route[] routes)
		{
			Array.Resize(ref routes, routes.Length + 1);
		}

		public static void AddOneElemPassenger(Passenger[] passengers)
		{
			Array.Resize(ref passengers, passengers.Length + 1);
		}

		//Добавление элемента в массив элементов классов
		public static void AddTrip(Trip[] trips, int DirId, int TrainSerNum, int IdRoute, int Mon, int Day, int TimeHours, int TimeMinutes)
		{
			AddOneElemTrip(trips);
			Trip newElem = new Trip();
			newElem.AddElem(DirId, TrainSerNum, IdRoute, Mon, Day, TimeHours, TimeMinutes);
			trips[trips.Length - 1] = newElem;
		}

		public static void AddStation(Station[][] stations, int DirId, string Name)
		{
			AddOneElemStation(stations, DirId);
			Station newElem = new Station();
			newElem.AddElem(Name, DirId);
			stations[DirId][stations[DirId].Length - 1] = newElem;
		}

		public static void AddDirection(Direction[] directions, string name)
		{
			AddOneElemDirection(directions);
			Direction newElem = new Direction();
			newElem.AddElem(name);
			directions[directions.Length - 1] = newElem;
		}

		public static void AddPass(Passenger[] passengers, string name1, string name2, int age)
		{
			AddOneElemPassenger(passengers);
			Passenger newElem = new Passenger();
			newElem.AddElem(name1, name2, age);
			passengers[passengers.Length - 1] = newElem;
		}

		public static void AddTicket(Ticket[] tickets, int PassId, int RouteId, int StartStation, int FinishStation, int TripId)
		{
			AddOneElemTicket(tickets);
			Ticket newElem = new Ticket();
			newElem.AddElem(PassId, RouteId, StartStation, FinishStation, TripId);
			tickets[tickets.Length] = newElem;
		}

		public static void AddRoute(Route[] routes, int DirId, int StartStaion, int FinishStation)
		{
			AddOneElemRoute(routes);
			Route newElem = new Route();
			newElem.AddElem(DirId, StartStaion, FinishStation);
			routes[routes.Length] = newElem;
		}

		//Удаление элемента из массива объектов класса
		public static void RemoveTrip(Trip[] trips, int id)
		{
			for (int i = id; i < trips.Length - 1; i++)
			{
				trips[i] = trips[i + 1];
			}
			Array.Resize(ref trips, trips.Length - 1);
		}

		public static void RemoveStation(Station[][] stations, int id1, int id2)
		{
			for (int i = id2; i < stations[id1].Length - 1; i++)
			{
				stations[id1][i] = stations[id1][i + 1];
			}
			Array.Resize(ref stations[id1], stations[id1].Length - 1);
		}

		public static void RemoveDir(Direction[] directions, int id)
		{
			for (int i = id; i < directions.Length - 1; i++)
			{
				directions[i] = directions[i + 1];
			}
			Array.Resize(ref directions, directions.Length - 1);
		}

		public static void RemovePass(Passenger[] passengers, int id)
		{
			for (int i = id; i < passengers.Length - 1; i++)
			{
				passengers[i] = passengers[i + 1];
			}
			Array.Resize(ref passengers, passengers.Length - 1);
		}

		public static void RemoveTicket(Ticket[] tickets, int id)
		{
			for (int i = id; i < tickets.Length - 1; i++)
			{
				tickets[i] = tickets[i + 1];
			}
			Array.Resize(ref tickets, tickets.Length - 1);
		}

		public static void RemoveRoute(Route[] routes, int id)
		{
			for (int i = id; i < routes.Length - 1; i++)
			{
				routes[i] = routes[i + 1];
			}
			Array.Resize(ref routes, routes.Length - 1);
		}

		//Функция записывающая данных в файл при выходе из программы
		public static void WriteInFile(Trip[] trips, Station[][] stations, Direction[] directions, Passenger[] passengers, Ticket[] tickets, Route[] routes)
		{
			StreamWriter sw = new StreamWriter("/home/edgar/C#_projects/LAb_Task/Laborat/Trip.txt", false);
			string str = "";
			for (int i = 0; i < trips.Length; i++)
			{
				str = trips[i].RetStr();
				sw.WriteLine(str);
			}
			sw.Close();

			int k = 0;
			for (int i = 0; i < directions.Length; i++)
			{
				k += stations[i].Length;
			}

			sw = new StreamWriter("/home/edgar/C#_projects/LAb_Task/Laborat/Counts.txt", false);
			int[] count = new int[6];
			count[0] = trips.Length;
			count[1] = k;
			count[2] = directions.Length;
			count[3] = passengers.Length;
			count[4] = tickets.Length;
			count[5] = routes.Length;
			str = "";
			for (int i = 0; i < count.Length; i++)
			{
				str = str.Insert(str.Length, Convert.ToString(count[i]));
				sw.WriteLine(str);
				str = "";
			}
			sw.Close();

			sw = new StreamWriter("/home/edgar/C#_projects/LAb_Task/Laborat/Station.txt", false);
			str = "";
			for (int i = 0; i < directions.Length; i++)
			{
				for (int j = 0; j < stations[i].Length; j++)
				{
					str = stations[i][j].RetStr();
					sw.WriteLine(str);
				}
			}
			sw.Close();

			sw = new StreamWriter("/home/edgar/C#_projects/LAb_Task/Laborat/Direction.txt", false);
			str = "";
			for (int i = 0; i < directions.Length; i++)
			{
				str = directions[i].RetStr();
				sw.WriteLine(str);
			}
			sw.Close();

			sw = new StreamWriter("/home/edgar/C#_projects/LAb_Task/Laborat/Passenger.txt", false);
			for (int i = 0; i < passengers.Length; i++)
			{
				str = passengers[i].RetStr();
				sw.WriteLine(str);
			}
			sw.Close();

			sw = new StreamWriter("/home/edgar/C#_projects/LAb_Task/Laborat/Ticket.txt", false);
			for (int i = 0; i < tickets.Length; i++)
			{
				str = tickets[i].RetStr();
				sw.WriteLine(str);
			}
			sw.Close();

			sw = new StreamWriter("/home/edgar/C#_projects/LAb_Task/Laborat/Routes.txt", false);
			for (int i = 0; i < routes.Length; i++)
			{
				str = routes[i].RetStr();
				sw.WriteLine(str);
			}
			sw.Close();
		}

		//Конвертирование обычного массива в зубчатый
		public static void ConvertArrToArrArr(int[] counts, Station[] stations, Station[][] RouStat)
		{


			int count = 0;
			for (int j = 0; j < counts[2]; j++)
			{
				for (int i = 0; i < counts[1]; i++)
				{
					bool plus = false;
					plus = stations[i].RouteCheck(j);
					if (plus)
					{
						count++;
					}
				}
				RouStat[j] = new Station[count];
				count = 0;
			}

			for (int j = 0; j < counts[2]; j++)
			{
				int k = 0;
				for (int i = 0; i < counts[1]; i++)
				{
					bool set = false;
					set = stations[i].RouteCheck(j);
					if (set)
					{
						RouStat[j][k] = stations[i];
						k++;
					}
				}
			}
		}

		//Вывод всех поездок определенного поезда
		public static void TrainTrip(Trip[] trips)
		{
			Console.WriteLine("Введите серийный номер поезда, поездки которого вы хотите посмотреть: ");
			int SerialNumber = Convert.ToInt32(Console.ReadLine());
			TrainTripOut(trips, SerialNumber);
		}

		public static void TripPrint(Trip trips, int ser)
		{
			if (ser == trips.TrainSerialNum)
				Menu.PrintTrain(trips);
		}

		public static void TrainTripOut(Trip[] trips, int s)
		{
			for (int i = 0; i < trips.Length; i++)
			{
				TripPrint(trips[i], s);
			}
		}


		public static bool Check(Ticket T, int k)
		{
			if (k == T.PassId)
				return true;
			return false;
		}

		//Поиск по классам
		public static bool Search(Station[] stations, Direction[] directions, Passenger[] passengers, Ticket[] tickets)
		{
			bool ok = false;
			Console.WriteLine("Что вы хотите найти?\n" +
							  "1.ID Станции по названию\n" +
							  "2.ID Направления по названию\n" +
							  "3.ID Пассажира по имени\n" +
							  "4.ID Билета по ID пассажира\n");
			int ch = Convert.ToInt32(Console.ReadLine());
			Console.Clear();
			string search;
			int sear;
			switch (ch)
			{
				case 1:
					Console.WriteLine("Введите название:");
					search = Console.ReadLine();
					bool exit = false;
					for (int j = 0; j < directions.Length; j++)
					{
						for (int i = 0; i < stations.Length; i++)
						{
							ok = stations[i].Check(search);
							if (ok)
							{
								exit = true;
								break;
							}
						}

						if (exit)
							break;
					}

					break;

				case 2:
					Console.WriteLine("Введите название:");
					search = Console.ReadLine();
					for (int i = 0; i < directions.Length; i++)
					{
						ok = directions[i].Check(search);
						break;
					}
					break;

				case 3:
					Console.WriteLine("Введите имя:");
					search = Console.ReadLine();
					for (int i = 0; i < passengers.Length; i++)
					{
						ok = passengers[i].Check(search);
						break;
					}
					break;

				case 4:
					Console.WriteLine("Введите id пассажира:");
					sear = Convert.ToInt32(Console.ReadLine());
					for (int i = 0; i < tickets.Length; i++)
					{
						ok = Check(tickets[i], sear);
						break;
					}
					break;


				default:
					Console.WriteLine("Вы ввели несуществующий пункт");
					break;
			}
			return ok;
		}

	}


}