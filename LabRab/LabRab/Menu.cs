using System;
using System.IO;


namespace Train_Lab
{
	public class Menu
	{
		Trip trips = new Trip();
		Station station = new Station();
		Program program = new Program();

		public static void PrintTrain(Trip trip)
		{
			Console.WriteLine("ID направления: {0}\n" +
							  "Серийный номер поезда{1}" +
							  "ID маршрута: {2}\n" +
							  "Дата и время отправления: {3}.{4} {5}:{6}", trip.DirectionId, trip.TrainSerialNum, trip.IdRoute, trip.Day,
				trip.Month
				, trip.TimeStartHours,
				trip.TimeStartMinutes);
		}

		public static void PrintStation(Station stations)
		{
			Console.WriteLine("Название станции: " + stations.Name + "\n" + "ID Направления: " + stations.DirId);
		}

		public static void PrintRoute(Direction directions)
		{
			Console.WriteLine("Название маршрута: " + directions.Name);
		}

		public static void PrintPass(Passenger passengers)
		{
			Console.WriteLine("Имя пассажира: " + passengers.FirstName + "\n" +
							  "Фамилия пассажира: " + passengers.SecondName + "\n" +
							  "Возраст пассажира: {0}\n", passengers.Age);
		}

		public static void PrintTicket(Ticket tickets)
		{
			Console.WriteLine("ID Пассажира: " + tickets.PassId + "\n" +
							  "ID Маршрута: " + tickets.RouteId + "\n" +
							  "ID Станции посадки: " + tickets.StartStation + "\n" +
							  "ID Станции высадки: " + tickets.FinishStation + "\n" +
							  "ID Поезда: " + tickets.TripId);
		}

		public static void PrintR(Route routes)
		{
			Console.WriteLine("ID направления: {0} \nСтартовая станция: {1}\nКонечная станция: {2}", routes.DirId, routes.StartStation, routes.FinishStation);
		}

