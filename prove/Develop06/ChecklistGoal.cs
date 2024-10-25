public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;

            if (_amountCompleted == _target)
            {
                Console.WriteLine($"Bonus! You've earned an additional {_bonus} points.");
            }
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetStringRepresentation()
    {
        string status = IsComplete() ? "[/]" : "[ ]";
        return $"{status} {base.GetDetailString()} (Completed {_amountCompleted}/{_target})";
    }
}
