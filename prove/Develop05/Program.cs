using System;

class Program
{
    static void Main(string[] args)
    {
        
        Goal g1 = new Goal();
        g1.CompleteGoal();

        GoalMenu m1 = new GoalMenu();
        m1.AddGoal(g1);

        m1.RunMenu();
    }
}