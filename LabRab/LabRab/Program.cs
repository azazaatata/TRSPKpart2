using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Channels;
using Microsoft.VisualBasic.CompilerServices;

namespace LabRab
{
	//Класс хранения информации о поездках
	class Trip
	{
		//*DI*TSN*IR*M*D*TSH*TSM
		public int DirectionId { get; set; }
		int TrainSerialNum { get; set; }
		int IdRoute { get; set; }
		public int Month { get; set; }
		int Day { get; set; }
		int TimeStartHours { get; set; }
		int TimeStartMinutes { get; set; }

		public void AddElem(int DI, int TSN, int IR, int M, int D, int TSH, int TSM)
		{
			DirectionId = DI;
			TrainSerialNum = TSN;
			IdRoute = IR;
			Month = M;
			Day = D;
			TimeStartHours = TSH;
			TimeStartMinutes = TSM;
		}

		public void ReadTrain(string read)
		{
			int Ind = read.IndexOf('*');
			read = read.Substring(Ind + 1);
			Ind = read.IndexOf('*');
			string conv = read.Substring(0, Ind);
			DirectionId = Convert.ToInt32(conv);
			read = read.Substring(Ind);


			Ind = read.IndexOf('*');
			read = read.Substring(Ind + 1);
			Ind = read.IndexOf('*');
			conv = read.Substring(0, Ind);
			TrainSerialNum = Convert.ToInt32(conv);
			read = read.Substring(Ind);


			Ind = read.IndexOf('*');
			read = read.Substring(Ind + 1);
			Ind = read.IndexOf('*');
			conv = read.Substring(0, Ind);
			IdRoute = Convert.ToInt32(conv);
			read = read.Substring(Ind);


			Ind = read.IndexOf('*');
			read = read.Substring(Ind + 1);
			Ind = read.IndexOf('*');
			conv = read.Substring(0, Ind);
			Month = Convert.ToInt32(conv);
			read = read.Substring(Ind);

			Ind = read.IndexOf('*');
			read = read.Substring(Ind + 1);
			Ind = read.IndexOf('*');
			conv = read.Substring(0, Ind);
			Day = Convert.ToInt32(conv);
			read = read.Substring(Ind);

			Ind = read.IndexOf('*');
			read = read.Substring(Ind + 1);
			Ind = read.IndexOf('*');
			conv = read.Substring(0, Ind);
			TimeStartHours = Convert.ToInt32(conv);
			read = read.Substring(Ind);


			Ind = read.IndexOf('*');
			read = read.Substring(Ind + 1);
			Ind = read.IndexOf('*');
			conv = read.Substring(0);
			TimeStartMinutes = Convert.ToInt32(conv);

		}

		public void PrintTrain()
		{
			Console.WriteLine("ID направления: {0}\n" +
			                  "Серийный номер поезда{1}" +
			                  "ID маршрута: {2}\n"+
			                  "Дата и время отправления: {3}.{4} {5}:{6}", DirectionId, TrainSerialNum, IdRoute, Day,
				Month
				, TimeStartHours,
				TimeStartMinutes);
		}

		public void TripPrint(int ser)
		{
			if(ser == TrainSerialNum)
				PrintTrain();
		}

		public string RetStr()
		{
			string temp = Convert.ToString(DirectionId);
			string str = "*";
			str = str.Insert(str.Length, temp);
			str = str.Insert(str.Length, "*");
			temp = Convert.ToString(TrainSerialNum);
			str = str.Insert(str.Length, temp);
			str = str.Insert(str.Length, "*");
			temp = Convert.ToString(IdRoute);
			str = str.Insert(str.Length, temp);
			str = str.Insert(str.Length, "*");
			temp = Convert.ToString(Month);
			str = str.Insert(str.Length, temp);
			str = str.Insert(str.Length, "*");
			temp = Convert.ToString(Day);
			str = str.Insert(str.Length, temp);
			str = str.Insert(str.Length, "*");
			temp = Convert.ToString(TimeStartHours);
			str = str.Insert(str.Length, temp);
			str = str.Insert(str.Length, "*");
			temp = Convert.ToString(TimeStartMinutes);
			str = str.Insert(str.Length, temp);
			return str;
		}
	}
	//Класс хранения информации о станциях
	class Station
    {
		//*name*dirid
	    string Name { get; set; }
		int DirId { get; set; }

