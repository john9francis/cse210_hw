using System;

class Program
{
    static void Main(string[] args)
    {
        GoalMenu m1 = new GoalMenu();
        //m1.RunMenu();
        NormalGoal n = new NormalGoal();
        EternalGoal e = new EternalGoal();
        ChecklistGoal c = new ChecklistGoal();

        List<Goal> l = new List<Goal>();
        l.Add(n);
        l.Add(e);
        l.Add(c);

        foreach (Goal g in l)
        {
            Console.WriteLine(g.GetGoalString());
        }

        m1._goals.Add(n);
        m1._goals.Add(e);
        m1._goals.Add(c);
        //m1.DisplayGoals();
    }
}