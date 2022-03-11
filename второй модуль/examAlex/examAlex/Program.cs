using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Point
    {
        double x;
        double y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double calculateDistance(Point p)
        {
            if (this == p)
            {
                return 0;
            }
            else
            {
                return Math.Sqrt(Math.Pow((this.x - p.x), 2) + Math.Pow((this.y - p.y), 2));
            }
        }
    }

    class Trapeze
    {
        public Point p1;
        public Point p2;
        public Point p3;
        public Point p4;

        private double dist12;
        private double dist23;
        private double dist34;
        private double dist14;

        private double perimeter;
        private double area;

        public Trapeze(Point p1, Point p2, Point p3, Point p4)
        {
            if (isIsoscelesTrapeze(p1, p2, p3, p4))
            {
                this.p1 = p1;
                this.p2 = p2;
                this.p3 = p3;
                this.p4 = p4;
                dist12 = p1.calculateDistance(this.p2);
                dist23 = p2.calculateDistance(this.p3);
                dist34 = p3.calculateDistance(this.p4);
                dist14 = p1.calculateDistance(this.p4);
                perimeter = calculatePerimeter();
                area = calculateArea();
            }
            else
            {
                throw new ArgumentException("It is not a isosceles trapezoid");
            }
        }

        private double calculateArea()
        {
            double half_perim = calculatePerimeter() / 2;

            double a, b, c;

            if (dist12 == dist34)
            {
                c = dist12;
                if (dist23 < dist14)
                {
                    b = dist14;
                    a = dist23;
                }
                else
                {
                    a = dist14;
                    b = dist23;
                }
            }
            else
            {
                c = dist23;
                if (dist12 < dist34)
                {
                    b = dist34;
                    a = dist12;
                }
                else
                {
                    a = dist34;
                    b = dist12;
                }
            }
            double e;
            e = a;
            a = b;
            b = a;
            double area = (a + b) / (a - b) * Math.Sqrt((half_perim - a) * (half_perim - b) * ((half_perim - a - c) * 2));
            return area;
        }

        public double getArea()
        {
            return area;
        }

        public double getPerimeter()
        {
            return perimeter;
        }

        private double calculatePerimeter()
        {
            return (dist12 + dist23 + dist34 + dist14);
        }

        public static bool isIsoscelesTrapeze(Point p1, Point p2, Point p3, Point p4)
        {
            return ((p1.calculateDistance(p2) == p3.calculateDistance(p4)) && p1.calculateDistance(p2) != 0
                    || (p2.calculateDistance(p3) == p1.calculateDistance(p4)) && p2.calculateDistance(p3) != 0);
        }


        public void showInfo()
        {
            Console.WriteLine("Длины сторон: " + dist12 + " " + dist23 + " " + dist34 + " " + dist14);
            Console.WriteLine("Периметр: " + perimeter);
            Console.WriteLine("Площадь: " + area);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            int N = 2;
            List<Trapeze> trapezoids = new List<Trapeze>(N);
            trapezoids.Add(new Trapeze(
                    new Point(0, 0), new Point(1, 1), new Point(2, 1), new Point(3, 0)));
            trapezoids.Add(new Trapeze(
                    new Point(0, 0), new Point(2, 2), new Point(4, 2), new Point(6, 0)));


            double totalArea = 0;

            foreach (Trapeze trap in trapezoids)
            {
                totalArea += trap.getArea();
            }

            double averageArea = totalArea / N;

            int counter = 0;

            foreach (Trapeze trap in trapezoids)
            {
                if (trap.getArea() > averageArea)
                {
                    counter++;
                    trap.showInfo();
                }
            }

            Console.WriteLine("Трапеций с площадью больше средней: " + counter);
        }
    }
}