		public void AddElem(string name, int DI)
		{
			Name = name;
			DirId = DI;
		}

		public void ReadStation(string read)
		{
			int Ind = read.IndexOf('*');
			read = read.Substring(Ind + 1);
			Ind = read.IndexOf('*');
			string conv = read.Substring(0, Ind);
			Name = conv;
			read = read.Substring(Ind);


			Ind = read.IndexOf('*');
			read = read.Substring(Ind + 1);
			Ind = read.IndexOf('*');
			conv = read.Substring(0, Ind);
			DirId = Convert.ToInt32(conv);
		}

		public void PrintStation()
		{
			Console.WriteLine("Название станции: "+Name+"\n" + "ID Направления: "+DirId);
		}

		public bool Check(string str)
		{
			if (str == Name)
				return true;
			return false;
		}

		public bool RouteCheck(int k)
		{
			if (k == DirId)
				return true;
			return false;
		}

		public bool StatIn(int i)
		{
			if (i == DirId)
			{
				return true;
			}
			return false;
		}

		public string RetStr()
		{
			string temp = Name;
			string str = "*";
			str = str.Insert(str.Length, temp);
			str = str.Insert(str.Length, "*");
			temp = Convert.ToString(DirId);
			str = str.Insert(str.Length, temp);
			return str;
		}
	}
	//Класс хранения информации о направлениях
	class Direction
	{
		//*name
		string Name { get; set; }

		public void AddElem(string name)
		{
			Name = name;
		}

		public void ReadRoute(string read)
		{
			
			int Ind = read.IndexOf('*');
			read = read.Substring(Ind + 1);
			Ind = read.IndexOf('*');
			string conv = read.Substring(0, Ind);
			Name = conv;
		}

		public void PrintRoute()
		{
			Console.WriteLine("Название маршрута: "+Name);
		}

		public bool Check(string str)
		{
			if (str == Name)
				return true;
			return false;
		}

		public string RetStr()
		{
			string str = "*";
			str = str.Insert(str.Length, Name);
			return str;
		}
	}
	//Класс хранения информации о пассажирах
	class Passenger
    {
		//*FN*SN*AGE
	    string FirstName { get; set; }
	    string SecondName { get; set; }
		int Age { get; set; }

		public void AddElem(string fn, string sn, int a)
		{
			FirstName = fn;
			SecondName = sn;
			Age = a;
		}

		public void ReadPass(string read)
		{
			int Ind = read.IndexOf('*');
			read = read.Substring(Ind + 1);
			Ind = read.IndexOf('*');
			string conv = read.Substring(0, Ind);
			FirstName = conv;
			read = read.Substring(Ind);

			Ind = read.IndexOf('*');
			read = read.Substring(Ind + 1);
			Ind = read.IndexOf('*');
			conv = read.Substring(0, Ind);
			SecondName = conv;
			read = read.Substring(Ind);

			Ind = read.IndexOf('*');
			read = read.Substring(Ind + 1);
			Ind = read.IndexOf('*');
			conv = read.Substring(0, Ind);
			Age = Convert.ToInt32(conv);
		}

		public void PrintPass()
		{
			Console.WriteLine("Имя пассажира: " + FirstName + "\n" +
			                  "Фамилия пассажира: " + SecondName +"\n"+
			                  "Возраст пассажира: {0}\n", Age);
		}

		public bool Check(string str)
		{
			if ((str == FirstName)&&(str == SecondName))
				return true;
			return false;
		}

		public string RetStr()
		{
			string temp = Convert.ToString(Age);
			string str = "*";
			str = str.Insert(str.Length, FirstName);
			str = str.Insert(str.Length, "*");
			str = str.Insert(str.Length, SecondName);
			str = str.Insert(str.Length, "*");
			str = str.Insert(str.Length, temp);
			return str;
		}
	}
	//Класс хранения информации о билетах
	class Ticket
    {
	    //*PI*RI*STST*FS*TI
	    int PassId { get; set; }
	    int RouteId { get; set; }
		int StartStation { get; set; }
		int FinishStation { get; set; }
		public int TripId { get; set; }

