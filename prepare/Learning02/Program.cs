using System;
namespace Learning02
{

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "programmer";
        job1._company = "Microsoft";
        job1._startYear = 2020;
        job1._endYear = 2021;

        Console.WriteLine($"{job1._jobTitle}, {job1._company}, {job1._startYear}, {job1._endYear}");

    }
}
}