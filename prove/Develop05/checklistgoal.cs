public class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _targetCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
        : base(name, description, points)
    {
        _timesCompleted = 0;
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
    }

    public override bool IsComplete() => _timesCompleted >= _targetCount;

    public override void RecordEvent()
    {
        _timesCompleted++;
    }

    public override string GetStatus()
    {
        return IsComplete() ? "[X]" : "[ ]";
    }

    public override string GetDetails()
    {
        return $"{GetStatus()} {GetName()} ({_description}) -- Completed {_timesCompleted}/{_targetCount}";
    }

    public override string Serialize()
    {
        return $"ChecklistGoal|{_name}|{_description}|{_points}|{_timesCompleted}|{_targetCount}|{_bonusPoints}";
    }

    public int GetBonus() => IsComplete() ? _bonusPoints : 0;
}
