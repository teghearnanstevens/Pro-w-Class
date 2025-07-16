using System;
using System.Collections.Generic;
using System.IO;

public class Goal : Financial
{
    private double _goal;

    private List<GoalItem> _goals = new List<GoalItem>();

    public override void Load()
    {
        if (File.Exists("goal.txt"))
        {
            string data = File.ReadAllText("goal.txt");
            if (double.TryParse(data, out double result))
            {
                _goal = result;
                Console.WriteLine($"Loaded goal: {_goal}");
            }
        }

        if (File.Exists("goals_list.txt"))
        {
            string[] lines = File.ReadAllLines("goals_list.txt");
            foreach (string line in lines)
            {                 
                string[] parts = line.Split('|');
                if (parts.Length == 2)
                {
                    string description = parts[0];
                    bool isComplete = bool.Parse(parts[1]);
                    _goals.Add(new GoalItem(description, isComplete));
                }
            }
        }
    }

    public override void Save()
    {
        File.WriteAllText("goal.txt", _goal.ToString());

        List<string> lines = new List<string>();
        foreach (var goal in _goals)
        {
            lines.Add($"{goal.Description}|{goal.IsComplete}");
        }
        File.WriteAllLines("goals_list.txt", lines);
    }

     public override void Process()
    {
        Console.Write("Enter a new goal description: ");
        string description = Console.ReadLine();
        _goals.Add(new GoalItem(description));
        Console.WriteLine("Goal added!");
    }

    public override void Display()
    {
        Console.WriteLine("Use the Checklist menu (option 6) to view goals.");
    }

    public double GetGoal() => _goal;

    public class GoalItem
    {
        public string Description { get; set; }
        public bool IsComplete { get; set; }

        public GoalItem(string description, bool isComplete = false)
        {
            Description = description;
            IsComplete = isComplete;
        }
    }
}