		//Метод работы пункта выбора добавления
		static void Add(Trip[] trips, Station[][] stations, Direction[] directions, Passenger[] passengers, Ticket[] tickets, Route[] routes)
		{
			Console.WriteLine("Добавить:\n" +
							  "1.Поездку\n" +
							  "2.Станцию\n" +
							  "3.Направление\n" +
							  "4.Пассажира\n" +
							  "5.Билет\n" +
							  "6.Маршрут\n");
			int ch = Convert.ToInt32(Console.ReadLine());
			int in1, in2, in3, in4, in5, in6, in7;
			string name1, name2;
			switch (ch)
			{
				case 1:
					Console.WriteLine("Введите id направление: ");
					in1 = Convert.ToInt32(Console.ReadLine());
					if ((in1 > directions.Length - 1) || (in1 < 0))
					{
						Console.WriteLine("Ошибка");
						break;
					}

					Console.WriteLine("Введите серийный номер поезда: ");
					in2 = Convert.ToInt32(Console.ReadLine());

					Console.WriteLine("Введите id маршрута: ");
					in3 = Convert.ToInt32(Console.ReadLine());
					if ((in3 > routes.Length - 1) || (in3 < 0))
					{
						Console.WriteLine("Ошибка");
						break;
					}

					Console.WriteLine("Введите номер месяца: ");
					in4 = Convert.ToInt32(Console.ReadLine());
					if ((in4 >= 12) || (in4 < 1))
					{
						Console.WriteLine("Ошибка");
						break;
					}

					Console.WriteLine("Введите номер дня: ");
					in5 = Convert.ToInt32(Console.ReadLine());
					if ((in5 > 30) || (in5 < 1))
					{
						Console.WriteLine("Ошибка");
						break;
					}

					Console.WriteLine("Введите часы отправления: ");
					in6 = Convert.ToInt32(Console.ReadLine());
					if ((in6 > 23) || (in6 < 0))
					{
						Console.WriteLine("Ошибка");
						break;
					}

					Console.WriteLine("Введите минуты отправления: ");
					in7 = Convert.ToInt32(Console.ReadLine());
					if ((in7 > 59) || (in7 < 0))
					{
						Console.WriteLine("Ошибка");
						break;
					}

					BuisnessLogic.AddTrip(trips, in1, in2, in3, in4, in5, in6, in7);

					break;


				case 2:
					Console.WriteLine("Введите название станции: ");
					name1 = Console.ReadLine();
					Console.WriteLine("Введите id направления: ");
					in1 = Convert.ToInt32(Console.ReadLine());
					if ((in1 > directions.Length - 1) || (in1 < 0))
					{
						Console.WriteLine("Ошибка");
						break;
					}
					BuisnessLogic.AddStation(stations, in1, name1);
					break;


				case 3:
					Console.WriteLine("Введите название направления: ");
					name1 = Console.ReadLine();
					BuisnessLogic.AddDirection(directions, name1);
					break;


				case 4:
					Console.WriteLine("Введите имя пассажира: ");
					name1 = Console.ReadLine();
					Console.WriteLine("Введите фамилию пассажира: ");
					name2 = Console.ReadLine();
					Console.WriteLine("Введите возраст пассажира: ");
					in1 = Convert.ToInt32(Console.ReadLine());
					if (in1 < 0)
					{
						Console.WriteLine("Ошибка");
						break;
					}
					BuisnessLogic.AddPass(passengers, name1, name2, in1);
					break;


				case 5:
					Console.WriteLine("Введите id пассажира: ");
					in1 = Convert.ToInt32(Console.ReadLine());
					if ((in1 > passengers.Length - 1) || (in1 < 0))
					{
						Console.WriteLine("Ошибка");
						break;
					}

					Console.WriteLine("Введите id маршрута: ");
					in2 = Convert.ToInt32(Console.ReadLine());
					if ((in2 > routes.Length - 1) || (in2 < 0))
					{
						Console.WriteLine("Ошибка");
						break;
					}

					Console.WriteLine("Введите id станции посадки: ");
					in3 = Convert.ToInt32(Console.ReadLine());
					if (routes[in2].StatInRouteForIn(in3))
					{
						Console.WriteLine("Ошибка");
						break;
					}

					Console.WriteLine("Введите id станции высадки: ");
					in4 = Convert.ToInt32(Console.ReadLine());
					if (routes[in2].StatInRouteForOut(in3))
					{
						Console.WriteLine("Ошибка");
						break;
					}

					Console.WriteLine("Введите id поездки: ");
					in5 = Convert.ToInt32(Console.ReadLine());
					if ((in5 > trips.Length) || (in5 < 0))
					{
						Console.WriteLine("Ошибка");
						break;
					}

					BuisnessLogic.AddTicket(tickets, in1, in2, in3, in4, in5);
					break;


				case 6:
					Console.WriteLine("Введите id направления: ");
					in1 = Convert.ToInt32(Console.ReadLine());
					if ((in1 > directions.Length - 1) || (in1 < 0))
					{
						Console.WriteLine("Ошибка");
						break;
					}

					Console.WriteLine("Введите id начальной станции: ");
					in2 = Convert.ToInt32(Console.ReadLine());
					if ((in2 < 0) || (in2 > stations[in1].Length - 1))
					{
						Console.WriteLine("Ошибка");
						break;
					}

					Console.WriteLine("Введите id конечной станции: ");
					in3 = Convert.ToInt32(Console.ReadLine());
					if ((in3 < 0) || (in3 > stations[in1].Length - 1))
					{
						Console.WriteLine("Ошибка");
						break;
					}

					BuisnessLogic.AddRoute(routes, in1, in2, in3);
					break;


				default:
					Console.WriteLine("Вы выбрали несуществующий пункт!!!!!!");
					break;
			}
		}

