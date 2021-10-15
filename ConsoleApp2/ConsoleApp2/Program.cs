using System;

enum Week
{
    p1 = 1,
    v2,
    s3,
    ch4,
    p5,
    s6,
    v7
};
class Program
{

    static void Main(string[] args)
    {
        Console.WriteLine("Введите число(от 1 до 7): ");
        int mb = Convert.ToInt32(Console.ReadLine());
        TellAboutWeek(mb);

    }
    private static void TellAboutWeek(int mb)
    {
	    Week output;
        switch (mb)
        {
            case 1:
	            output = Week.p1;
                Console.WriteLine(output);
                break;
            case 2:
	            output = Week.v2;
                Console.WriteLine(output);
                break;
            case 3:
	            output = Week.s3;
                Console.WriteLine(output);
                break;
            case 4:
	            output = Week.ch4;
                Console.WriteLine(output);
                break;
            case 5:
	            output = Week.p5;
                Console.WriteLine(output);
                break;
            case 6:
	            output = Week.s6;
                Console.WriteLine(output);
                break;
            case 7:
	            output = Week.v7;
                Console.WriteLine(output);
                break;
        }
    }
}
