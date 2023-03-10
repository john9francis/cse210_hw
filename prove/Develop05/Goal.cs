public class Goal
{
    private bool _completed;
    private string _goalName;
    private int _difficulty;
    private int _pointValue;
    private string _goalType;

    public Goal(string goalName="goal", int difficulty=0, string goalType="normal")
    {
        _completed = false;
        _goalName = goalName;
        _difficulty = difficulty;
        _pointValue = _difficulty*100;
        _goalType = goalType;
    }

    public void CompleteGoal()
    {
        _completed = true;
    }

    public void SetGoal()
    {
        Console.Write("Enter name of goal: ");
        _goalName = Console.ReadLine();
        Console.Write("Enter difficulty.(1=easiest, 3=hardest)");
        int diff = int.Parse(Console.ReadLine());
        _difficulty = diff;

        // setting the point value:
        _pointValue = _difficulty * 100;
    }

    public string GetGoalString()
    {
        string _status = _completed ? "x" : "_";
        return $"{_status} {_goalType} {_goalName} - difficulty: {_difficulty} - {_pointValue} points";
    }
}