		public void AddElem(int PI, int RI, int StSt, int FS, int TI)
		{
			PassId = PI;
			RouteId = RI;
			StartStation = StSt;
			FinishStation = FS;
			TripId = TI;
		}

		public void ReadTicket(string read)
		{
			int Ind = read.IndexOf('*');
			read = read.Substring(Ind + 1);
			Ind = read.IndexOf('*');
			string conv = read.Substring(0, Ind);
			PassId = Convert.ToInt32(conv);
			read = read.Substring(Ind);

			Ind = read.IndexOf('*');
			read = read.Substring(Ind + 1);
			Ind = read.IndexOf('*');
			conv = read.Substring(0, Ind);
			RouteId = Convert.ToInt32(conv);
			read = read.Substring(Ind);

			Ind = read.IndexOf('*');
			read = read.Substring(Ind + 1);
			Ind = read.IndexOf('*');
			conv = read.Substring(0, Ind);
			StartStation = Convert.ToInt32(conv);
			read = read.Substring(Ind);


			Ind = read.IndexOf('*');
			read = read.Substring(Ind + 1);
			Ind = read.IndexOf('*');
			conv = read.Substring(0, Ind);
			FinishStation = Convert.ToInt32(conv);
			read = read.Substring(Ind);


			Ind = read.IndexOf('*');
			read = read.Substring(Ind + 1);
			Ind = read.IndexOf('*');
			conv = read.Substring(0);
			TripId = Convert.ToInt32(conv);
		}

		public void PrintTicket()
		{
			Console.WriteLine("ID Пассажира: " + PassId + "\n" +
							  "ID Маршрута: " + RouteId + "\n" +
			                  "ID Станции посадки: "+ StartStation+ "\n" +
			                  "ID Станции высадки: "+ FinishStation+ "\n" +
			                  "ID Поезда: " + TripId);
		}

		public int GetRouteId()
		{
			return RouteId;
		}

		public bool Check(int k)
		{
			if (k == PassId)
				return true;
			return false;
		}

		public bool Out(int stat, int trip)
		{
			if ((FinishStation == stat)&&(trip == TripId))
				return true;
			return false;
		}

		public bool In(int stat, int trip)
		{
			if ((StartStation == stat) && (trip == TripId))
				return true;
			return false;
		}

		public string RetStr()
		{
			string str = "*";
			string temp = Convert.ToString(PassId);
			str = str.Insert(str.Length, temp);
			str = str.Insert(str.Length, "*");
			temp = Convert.ToString(RouteId);
			str = str.Insert(str.Length, temp);
			str = str.Insert(str.Length, "*");
			temp = Convert.ToString(StartStation);
			str = str.Insert(str.Length, temp);
			str = str.Insert(str.Length, "*");
			temp = Convert.ToString(FinishStation);
			str = str.Insert(str.Length, temp);
			str = str.Insert(str.Length, "*");
			temp = Convert.ToString(TripId);
			str = str.Insert(str.Length, temp);
			return str;
		}
	}
	//Класс хранения информации о маршрутах
	class Route
	{
		//*DI*STST*FS
		int DirId { get; set; }
		int StartStation { get; set; }
		int FinishStation { get; set; }


		public void AddElem(int DI, int StSt, int FS)
		{
			DirId = DI;
			StartStation = StSt;
			FinishStation = FS;
		}

		public void ReadR(string read)
		{
			int Ind = read.IndexOf('*');
			read = read.Substring(Ind + 1);
			Ind = read.IndexOf('*');
			string conv = read.Substring(0, Ind);
			DirId = Convert.ToInt32(conv);
			read = read.Substring(Ind);

			Ind = read.IndexOf('*');
			read = read.Substring(Ind + 1);
			Ind = read.IndexOf('*');
			conv = read.Substring(0, Ind);
			StartStation = Convert.ToInt32(conv);
			read = read.Substring(Ind);

			Ind = read.IndexOf('*');
			read = read.Substring(Ind + 1);
			Ind = read.IndexOf('*');
			conv = read.Substring(0, Ind);
			FinishStation = Convert.ToInt32(conv);
			read = read.Substring(Ind);
		}

