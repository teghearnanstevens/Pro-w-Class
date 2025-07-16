using System;
using System.IO;

public class Budget : Financial
{
    public static double BiWeeklyBudget = 0;
    public static double RemainingBudget = 0;

    public override void Load()
    {
        if (File.Exists("budget.txt"))
        {
            string[] lines = File.ReadAllLines("budget.txt");
            if (lines.Length >= 2 &&
                double.TryParse(lines[0], out double budget) &&
                double.TryParse(lines[1], out double remaining))
            {
                BiWeeklyBudget = budget;
                RemainingBudget = remaining;
                Console.WriteLine($"Loaded budget: ${BiWeeklyBudget:F2}, Remaining: ${RemainingBudget:F2}");
            }
            else
            {
                Console.WriteLine("Error reading budget file. Resetting budget.");
                BiWeeklyBudget = 0;
                RemainingBudget = 0;
            }
        }
    }

    public override void Save()
    {
        File.WriteAllLines("budget.txt", new string[]
        {
            BiWeeklyBudget.ToString(),
            RemainingBudget.ToString()
        });
    }

    public override void Process()
    {
        Console.Write("Enter your new bi-weekly budget amount: $");
        if (double.TryParse(Console.ReadLine(), out double newBudget))
        {
            BiWeeklyBudget = newBudget;
            RemainingBudget = newBudget;
            Console.WriteLine($"Budget set to ${BiWeeklyBudget:F2} for the next two weeks.");
            Save();
        }
        else
        {
            Console.WriteLine("Invalid input. Budget not changed.");
        }

        Console.WriteLine("Press Enter to return...");
        Console.ReadLine();
    }

    public static void ResetBudget()
    {
        RemainingBudget = BiWeeklyBudget;
        SaveStatic();
        Console.WriteLine("Budget has been reset to the full bi-weekly amount!");
    }

    public static void SubtractFromBudget(double amount)
    {
        RemainingBudget -= amount;
        SaveStatic();

        if (RemainingBudget < 0)
        {
            Console.WriteLine("WARNING: You are OVER budget! Stop spending!");
        }
        else
        {
            Console.WriteLine($"New Remaining Budget: ${RemainingBudget:F2}");
        }
    }

    public static void SaveStatic()
    {
        File.WriteAllLines("budget.txt", new string[]
        {
            BiWeeklyBudget.ToString(),
            RemainingBudget.ToString()
        });
    }

    public override void Display()
    {
        Console.Clear();
        Console.WriteLine("Budget Overview\n");
        Console.WriteLine($"Bi-Weekly Budget: ${BiWeeklyBudget:F2}");
        Console.WriteLine($"Remaining: ${RemainingBudget:F2}");

        if (RemainingBudget < 0)
        {
            Console.WriteLine("\nYou are over budget! Take immediate action!");
        }

        Console.WriteLine("\nPress Enter to return...");
        Console.ReadLine();
    }
}
