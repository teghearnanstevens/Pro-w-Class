public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public override bool IsComplete() => _isComplete;

    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override string GetStatus()
    {
        return _isComplete ? "[X]" : "[ ]";
    }

    public override string GetDetails()
    {
        return $"{GetStatus()} {GetName()} ({GetDescription()})";
    }

    public override string Serialize()
    {
        return $"SimpleGoal|{_name}|{_description}|{_points}|{_isComplete}";
    }
}
