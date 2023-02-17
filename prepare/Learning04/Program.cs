using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment a = new Assignment("John", "Math");
        Console.WriteLine(a.GetSummary());

        MathAssignment ma = new MathAssignment("John","Math","section 1","problems 1-2");
        Console.WriteLine(ma.GetHomeworkList());
        Console.WriteLine(ma.GetSummary());

        WritingAssignment wa = new WritingAssignment("John","writing","The power of classes");
        Console.WriteLine(wa.GetWritingInformation());
        Console.WriteLine(wa.GetSummary());
    }
}