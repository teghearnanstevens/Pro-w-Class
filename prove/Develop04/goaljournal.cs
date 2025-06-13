using System;
using System.Collections.Generic;
using System.IO;

public class GoalJournal
{
    private List<GoalEntry> _goals = new List<GoalEntry>();

    public void AddGoal(GoalEntry goal)
    {
        _goals.Add(goal);
    }

    public void DisplayGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to display.");
            return;
        }

        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.FormatEntry());
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.ToFileLine());
            }
        }
        Console.WriteLine($"Goals saved to {filename}");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("No saved goals yet.");
            return;
        }

        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            GoalEntry goal = GoalEntry.FromFileLine(line);
            if (goal != null)
            {
                _goals.Add(goal);
            }
        }

        Console.WriteLine($"Goals loaded from {filename}");
    }
}