		//Вывод всех данных данных
		static void PrintAllInfo(Trip[] trips, Station[][] RouStat, Direction[] routes, Passenger[] passengers, Ticket[] tickets, Route[] marsh, int[] counts)
		{
			Console.WriteLine("ПОЕЗДА:");
			for (int i = 0; i < counts[0]; i++)
			{
				Console.WriteLine("{0} поезд:", i + 1);
				Console.WriteLine("-------------------------");
				PrintTrain(trips[i]);
				Console.WriteLine("-------------------------");
			}
			Console.WriteLine("\n");

			Console.WriteLine("СТАНЦИИ:");
			for (int j = 0; j < counts[1]; j++)
			{
				Console.WriteLine("Направление {0}:", j);
				for (int i = 0; i < counts[1]; i++)
				{
					Console.WriteLine("{0} станция:", i);
					PrintStation(RouStat[j][i]);
				}
			}
			Console.WriteLine("\n");

			Console.WriteLine("НАПРАВЛЕНИЯ:");
			for (int i = 0; i < counts[2]; i++)
			{
				Console.WriteLine("{0} направление:", i + 1);
				Console.WriteLine("-------------------------");
				PrintRoute(routes[i]);
				Console.WriteLine("-------------------------");
			}
			Console.WriteLine("\n");

			Console.WriteLine("ПАССАЖИРЫ:");
			for (int i = 0; i < counts[3]; i++)
			{
				Console.WriteLine("{0} пассажир:", i + 1);
				Console.WriteLine("-------------------------");
				PrintPass(passengers[i]);
				Console.WriteLine("-------------------------");
			}
			Console.WriteLine("\n");

			Console.WriteLine("БИЛЕТЫ:");
			for (int i = 0; i < counts[4]; i++)
			{
				Console.WriteLine("{0} билет:", i + 1);
				Console.WriteLine("-------------------------");
				PrintTicket(tickets[i]);
				Console.WriteLine("-------------------------");
			}

			Console.WriteLine("Маршруты");
			for (int i = 0; i < counts[5]; i++)
			{
				Console.WriteLine("{0} маршрут:", i + 1);
				Console.WriteLine("-------------------------");
				PrintR(marsh[i]);
				Console.WriteLine("-------------------------");
			}
		}

		//Вывод данных конкретного значения
		static void IdInfo(Trip[] trips, Station[][] RouStat, Direction[] routes, Passenger[] passengers, Ticket[] tickets, Route[] marsh)
		{
			Console.WriteLine("Выберете пункт, по которому хотите получить информацию о конкретном значении: \n" +
							  "1.Информация о поезде\n" +
							  "2.Информация о станции\n" +
							  "3.Информация о маршруте\n" +
							  "4.Информация о пассажире\n" +
							  "5.Информация о билете\n" +
							  "6.Инфомация о маршруте\n");
			int ch = Convert.ToInt32(Console.ReadLine());
			int id;
			switch (ch)
			{
				case 1:
					Console.WriteLine("Введите id поезда:");
					id = Convert.ToInt32(Console.ReadLine());
					PrintTrain(trips[id]);
					break;


				case 2:
					Console.WriteLine("Введите id направления:");
					int id1 = Convert.ToInt32(Console.ReadLine());
					Console.WriteLine("Введите id станции на направлении:");
					int id2 = Convert.ToInt32(Console.ReadLine());
					PrintStation(RouStat[id1][id2]);
					break;


				case 3:
					Console.WriteLine("Введите id направления:");
					id = Convert.ToInt32(Console.ReadLine());
					PrintRoute(routes[id]);
					break;


				case 4:
					Console.WriteLine("Введите id пассажира:");
					id = Convert.ToInt32(Console.ReadLine());
					PrintPass(passengers[id]);
					break;


				case 5:
					Console.WriteLine("Введите id билета:");
					id = Convert.ToInt32(Console.ReadLine());
					PrintTicket(tickets[id]);
					break;

				case 6:
					Console.WriteLine("Введите id маршрута:");
					id = Convert.ToInt32(Console.ReadLine());
					PrintR(marsh[id]);
					break;


				default:
					Console.WriteLine("Вы выбрали несуществующий пункт");
					break;
			}
		}