		public void PrintR()
		{
			Console.WriteLine("ID направления: {0} \nСтартовая станция: {1}\nКонечная станция: {2}", DirId, StartStation, FinishStation);
		}

		public bool StatInRouteForOut(int Station)
		{
			if (StartStation > FinishStation)
			{
				if ((Station < StartStation) && (Station >= FinishStation))
				{
					return true;
				}
				return false;
			}
			if ((Station > StartStation) && (Station <= FinishStation))
			{
				return true;
			}
			return false;
		}

		public bool StatInRouteForIn(int Station)
		{
			if (StartStation > FinishStation)
			{
				if ((Station <= StartStation) && (Station > FinishStation))
				{
					return true;
				}
				return false;
			}
			if ((Station >= StartStation) && (Station < FinishStation))
			{
				return true;
			}
			return false;
		}

		public string RetStr()
		{
			string str = "*";
			string temp = Convert.ToString(DirId);
			str = str.Insert(str.Length, temp);
			str = str.Insert(str.Length, "*");
			temp = Convert.ToString(StartStation);
			str = str.Insert(str.Length, temp);
			str = str.Insert(str.Length, "*");
			temp = Convert.ToString(FinishStation);
			str = str.Insert(str.Length, temp);
			return str;
		}
	}



	class Program
	{
		//Чтение данных из файлов
		static void ReadingArraysInfo(Trip[] trips, Station[] stations, Direction[] directions, Passenger[] passengers, Ticket[] tickets, Route[] routes, int[] counts)
        {
			FileStream file1 = new FileStream("C:\\Laborat\\Train.txt", FileMode.Open); //создаем файловый поток
			StreamReader reader = new StreamReader(file1); // создаем «потоковый читатель» и связываем его с файловым потоком

			string str1 = reader.ReadLine(); //считываем все данные с потока и выводим на экран
			string read;
			for (int i = 0; i < counts[0]; i++)
			{
				read = reader.ReadLine();
				trips[i].ReadTrain(read);
			}

			reader.Close(); //закрываем поток



			file1 = new FileStream("C:\\Laborat\\Station.txt", FileMode.Open); //создаем файловый поток
			reader = new StreamReader(file1); // создаем «потоковый читатель» и связываем его с файловым потоком

			str1 = reader.ReadLine(); //считываем все данные с потока и выводим на экран
			for (int i = 0; i < counts[1]; i++)
			{
				read = reader.ReadLine();
				stations[i].ReadStation(read);
			}

			reader.Close(); //закрываем поток



			file1 = new FileStream("C:\\Laborat\\Direction.txt", FileMode.Open); //создаем файловый поток
			reader = new StreamReader(file1); // создаем «потоковый читатель» и связываем его с файловым потоком

			str1 = reader.ReadLine(); //считываем все данные с потока и выводим на экран
			for (int i = 0; i < counts[2]; i++)
			{
				read = reader.ReadLine();
				directions[i].ReadRoute(read);
			}

			reader.Close(); //закрываем поток



			file1 = new FileStream("C:\\Laborat\\Passenger.txt", FileMode.Open); //создаем файловый поток
			reader = new StreamReader(file1); // создаем «потоковый читатель» и связываем его с файловым потоком

			str1 = reader.ReadLine(); //считываем все данные с потока и выводим на экран
			for (int i = 0; i < counts[3]; i++)
			{
				read = reader.ReadLine();
				passengers[i].ReadPass(read);
			}

			reader.Close(); //закрываем поток

			file1 = new FileStream("C:\\Laborat\\Ticket.txt", FileMode.Open); //создаем файловый поток
			reader = new StreamReader(file1); // создаем «потоковый читатель» и связываем его с файловым потоком

			str1 = reader.ReadLine(); //считываем все данные с потока и выводим на экран
			for (int i = 0; i < counts[4]; i++)
			{
				read = reader.ReadLine();
				tickets[i].ReadTicket(read);
			}

			reader.Close(); //закрываем поток

			file1 = new FileStream("C:\\Laborat\\Routes.txt", FileMode.Open); //создаем файловый поток
			reader = new StreamReader(file1); // создаем «потоковый читатель» и связываем его с файловым потоком

			str1 = reader.ReadLine(); //считываем все данные с потока и выводим на экран
			for (int i = 0; i < counts[5]; i++)
			{
				read = reader.ReadLine();
				routes[i].ReadR(read);
			}

			reader.Close(); //закрываем поток
		}

