using System;
namespace Learning02
{
    public class Job
        {
            public string _jobTitle = "";
            public string _company = "";
            public int _startYear = 0;
            public int _endYear = 0;

            public void DisplayJobDetails()
            {
                Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
            }
        }
}

