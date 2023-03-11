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
        return base.GetGoalString() + " each completion";
    }
    public override void SetGoal()
    {
        base.SetGoal();
        // setting the point value:
        _pointValue = _difficulty * 10;
    }

    public override int GetPoints()
    {
        return base.GetPoints() + _timesCompleted * _pointValue;
    }

}