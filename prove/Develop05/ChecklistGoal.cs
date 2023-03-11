public class ChecklistGoal : Goal
{
    private int _timesToComplete;
    private int _timesCompleted;
    public ChecklistGoal()
    {
        _goalType = "Checklist";
        _goalName = "New Checklist Goal";
        _timesCompleted = 0;
        _timesToComplete = 0;
    }
    public override void CompleteGoal()
    {
        if (!_completed)
        {
            _timesCompleted ++;
        }
        if (_timesCompleted == _timesToComplete)
        {
            _completed = true;
        }
    }
    public override string GetGoalString()
    {
        return base.GetGoalString() + 
        $" - Completed [{_timesCompleted}/{_timesToComplete}] times";
    }
    public override void SetGoal()
    {
        base.SetGoal();
        bool x= true;
        while (x)
        {
        Console.Write(
            "How many times do you need to check-off " + 
            "this goal before it's complete? ");
        try
        {
            _timesToComplete = int.Parse(Console.ReadLine());
            x = false;
        }
        catch (FormatException)
        {
            Console.WriteLine("Please enter a number.");
        }
        }
    }
    public override void SetPointValue()
    {
        _pointValue = _difficulty * 10;
    }

    public override int GetPoints()
    {
        int bonus = 0;
        if (_completed)
        {
            bonus = _difficulty*100;
        }
        return base.GetPoints() + _timesCompleted * _pointValue + bonus;
    }

    public override List<string> GetGoalVector()
    {
        List<string> vec = base.GetGoalVector();
        vec.Add($"{_timesCompleted}");
        vec.Add($"{_timesToComplete}");
        return vec;
    }

    public override void ReverseGoalVector(List<string> goalVec)
    {
        base.ReverseGoalVector(goalVec);
        _timesCompleted = int.Parse(goalVec[4]);
        _timesToComplete = int.Parse(goalVec[5]);
    }
}