		//Конвертирование обычного массива в зубчатый
		static void ConvertArrToArrArr(int[] counts, Station[] stations, Station[][] RouStat)
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

		//Вывод всех данных данных
		static void PrintAllInfo(Trip[] trips, Station[][] RouStat, Direction[] routes, Passenger[] passengers, Ticket[] tickets, Route[] marsh, int[] counts)
		{
			Console.WriteLine("ПОЕЗДА:");
			for (int i = 0; i < counts[0]; i++)
			{
				Console.WriteLine("{0} поезд:",i+1);
				Console.WriteLine("-------------------------");
				trips[i].PrintTrain();
				Console.WriteLine("-------------------------");
			}
			Console.WriteLine("\n");

			Console.WriteLine("СТАНЦИИ:");
			for (int j = 0; j < counts[1]; j++)
			{
				Console.WriteLine("Направление {0}:",j);
				int k = 0;
				for (int i = 0; i < counts[1]; i++)
				{
					Console.WriteLine("{0} станция:",i);
					RouStat[j][i].PrintStation();
				}
			}
			Console.WriteLine("\n");

			Console.WriteLine("НАПРАВЛЕНИЯ:");
			for (int i = 0; i < counts[2]; i++)
			{
				Console.WriteLine("{0} направление:", i+1);
				Console.WriteLine("-------------------------");
				routes[i].PrintRoute();
				Console.WriteLine("-------------------------");
			}
			Console.WriteLine("\n");

			Console.WriteLine("ПАССАЖИРЫ:");
			for (int i = 0; i < counts[3]; i++)
			{
				Console.WriteLine("{0} пассажир:", i+1);
				Console.WriteLine("-------------------------");
				passengers[i].PrintPass();
				Console.WriteLine("-------------------------");
			}
			Console.WriteLine("\n");

			Console.WriteLine("БИЛЕТЫ:");
			for (int i = 0; i < counts[4]; i++)
			{
				Console.WriteLine("{0} билет:", i+1);
				Console.WriteLine("-------------------------");
				tickets[i].PrintTicket();
				Console.WriteLine("-------------------------");
			}

			Console.WriteLine("Маршруты");
			for (int i = 0; i < counts[5]; i++)
			{
				Console.WriteLine("{0} маршрут:", i + 1);
				Console.WriteLine("-------------------------");
				marsh[i].PrintR();
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
					trips[id].PrintTrain();
					break;


				case 2:
					Console.WriteLine("Введите id направления:");
					int id1 = Convert.ToInt32(Console.ReadLine());
					Console.WriteLine("Введите id станции на направлении:");
					int id2 = Convert.ToInt32(Console.ReadLine());
					RouStat[id1][id2].PrintStation();
					break;


				case 3:
					Console.WriteLine("Введите id направления:");
					id = Convert.ToInt32(Console.ReadLine());
					routes[id].PrintRoute();
					break;


				case 4:
					Console.WriteLine("Введите id пассажира:");
					id = Convert.ToInt32(Console.ReadLine());
					passengers[id].PrintPass();
					break;


				case 5:
					Console.WriteLine("Введите id билета:");
					id = Convert.ToInt32(Console.ReadLine());
					tickets[id].PrintTicket();
					break;

				case 6:
					Console.WriteLine("Введите id маршрута:");
					id = Convert.ToInt32(Console.ReadLine());
					marsh[id].PrintR();
					break;


				default:
					Console.WriteLine("Вы выбрали несуществующий пункт");
					break;
			}
		}

		//Поиск по классам
		static bool Search(Station[] stations, Direction[] directions, Passenger[] passengers, Ticket[] tickets)
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
						ok = tickets[i].Check(sear);
						break;
					}
					break;


