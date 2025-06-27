using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public int GetScore() => _score;
    public List<Goal> GetGoals() => _goals;

    public void CreateGoal()
    {
        Console.WriteLine("\nChoose Goal Type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        string type = Console.ReadLine();

        Console.Write("Name: "); string name = Console.ReadLine();
        Console.Write("Description: "); string desc = Console.ReadLine();
        Console.Write("Points: "); int points = int.Parse(Console.ReadLine());

        if (type == "1") _goals.Add(new SimpleGoal(name, desc, points));
        else if (type == "2") _goals.Add(new EternalGoal(name, desc, points));
        else if (type == "3")
        {
            Console.Write("Target Completions: "); int target = int.Parse(Console.ReadLine());
            Console.Write("Bonus Points: "); int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
        }
    }

    public void ListGoals()
    {
        Console.WriteLine("\nGoals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetails()}");
        }
        Console.ReadLine();
    }

    public void RecordEvent()
    {
        Console.WriteLine("\nSelect a goal to record:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetails()}");
        }

        Console.Write("Enter number: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= _goals.Count)
        {
            index -= 1;
            _goals[index].RecordEvent();
            _score += _goals[index].GetPoints();

            if (_goals[index] is ChecklistGoal checklist && checklist.IsComplete())
            {
                _score += checklist.GetBonus();
                Console.WriteLine("Checklist goal complete! Bonus points awarded!");
            }

            Console.WriteLine("Event recorded! Points awarded.");
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }

        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    public void SaveGoals(string filename = "goals.txt")
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal g in _goals)
                writer.WriteLine(g.Serialize());
        }
    }

    public void LoadGoals(string filename = "goals.txt")
    {
        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');
            switch (parts[0])
            {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3])));
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                    break;
                case "ChecklistGoal":
                    ChecklistGoal cg = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[5]), int.Parse(parts[6]));
                    for (int j = 0; j < int.Parse(parts[4]); j++) cg.RecordEvent();
                    _goals.Add(cg);
                    break;
            }
        }
    }
}
