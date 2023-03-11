public class EternalGoal : Goal
{
    // Note: there should be no way to make _completed = true.
    private int _timesCompleted;
    public EternalGoal()
    {
        _goalType = "Eternal";
        _goalName = "New Eternal Goal";
        _timesCompleted = 0;
    }

    public override void CompleteGoal()
    {
        _timesCompleted ++;
    }
    public override string GetGoalString()
    {
        return base.GetGoalString() + 
        $" - Completed {_timesCompleted} times";
    }
    public override void SetPointValue()
    {
        _pointValue = _difficulty * 10;
    }

    public override int GetPoints()
    {
        return base.GetPoints() + _timesCompleted * _pointValue;
    }
    public override List<string> GetGoalVector()
    {
        List<string> vec = base.GetGoalVector();
        vec.Add($"{_timesCompleted}");
        return vec;
    }

    public override void ReverseGoalVector(List<string> goalVec)
    {
        base.ReverseGoalVector(goalVec);
        _timesCompleted = int.Parse(goalVec[4]);
    }

}