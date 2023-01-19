using System;
namespace Learning02
{

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Programmer";
        job1._company = "Microsoft";
        job1._startYear = 2020;
        job1._endYear = 2021;

        Job job2 = new Job();
        job2._company = "Apple";

        job1.DisplayJobDetails();
        job2.DisplayJobDetails();

        Resume resume1 = new Resume();
        resume1._


    }
}
}