				default:
					Console.WriteLine("Вы ввели несуществующий пункт");
					break;
			}
			return ok;
		}

		//Вывод всех поездок определенного поезда
		static void TrainTrip(Trip[] trips)
		{
			Console.WriteLine("Введите серийный номер поезда, поездки которого вы хотите посмотреть: ");
			int SerialNumber = Convert.ToInt32(Console.ReadLine());
			TrainTripOut(trips, SerialNumber);
		}

		static void TrainTripOut(Trip[] trips, int s)
		{
			for (int i = 0; i < trips.Length; i++)
			{
				trips[i].TripPrint(s);
			}
		}

		//Нахождение наиболее и наименее загруженных направлений

		static void MaxMinRouteLoadedOut(Ticket[] tickets, Route[] routes)
		{
			int maximus = 0;
			int minimus = 0;
			MaxMinRouteLoaded(tickets, routes, out  maximus,out  minimus);
			Console.WriteLine("Наиболее загруженное направление:");
			routes[maximus].PrintR();
			Console.WriteLine("Наименее загруженное направление:");
			routes[minimus].PrintR();
		}

		static void MaxMinRouteLoaded(Ticket[] tickets, Route[] routes, out int maximus,out  int minimus)
		{
			maximus = -1;
			minimus = -1;
			int[] count = new int[routes.Length];
			for (int i = 0; i < tickets.Length; i++)
			{
				count[tickets[i].GetRouteId()]++;
			}

			for (int i = 0; i < count.Length; i++)
			{
				for (int j = 0; j < count.Length; j++)
				{
					if((i!=j)&&(count[i]>=count[j]))
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

		//Нахождение кол-ва вышедших или вошедших пассажиров
		static void TripCountPass(Ticket[] tickets, Trip[] trips, Route[] routes)
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
			if ((ch != 1) || (ch != 2)|| (otv == -1))
			{
				Console.WriteLine("Ошибка");
				return;
			}
			Console.WriteLine(otv);
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
				if (tickets[i].Out(Station, TripId))
				{
					Outc++;
				}
			}
			return Outc;
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
				if (tickets[i].In(Station, TripId))
				{
					Inc++;
				}
			}
			return Inc;
		}


		//Нахождение среднего кол-ва пассажиров за месяц на определенном направлении
		static void AvgCountPassOut(Ticket[] tickets, Trip[] trips)
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
				if ((trips[tickets[i].TripId].DirectionId == DirId)&&(trips[tickets[i].TripId].Month == mon))
				{
					count++;
				}
			}
			count = count / 30;
			return count;
		}

		//Расширение массивов объектов классов на 1 элемент
		static void AddOneElemTrip(Trip[] trips)
		{
			Array.Resize(ref trips, trips.Length+1);
		}

		static void AddOneElemStation(Station[][] stations, int dirid)
		{
			Array.Resize(ref stations[dirid], stations.Length + 1);
		}

		static void AddOneElemDirection(Direction[] directions)
		{
			Array.Resize(ref directions, directions.Length + 1);
		}

		static void AddOneElemPass(Passenger[] passengers)
		{
			Array.Resize(ref passengers, passengers.Length+1);
		}

		static void AddOneElemTicket(Ticket[] tickets)
		{
			Array.Resize(ref tickets, tickets.Length + 1);
		}

		static void AddOneElemRoute(Route[] routes)
		{
			Array.Resize(ref routes, routes.Length + 1);
		}

		static void AddOneElemPassenger(Passenger[] passengers)
		{
			Array.Resize(ref passengers, passengers.Length + 1);
		}

		//Добавление элемента в массив элементов классов
		static void AddTrip(Trip[] trips, int DirId, int TrainSerNum, int IdRoute, int Mon, int Day, int TimeHours, int TimeMinutes)
		{
			AddOneElemTrip(trips);
			Trip newElem = new Trip();
			newElem.AddElem(DirId,TrainSerNum,IdRoute,Mon,Day, TimeHours, TimeMinutes);
			trips[trips.Length - 1] = newElem;
		}

		static void AddStation(Station[][] stations, int DirId, string Name)
		{
			AddOneElemStation(stations, DirId);
			Station newElem = new Station();
			newElem.AddElem(Name, DirId);
			stations[DirId][stations[DirId].Length - 1] = newElem;
		}

		static void AddDirection(Direction[] directions, string name)
		{
			AddOneElemDirection(directions);
			Direction newElem = new Direction();
			newElem.AddElem(name);
			directions[directions.Length - 1] = newElem;
		}

		static void AddPass(Passenger[] passengers, string name1, string name2, int age)
		{
			AddOneElemPassenger(passengers);
			Passenger newElem = new Passenger();
			newElem.AddElem(name1, name2, age);
			passengers[passengers.Length - 1] = newElem;
		}

		static void AddTicket(Ticket[] tickets, int PassId, int RouteId, int StartStation, int FinishStation, int TripId)
		{
			AddOneElemTicket(tickets);
			Ticket newElem = new Ticket();
			newElem.AddElem(PassId,RouteId,StartStation,FinishStation, TripId);
			tickets[tickets.Length] = newElem;
		}

		static void AddRoute(Route[] routes, int DirId, int StartStaion, int FinishStation)
		{
			AddOneElemRoute(routes);
			Route newElem = new Route();
			newElem.AddElem(DirId, StartStaion, FinishStation);
			routes[routes.Length] = newElem;
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
					if ((in1 > directions.Length-1)||(in1<0))
					{
						Console.WriteLine("Ошибка");
						break;
					}

					Console.WriteLine("Введите серийный номер поезда: ");
					in2 = Convert.ToInt32(Console.ReadLine());

					Console.WriteLine("Введите id маршрута: ");
					in3 = Convert.ToInt32(Console.ReadLine());
					if ((in3 > routes.Length - 1)||(in3<0))
					{
						Console.WriteLine("Ошибка");
						break;
					}

					Console.WriteLine("Введите номер месяца: ");
					in4 = Convert.ToInt32(Console.ReadLine());
					if ((in4 > 12)||(in4<1))
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

					AddTrip(trips, in1, in2, in3, in4, in5, in6, in7);

					break;


				case 2:
					Console.WriteLine("Введите название станции: ");
					name1 = Console.ReadLine();
					Console.WriteLine("Введите id направления: ");
					in1 = Convert.ToInt32(Console.ReadLine());
					if ((in1 > directions.Length - 1)||(in1<0))
					{
						Console.WriteLine("Ошибка");
						break;
					}
					AddStation(stations, in1, name1);
					break;


				case 3:
					Console.WriteLine("Введите название направления: ");
					name1 = Console.ReadLine();
					AddDirection(directions, name1);
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
					AddPass(passengers, name1, name2, in1);
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

					AddTicket(tickets,in1,in2, in3,in4,in5);
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

					AddRoute(routes, in1, in2, in3);
					break;


				default:
					Console.WriteLine("Вы выбрали несуществующий пункт!!!!!!");
					break;
			}
		}

		//Удаление элемента из массива объектов класса
		static void RemoveTrip(Trip[] trips, int id)
		{
			for (int i = id; i < trips.Length-1; i++)
			{
				trips[i] = trips[i + 1];
			}
			Array.Resize(ref trips, trips.Length-1);
		}

		static void RemoveStation(Station[][] stations, int id1, int id2)
		{
			for (int i = id2; i < stations[id1].Length-1; i++)
			{
				stations[id1][i] = stations[id1][i + 1];
			}
			Array.Resize(ref stations[id1], stations[id1].Length - 1);
		}

		static void RemoveDir(Direction[] directions, int id)
		{
			for (int i = id; i < directions.Length - 1; i++)
			{
				directions[i] = directions[i + 1];
			}
			Array.Resize(ref directions, directions.Length - 1);
		}

		static void RemovePass(Passenger[] passengers, int id)
		{
			for (int i = id; i < passengers.Length - 1; i++)
			{
				passengers[i] = passengers[i + 1];
			}
			Array.Resize(ref passengers, passengers.Length - 1);
		}

		static void RemoveTicket(Ticket[] tickets, int id)
		{
			for (int i = id; i < tickets.Length - 1; i++)
			{
				tickets[i] = tickets[i + 1];
			}
			Array.Resize(ref tickets, tickets.Length - 1);
		}

		static void RemoveRoute(Route[] routes, int id)
		{
			for (int i = id; i < routes.Length - 1; i++)
			{
				routes[i] = routes[i + 1];
			}
			Array.Resize(ref routes, routes.Length - 1);
		}

		//Функция работы пункта удаления
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
					RemoveTrip(trips, in1);
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

					RemoveStation(stations, in1, in2);
					break;

				case 3:
					Console.WriteLine("Введите id направления: ");
					in1 = Convert.ToInt32(Console.ReadLine());
					if ((in1 < 0) || (in1 > directions.Length))
					{
						Console.WriteLine("Ошибка");
						break;
					}

					RemoveDir(directions, in1);
					break;

				case 4:
					Console.WriteLine("Введите id пассажира: ");
					in1 = Convert.ToInt32(Console.ReadLine());
					if ((in1 < 0) || (in1 > passengers.Length))
					{
						Console.WriteLine("Ошибка");
						break;
					}

					RemovePass(passengers, in1);
					break;

				case 5:
					Console.WriteLine("Введите id билета: ");
					in1 = Convert.ToInt32(Console.ReadLine());
					if ((in1 < 0) || (in1 > tickets.Length))
					{
						Console.WriteLine("Ошибка");
						break;
					}

					RemoveTicket(tickets, in1);
					break;

				case 6:
					Console.WriteLine("Введите id маршрута: ");
					in1 = Convert.ToInt32(Console.ReadLine());
					if ((in1 < 0) || (in1 > routes.Length))
					{
						Console.WriteLine("Ошибка");
						break;
					}

					RemoveRoute(routes, in1);
					break;

				default:
					Console.WriteLine("Вы ввели несуществующий пункт");
					break;
			}
		}

		//Функция записывающая данных в файл при выходе из программы
		static void WriteInFile(Trip[] trips, Station[][] stations, Direction[] directions, Passenger[] passengers, Ticket[] tickets, Route[] routes)
		{
			StreamWriter sw = new StreamWriter("C:\\Laborat\\Trip.txt", false);
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

			sw = new StreamWriter("C:\\Laborat\\Counts.txt", false);
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
			}
			sw.Close();

			sw = new StreamWriter("C:\\Laborat\\Stations.txt", false);
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

			sw = new StreamWriter("C:\\Laborat\\Directions.txt", false);
			str = "";
			for (int i = 0; i < directions.Length; i++)
			{
				str = directions[i].RetStr();
				sw.WriteLine(str);
			}
			sw.Close();

			sw = new StreamWriter("C:\\Laborat\\Passengers.txt", false);
			for (int i = 0; i < passengers.Length; i++)
			{
				str = passengers[i].RetStr();
				sw.WriteLine(str);
			}
			sw.Close();

			sw = new StreamWriter("C:\\Laborat\\Ticket.txt", false);
			for (int i = 0; i < tickets.Length; i++)
			{
				str = tickets[i].RetStr();
				sw.WriteLine(str);
			}
			sw.Close();

			sw = new StreamWriter("C:\\Laborat\\Route.txt", false);
			for (int i = 0; i < routes.Length; i++)
			{
				str = routes[i].RetStr();
				sw.WriteLine(str);
			}
			sw.Close();
		}

		//Меню
		static void menu(Trip[] trips, Station[] stations, Direction[] directions, Passenger[] passengers, Ticket[] tickets, Route[] routes, int[] counts)
		{
			Station[][] Nstations = new Station[directions.Length][];
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
			ConvertArrToArrArr(counts, stations, Nstations);
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
						ReadingArraysInfo(trips, stations, directions, passengers, tickets, routes, counts);
						Console.WriteLine("Готово");
						break;
					case 2:
						PrintAllInfo(trips, Nstations, directions, passengers, tickets, routes, counts);
						break;
					case 3:
						IdInfo(trips, Nstations, directions, passengers, tickets, routes);
						break;
					case 4:
						Search(stations, directions, passengers, tickets);
						break;
					case 5:
						TrainTrip(trips);
						break;
					case 6:
						MaxMinRouteLoadedOut(tickets, routes);
						break;
					case 7:
						TripCountPass(tickets, trips, routes);
						break;
					case 8:
						AvgCountPassOut(tickets,trips);
						break;
					case 9:
						Add(trips, Nstations, directions, passengers, tickets, routes);
						break;
					case 10:
						Remove(trips, Nstations, directions, passengers, tickets, routes);
						break;
					case 11:
						WriteInFile(trips, Nstations, directions, passengers, tickets, routes);
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
		static void Main(string[] args)
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

			menu(trips, stations, directions, passengers, tickets, routes, counts);
		}
	}
}
