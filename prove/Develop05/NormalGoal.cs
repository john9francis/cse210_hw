public class NormalGoal : Goal
{
    public NormalGoal()
    {
        _goalType = "Normal";
        _goalName = "New Normal Goal";
    }
    public override void CompleteGoal()
    {
        _completed = true;
    }
    public override string GetGoalString()
    {
        string status = _completed ? "X" : " ";
        return $"[{status}] " + base.GetGoalString();
    }
    public override void SetPointValue()
    {
        _pointValue = _difficulty * 100;
    }
}