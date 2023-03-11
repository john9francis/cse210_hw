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
    public string GetGoalType()
    {
        return _goalType;
    }
    public bool IsCompleted()
    {
        return _completed;
    }
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
        SetPointValue();
    }

    public abstract void SetPointValue();

    public virtual int GetPoints()
    {
        return _completed ? _pointValue : 0;
    }

    public virtual List<string> GetGoalVector()
    {
        List<string> vec = new List<string>();
        vec.Add(_goalType);
        vec.Add(_goalName);
        vec.Add($"{_difficulty}");
        vec.Add($"{_completed}");
        return vec;
    }
    public virtual void ReverseGoalVector(List<string> goalVec)
    {
        _goalType = goalVec[0];
        _goalName = goalVec[1];
        _difficulty = int.Parse(goalVec[2]);
        if (goalVec[3] == "True")
        {
            _completed = true;
        }
        else if (goalVec[3] == "False")
        {
            _completed = false;
        }
        SetPointValue();
    }
}