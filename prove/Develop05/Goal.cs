public abstract class Goal
{
    protected bool _completed;
    protected string _goalName;
    protected int _difficulty;
    protected int _pointValue;
    protected string _goalType;

    public Goal()
    {
        _completed = false;
        _goalName = "name";
        _difficulty = 0;
        _pointValue = 0;
        _goalType = "type";
    }

    public abstract void CompleteGoal();
    public virtual string GetGoalString()
    {
        return $"({_goalType}) {_goalName} - "+
        $"difficulty: {_difficulty} - {_pointValue} points";
    }

    public virtual void SetGoal()
    {
        Console.Write("Enter name of goal: ");
        _goalName = Console.ReadLine();
        Console.Write("Enter difficulty. (1=easiest, 3=hardest): ");
        int diff = int.Parse(Console.ReadLine());
        _difficulty = diff;
    }

    public virtual int GetPoints()
    {
        return _completed ? _pointValue : 0;
    }
}