		static void Remove(Trip[] trips, Station[][] stations, Direction[] directions, Passenger[] passengers, Ticket[] tickets, Route[] routes)
		{
			Console.WriteLine("Что вы хотите удалить?\n" +
							  "1.Поездку\n" +
							  "2.Станцию\n" +
							  "3.Направление\n" +
							  "4.Пассажира\n" +
							  "5.Билет\n" +
							  "6.Маршрут\n");
			int ch = Convert.ToInt32(Console.ReadLine());
			int in1, in2;
			switch (ch)
			{
				case 1:
					Console.WriteLine("Введите id поездки: ");
					in1 = Convert.ToInt32(Console.ReadLine());
					if ((in1 < 0) || (in1 > trips.Length))
					{
						Console.WriteLine("Ошибка");
						break;
					}
					BuisnessLogic.RemoveTrip(trips, in1);
					break;

				case 2:
					Console.WriteLine("Введите id направления: ");
					in1 = Convert.ToInt32(Console.ReadLine());
					if ((in1 < 0) || (in1 > directions.Length))
					{
						Console.WriteLine("Ошибка");
						break;
					}

					Console.WriteLine("Введите id станции: ");
					in2 = Convert.ToInt32(Console.ReadLine());
					if ((in2 < 0) || (in2 > stations.Length))
					{
						Console.WriteLine("Ошибка");
						break;
					}

					BuisnessLogic.RemoveStation(stations, in1, in2);
					break;

				case 3:
					Console.WriteLine("Введите id направления: ");
					in1 = Convert.ToInt32(Console.ReadLine());
					if ((in1 < 0) || (in1 > directions.Length))
					{
						Console.WriteLine("Ошибка");
						break;
					}

					BuisnessLogic.RemoveDir(directions, in1);
					break;

				case 4:
					Console.WriteLine("Введите id пассажира: ");
					in1 = Convert.ToInt32(Console.ReadLine());
					if ((in1 < 0) || (in1 > passengers.Length))
					{
						Console.WriteLine("Ошибка");
						break;
					}

					BuisnessLogic.RemovePass(passengers, in1);
					break;

				case 5:
					Console.WriteLine("Введите id билета: ");
					in1 = Convert.ToInt32(Console.ReadLine());
					if ((in1 < 0) || (in1 > tickets.Length))
					{
						Console.WriteLine("Ошибка");
						break;
					}

					BuisnessLogic.RemoveTicket(tickets, in1);
					break;

				case 6:
					Console.WriteLine("Введите id маршрута: ");
					in1 = Convert.ToInt32(Console.ReadLine());
					if ((in1 < 0) || (in1 > routes.Length))
					{
						Console.WriteLine("Ошибка");
						break;
					}

					BuisnessLogic.RemoveRoute(routes, in1);
					break;

				default:
					Console.WriteLine("Вы ввели несуществующий пункт");
					break;
			}
		}

		//Меню
		public static void menu(Trip[] trips, Station[] stations, Direction[] directions, Passenger[] passengers, Ticket[] tickets, Route[] routes, int[] counts)
		{
			Station[][] Nstations = new Station[directions.Length][];
			bool exit = false;
			while (!exit)
			{
				Console.Clear();
				Console.WriteLine("1.Считать базу из файла");
				Console.WriteLine("2.Вывести все данные");
				Console.WriteLine("3.Вывод конкретного значения");
				Console.WriteLine("4.Поиск элемента");
				Console.WriteLine("5.Вывести все поездки поезда под серийным номером");
				Console.WriteLine("6.Нахождение наиболее и наименее загруженных направлений");
				Console.WriteLine("7.Нахождение кол-ва вышедших или вошедших пассажиров");
				Console.WriteLine("8.Нахождение среднего кол-ва пассажиров за месяц на определенном направлении");
				Console.WriteLine("9.Добавить элемент");
				Console.WriteLine("10.Удалить элемент");
				Console.WriteLine("11.Выход");
				int ch = Convert.ToInt32(Console.ReadLine());

				switch (ch)
				{
					case 1:
						Program.ReadingArraysInfo(trips, stations, directions, passengers, tickets, routes, counts);
						Console.WriteLine("Готово");
						int k = 0;
						for (int j = 0; j < directions.Length; j++)
						{
							for (int i = 0; i < stations.Length; i++)
							{
								if (stations[i].StatIn(j))
									k++;
							}
							Nstations[j] = new Station[k];
							k = 0;
						}
						BuisnessLogic.ConvertArrToArrArr(counts, stations, Nstations);
						break;
					case 2:
						PrintAllInfo(trips, Nstations, directions, passengers, tickets, routes, counts);
						break;
					case 3:
						IdInfo(trips, Nstations, directions, passengers, tickets, routes);
						break;
					case 4:
						BuisnessLogic.Search(stations, directions, passengers, tickets);
						break;
					case 5:
						BuisnessLogic.TrainTrip(trips);
						break;
					case 6:
						BuisnessLogic.MaxMinRouteLoadedOut(tickets, routes);
						break;
					case 7:
						BuisnessLogic.TripCountPass(tickets, trips, routes);
						break;
					case 8:
						BuisnessLogic.AvgCountPassOut(tickets, trips);
						break;
					case 9:
						Add(trips, Nstations, directions, passengers, tickets, routes);
						break;
					case 10:
						Remove(trips, Nstations, directions, passengers, tickets, routes);
						break;
					case 11:
						BuisnessLogic.WriteInFile(trips, Nstations, directions, passengers, tickets, routes);
						Console.WriteLine("Пока....");
						exit = true;
						break;
					default:
						Console.WriteLine("Вы ввели несуществующий пункт меню");
						break;
				}
				Console.ReadKey();
			}

		}
	}
}