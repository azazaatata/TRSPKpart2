using System;
using System.IO;

namespace Train_Lab
{
	public class Trip
	{
		public int DirectionId;
		public int TrainSerialNum { get; set; }
		public int IdRoute { get; set; }
		public int Month { get; set; }
		public int Day { get; set; }
		public int TimeStartHours { get; set; }
		public int TimeStartMinutes { get; set; }

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
	public class Station
	{
		//*name*dirid
		public string Name { get; set; }
		public int DirId { get; set; }

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
	public class Direction
	{
		//*name
		public string Name { get; set; }

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
	public class Passenger
	{
		//*FN*SN*AGE
		public string FirstName { get; set; }
		public string SecondName { get; set; }
		public int Age { get; set; }

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

		public bool Check(string str)
		{
			if ((str == FirstName) && (str == SecondName))
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
	public class Ticket
	{
		//*PI*RI*STST*FS*TI
		public int PassId { get; set; }
		public int RouteId { get; set; }
		public int StartStation { get; set; }
		public int FinishStation { get; set; }
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
	public class Route
	{
		//*DI*STST*FS
		public int DirId { get; set; }
		public int StartStation { get; set; }
		public int FinishStation { get; set; }


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

	public class Program
	{
		//Чтение данных из файлов
		public static void ReadingArraysInfo(Trip[] trips, Station[] stations, Direction[] directions, Passenger[] passengers, Ticket[] tickets, Route[] routes, int[] counts)
		{
			FileStream file1 = new FileStream("/home/edgar/Lab_C#/Laborat.data/Trip.txt", FileMode.Open); //создаем файловый поток
			StreamReader reader = new StreamReader(file1); // создаем «потоковый читатель» и связываем его с файловым потоком

			string str1 = reader.ReadLine(); //считываем все данные с потока и выводим на экран
			string read;
			for (int i = 0; i < counts[0]; i++)
			{
				read = reader.ReadLine();
				trips[i].ReadTrain(read);
			}

			reader.Close(); //закрываем поток



			file1 = new FileStream("/home/edgar/Lab_C#/Laborat.data/Station.txt", FileMode.Open); //создаем файловый поток
			reader = new StreamReader(file1); // создаем «потоковый читатель» и связываем его с файловым потоком

			str1 = reader.ReadLine(); //считываем все данные с потока и выводим на экран
			for (int i = 0; i < counts[1]; i++)
			{
				read = reader.ReadLine();
				stations[i].ReadStation(read);
			}

			reader.Close(); //закрываем поток



			file1 = new FileStream("/home/edgar/Lab_C#/Laborat.data/Direction.txt", FileMode.Open); //создаем файловый поток
			reader = new StreamReader(file1); // создаем «потоковый читатель» и связываем его с файловым потоком

			str1 = reader.ReadLine(); //считываем все данные с потока и выводим на экран
			for (int i = 0; i < counts[2]; i++)
			{
				read = reader.ReadLine();
				directions[i].ReadRoute(read);
			}

			reader.Close(); //закрываем поток



			file1 = new FileStream("/home/edgar/Lab_C#/Laborat.data/Passenger.txt", FileMode.Open); //создаем файловый поток
			reader = new StreamReader(file1); // создаем «потоковый читатель» и связываем его с файловым потоком

			str1 = reader.ReadLine(); //считываем все данные с потока и выводим на экран
			for (int i = 0; i < counts[3]; i++)
			{
				read = reader.ReadLine();
				passengers[i].ReadPass(read);
			}

			reader.Close(); //закрываем поток

			file1 = new FileStream("/home/edgar/Lab_C#/Laborat.data/Ticket.txt", FileMode.Open); //создаем файловый поток
			reader = new StreamReader(file1); // создаем «потоковый читатель» и связываем его с файловым потоком

			str1 = reader.ReadLine(); //считываем все данные с потока и выводим на экран
			for (int i = 0; i < counts[4]; i++)
			{
				read = reader.ReadLine();
				tickets[i].ReadTicket(read);
			}

			reader.Close(); //закрываем поток

			file1 = new FileStream("/home/edgar/Lab_C#/Laborat.data/Routes.txt", FileMode.Open); //создаем файловый поток
			reader = new StreamReader(file1); // создаем «потоковый читатель» и связываем его с файловым потоком

			str1 = reader.ReadLine(); //считываем все данные с потока и выводим на экран
			for (int i = 0; i < counts[5]; i++)
			{
				read = reader.ReadLine();
				routes[i].ReadR(read);
			}

			reader.Close(); //закрываем поток
		}
	}
}