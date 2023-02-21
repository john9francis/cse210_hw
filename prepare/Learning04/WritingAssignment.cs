public class WritingAssignment : Assignment
{
    private string _title;
    public WritingAssignment(
        string name,
        string topic,
        string title
    ) : base(name,topic)
    {
        _title = title;
    }

    public string GetWritingInformation()
    {
        string _info = GetSummary();
        _info += "\n";
        _info += $"{_title} by {_studentName}";
        return _info;
    }
}