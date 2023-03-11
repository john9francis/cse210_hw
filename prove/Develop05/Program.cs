using System;

class Program
{
    static void Main(string[] args)
    {
        GoalMenu m1 = new GoalMenu();
        m1.RunMenu();

        /*
        Goal n = new ChecklistGoal();
        List<string> g = new List<string>();
        g = n.GetGoalVector();

        Goal n2 = new ChecklistGoal();
        List<string> g2 = new List<string>();
        g2 = n2.GetGoalVector();

        Goal n3 = new EternalGoal();
        List<string> g3 = new List<string>();
        g3 = n3.GetGoalVector();

        Progress p = new Progress();
        p.SetFilename("test.txt");

        // save
        p.SetGoalVector(g);
        p.SetGoalVector(g3);
        p.SaveGoalVectors();

        //// load
        //p.LoadGoalVectors();
        //p.DisplayGoalVectors();
        */
    }
}