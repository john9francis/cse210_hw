using System;
namespace Learning02
{

class Program
{
    static void Main(string[] args)
    {
        // defining 2 jobs;
        Job job1 = new Job();
        job1._jobTitle = "Programmer";
        job1._company = "Microsoft";
        job1._startYear = 2020;
        job1._endYear = 2021;

        Job job2 = new Job();
        job2._jobTitle = "Software engineer";
        job2._company = "Apple";
        job2._startYear = 2019;
        job2._endYear = 2023;

        // adding jobs to resume;
        Resume resume1 = new Resume();
        resume1._name = "John Francis";
        resume1._jobList.Add(job1);
        resume1._jobList.Add(job2);

        // displaying the resume;
        resume1.DisplayResume();



    }
}
}