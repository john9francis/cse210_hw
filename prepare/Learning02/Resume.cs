using System;
namespace Learning02
{
public class Resume
{
    public string _name = "";
    public List<Job> _jobList = new List<Job>();

    public void DisplayResume()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine($"Jobs:");
        foreach (var j in _jobList) {
            j.DisplayJobDetails();
        }
    }
}
}