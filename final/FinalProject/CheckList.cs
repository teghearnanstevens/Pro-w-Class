using System;
using System.Collections.Generic;
using System.IO;

public class CheckList : Financial
{
    private List<(string Goal, bool IsCompleted)> _checklistGoals = new();

    public override void Load()
    {
        if (File.Exists("checklist.txt"))
        {
            var lines = File.ReadAllLines("checklist.txt");
            _checklistGoals.Clear();
            foreach (var line in lines)
            {
                var parts = line.Split('|');
                if (parts.Length == 2)
                {
                    string goal = parts[0];
                    if (bool.TryParse(parts[1], out bool completed))
                    {
                        _checklistGoals.Add((goal, completed));
                    }
                    else
                    {
                        _checklistGoals.Add((goal, false)); // Fallback if corrupt
                    }
                }
            }
        }
    }

    public override void Save()
    {
        List<string> lines = new();
        foreach (var item in _checklistGoals)
        {
            lines.Add($"{item.Goal}|{item.IsCompleted}");
        }
        File.WriteAllLines("checklist.txt", lines);
    }

    public override void Display()
    {
        Console.Clear();
        Console.WriteLine("Goal Checklist\n");

        if (_checklistGoals.Count == 0)
        {
            Console.WriteLine("No goals in your checklist.");
        }
        else
        {
            for (int i = 0; i < _checklistGoals.Count; i++)
            {
                string box = _checklistGoals[i].IsCompleted ? "[X]" : "[ ]";
                Console.WriteLine($"{i + 1}. {box} {_checklistGoals[i].Goal}");
            }
        }

        Console.WriteLine("\nPress Enter to return...");
        Console.ReadLine();
    }

    public override void Process()
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Checklist Goals:\n");
            for (int i = 0; i < _checklistGoals.Count; i++)
            {
                string box = _checklistGoals[i].IsCompleted ? "[X]" : "[ ]";
                Console.WriteLine($"{i + 1}. {box} {_checklistGoals[i].Goal}");
            }

            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Add a new goal");
            Console.WriteLine("2. Toggle goal completion");
            Console.WriteLine("3. Exit checklist");
            Console.Write("\nChoose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter new goal: ");
                    string newGoal = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newGoal))
                    {
                        _checklistGoals.Add((newGoal, false));
                    }
                    break;

                case "2":
                    Console.Write("Enter goal number to toggle: ");
                    if (int.TryParse(Console.ReadLine(), out int num) &&
                        num >= 1 && num <= _checklistGoals.Count)
                    {
                        var current = _checklistGoals[num - 1];
                        _checklistGoals[num - 1] = (current.Goal, !current.IsCompleted);
                    }
                    else
                    {
                        Console.WriteLine("Invalid number. Press Enter...");
                        Console.ReadLine();
                    }
                    break;

                case "3":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option. Press Enter...");
                    Console.ReadLine();
                    break;
            }

            Save();
        }
    }

        public void AddGoalOnly()
    {
        Console.Clear();
        Console.Write("Enter a new goal: ");
        string newGoal = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newGoal))
        {
            _checklistGoals.Add((newGoal, false));
            Save();
            Console.WriteLine("Goal added successfully!");
        }
        else
        {
            Console.WriteLine("Empty goal not added.");
        }
        Console.WriteLine("Press Enter to return...");
        Console.ReadLine();
    }

    public void ViewAndToggleChecklist()
    {
        Process(); 
    }

}
