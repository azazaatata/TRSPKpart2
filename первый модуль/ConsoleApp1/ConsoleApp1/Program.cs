using System;

namespace Сomputational_geometry
{
    class Program
    {
        static bool point(out double s, out double p) //Ввод координат точек
        {
	        int n;
	        p = 0;
	        Console.WriteLine("Точки должны вводится в порядке обхода");
            Console.WriteLine("Введите количество вершин:");
            n = Convert.ToInt32(Console.ReadLine());
            int[] ArrayX = new int[n];
            int[] ArrayY = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Clear();
                Console.WriteLine("Введите координату x точки {0}:", i);
                ArrayX[i] = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите координату y точки {0}:", i);
                ArrayY[i] = Convert.ToInt32(Console.ReadLine());
            }
            s = S(ArrayX, ArrayY);
            bool ok = s == 0 ? false : true;
            if (ok)
				p = P(ArrayX, ArrayY);
            return ok;
        }


        static double S(int[] ArrayX, int[] ArrayY) //Нахождение площади n-угольной фигуры по координатам точек
        {
            double S = ((ArrayX[ArrayX.Length - 1] - ArrayX[0]) * (ArrayY[ArrayY.Length - 1] + ArrayY[0]));
            for (int i = 0; i < ArrayX.Length-1; i++)
            {
                S += ((ArrayX[i] - ArrayX[i + 1]) * (ArrayY[i] + ArrayY[i + 1]));
            }
            if (S < 0)
            {
                S *= -1;
            }
            S *= 0.5;
            return S;
        }


        static double P(int[] ArrayX, int[] ArrayY) //Нахождение периметра n-угольной фигуры по координатам точки
        {
            double P = Math.Sqrt(Math.Pow((ArrayX[ArrayX.Length - 1] - ArrayX[0]), 2) + Math.Pow((ArrayY[ArrayY.Length - 1] - ArrayY[0]), 2));
            for (int i = 0; i < ArrayX.Length - 1; i++)
            {
                P += Math.Sqrt(Math.Pow((ArrayX[i + 1] - ArrayX[i]), 2) + Math.Pow((ArrayY[i + 1] - ArrayY[i]), 2));
            }
            return P;
        }


        static void CircleSquare1()   //Площадь окружности через радиус
        {
            Console.Clear();
            double S = 0;
            Console.WriteLine("Введите длину радиуса: ");
            double r = Convert.ToInt32(Console.ReadLine());
            S = 3.14 * Math.Pow(r, 2);
            Console.Clear();
            if (S <= 0)
            {
                Console.WriteLine("Данные введены неверно");
            }
            else
            {
                Console.WriteLine("Площадь равна: " + S);
            }
            return;
        }


        static void CircleSquare2()   //Площадь окружности через диаметр
        {
            Console.Clear();
            double S = 0;
            Console.WriteLine("Введите диаметр окружности: ");
            double d = Convert.ToInt32(Console.ReadLine());
            S = (3.14 * Math.Pow(d, 2)) / 4;
            Console.Clear();
            if (S <= 0)
            {
                Console.WriteLine("Данные введены неверно");
            }
            else
            {
                Console.WriteLine("Площадь равна: " + S);
            }
            return;
        }


        static void CircleSquare3()   //Площадь окружности через длину окружности
        {
            Console.Clear();
            double S = 0;
            Console.WriteLine("Введите длину окружности");
            double l = Convert.ToInt32(Console.ReadLine());
            S = Math.Pow(l, 2) / (4 * 3.14);
            Console.Clear();
            if (S <= 0)
            {
                Console.WriteLine("Данные введены неверно");
            }
            else
            {
                Console.WriteLine("Площадь равна: " + S);
            }
            return;
        }


