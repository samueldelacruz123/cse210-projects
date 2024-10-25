public class Goal
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Points { get; private set; }

    public Goal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
    }

    public virtual void RecordEvent()
    {
    }

    public virtual bool IsComplete()
    {
        return false;
    }

    public virtual string GetDetailString()
    {
        return $"{Name}: {Description} ({Points} points)";
    }

    public virtual string GetStringRepresentation()
    {
        return $"Goal: {Name}, Description: {Description}, Points: {Points}";
    }
}
