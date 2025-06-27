public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override bool IsComplete() => false;

    public override void RecordEvent()
    {
        // never complete, always gives points
    }

    public override string GetStatus()
    {
        return "[~]";
    }

    public override string GetDetails()
    {
        return $"{GetStatus()} {GetName()} ({_description})";
    }

    public override string Serialize()
    {
        return $"EternalGoal|{_name}|{_description}|{_points}";
    }
}