        static void Cosinus() //Косинус угла между векторами
        {
            Console.Clear();

            int[] ArrX = new int[4];
            int[] ArrY = new int[4];
            Console.WriteLine("Введите начальные и конечные точки векторов: ");
            Console.Clear();
            Console.WriteLine("Точки вводятся в порядке:\n" +
                "1 точка - начало вектора 1\n" +
                "2 точка - конец вектора 1\n" +
                "3 точка - начало вектора 2\n" +
                "4 точка - конец вектора 2");
            for (int i = 0; i < ArrX.Length; i++)
            {
                Console.WriteLine("Введите координату x точки {0}:", i);
                ArrX[i] = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите координату y точки {0}:", i);
                ArrY[i] = Convert.ToInt32(Console.ReadLine());
            }

            double Cos = (((ArrX[1] - ArrX[0]) * (ArrX[3] - ArrX[2])) + ((ArrY[1] - ArrY[0]) * (ArrY[3] - ArrY[2]))) /
                (Math.Sqrt(Math.Pow((ArrX[1] - ArrX[0]), 2) + Math.Pow((ArrY[1] - ArrY[0]), 2)) *
                Math.Sqrt(Math.Pow((ArrX[3] - ArrX[2]), 2) + Math.Pow((ArrY[3] - ArrY[2]), 2)));
            Console.WriteLine("Косинус равен: " + Cos);
            return;
        }


        static void Triangle()    //Нахождение третьей стороны треугольника
        {
            double bis;    //Биссектриса
            double leg1;    //Катет 1
            double leg2;    //Катет 2
            double seek = 0;
            int k;

            Console.WriteLine("Что нужно найти?\n" +
                "1. Катет по биссектрисе и катету\n" +
                "2. Бисектрису по катетам");
            Console.Clear();

            k = Convert.ToInt32(Console.ReadLine());

            bool ok = true;
            switch (k)
            {
                case 1:
                    Console.WriteLine("Введите длину биссектрисы: ");
                    bis = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите длину катета");
                    leg1 = Convert.ToInt32(Console.ReadLine());
                    seek = Math.Sqrt(Math.Pow(bis, 2) - Math.Pow(leg1, 2));
                    break;
                case 2:
                    Console.WriteLine("Введите длину катета 1");
                    leg1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите длину катета 2");
                    leg2 = Convert.ToInt32(Console.ReadLine());
                    seek = Math.Sqrt(Math.Pow(leg1, 2) + Math.Pow(leg2, 2));
                    break;
                default:
                    ok = false;
                    Console.WriteLine("Вы выбрали несуществующий вариант");
                    break;
            }
            if (!ok)
	            return;
            Console.Clear();
            Console.WriteLine("Искомая сторона равна: " + seek);
        }


        static void Main(string[] args)
        {
	        bool exit = true;
	        while (exit)
	        {
		        Console.WriteLine("Выберите пункт из списка:\n" +
		                          "1. Найти площадь и периметр многоугольника, через координаты точек, заданых в порядке обхода\n" +
		                          "2. Найти площадь круга\n" +
		                          "3. Найти косинус между векторами\n" +
                                  "4. Найти сторону треугольника через две другие\n" +
                                  "5. Выход\n");
		        int choose = Convert.ToInt32(Console.ReadLine());
		        switch (choose)
		        {
			        case 1:
				        double Plosh = 0, Perim = 0;
				        bool OK = point(out Plosh, out Perim);
				        if (OK)
				        {
					        Console.WriteLine("Площадь многоугольника: {0}, Периметр многоугольника: {1}", Plosh, Perim);
					        break;
				        }
				        Console.WriteLine("Ошибка в координатах");
				        break;
                    case 2:
	                    Console.Clear();
	                    Console.WriteLine("Найти площадь круга:\n" +
                                          "1. Через радиус\n" +
                                          "2. Через диаметр\n" +
                                          "3. Через длинну окружности\n");
	                    choose = Convert.ToInt32(Console.ReadLine());
	                    switch (choose)
	                    {
		                    case 1:
			                    CircleSquare1();
			                    break;

                            case 2:
	                            CircleSquare2();
	                            break;

                            case 3:
	                            CircleSquare3();
	                            break;

		                    default:
			                    Console.WriteLine("Введена неверная цифра");
	                            break;
                        }
	                    break;

                    case 3:
						Cosinus();
	                    break;

                    case 4:
						Triangle();
	                    break;

                    case 5:
	                    exit = false;
	                    break;

                    default:
	                    Console.WriteLine("Введена неверная цифра");
	                    break;
		        }
		        Console.ReadKey();
                Console.Clear();
	        }
        }
    }
}
