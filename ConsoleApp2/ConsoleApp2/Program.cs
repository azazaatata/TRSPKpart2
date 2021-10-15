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
	    output = (Week) mb;
	    Console.WriteLine(output);
    }
}
