using System;
using System.Collections.Generic;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        Console.WriteLine("Welcome to the Eternal Quest!");

        while (true)
        {
            Console.WriteLine($"\nCurrent Score: {_score}");
            Console.WriteLine();

            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Record an event (mark goal progress)");
            Console.WriteLine("4. Display player score");
            Console.WriteLine("5. Save goals");
            Console.WriteLine("6. Load goals");
            Console.WriteLine("7. Exit");

            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalNames();
                    break;
                case "3":
                    RecordEventPrompt();
                    break;
                case "4":
                    DisplayPlayerInfo();
                    break;
                case "5":
                    SaveGoals();
                    break;
                case "6":
                    LoadGoals();
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Current Score: {_score}");
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStringRepresentation()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("Creating a new goal...");

        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Select the type of goal: ");

        string choice = Console.ReadLine();

        Console.Write("Enter the name of the goal: ");
        string name = Console.ReadLine();

        Console.Write("Enter the description for the goal: ");
        string description = Console.ReadLine();

        Console.Write("Enter the points for the goal: ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case "1":
                SimpleGoal newSimpleGoal = new SimpleGoal(name, description, points);
                _goals.Add(newSimpleGoal);
                break;
            case "2":
                EternalGoal newEternalGoal = new EternalGoal(name, description, points);
                _goals.Add(newEternalGoal);
                break;
            case "3":
                Console.Write("Enter the target number of completions: ");
                int target = int.Parse(Console.ReadLine());

                Console.Write("Enter the bonus points for this goal: ");
                int bonus = int.Parse(Console.ReadLine());

                ChecklistGoal newChecklistGoal = new ChecklistGoal(name, description, points, target, bonus);
                _goals.Add(newChecklistGoal);
                break;
            default:
                Console.WriteLine("Invalid choice. Goal not created.");
                return;
        }

        Console.WriteLine("Goal added successfully!");
    }

    public void RecordEventPrompt()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record.");
            return;
        }

        ListGoalNames();

        Console.Write("Select a goal number to record progress: ");
        int goalIndex;
        while (!int.TryParse(Console.ReadLine(), out goalIndex) || goalIndex < 1 || goalIndex > _goals.Count)
        {
            Console.Write("Please select a valid goal number: ");
        }

        RecordEvent(goalIndex - 1);
    }

    public void RecordEvent(int goalIndex)
    {
        Goal selectedGoal = _goals[goalIndex];
        selectedGoal.RecordEvent();

        _score += selectedGoal.Points;
        Console.WriteLine($"Event recorded! You've earned {selectedGoal.Points} points.");
    }

    public void SaveGoals()
    {
        string filePath = "goals.txt";

        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(_score);
                foreach (var goal in _goals)
                {
                    writer.WriteLine($"{goal.Name},{goal.Description},{goal.Points}");
                }
            }

            Console.WriteLine("Goals saved successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving goals: {ex.Message}");
        }
    }

    public void LoadGoals()
    {
        string filePath = "goals.txt";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("No saved goals found.");
            return;
        }

        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                _score = int.Parse(reader.ReadLine());
                _goals.Clear();

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    string name = parts[0];
                    string description = parts[1];
                    int points = int.Parse(parts[2]);

                    SimpleGoal loadedGoal = new SimpleGoal(name, description, points);
                    _goals.Add(loadedGoal);
                }
            }

            Console.WriteLine("Goals loaded successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading goals: {ex.Message}");
        }
    }
}