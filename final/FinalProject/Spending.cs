using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Spending : Financial
{
    private List<double> _userSpending = new List<double>();

    public override void Load()
    {
        if (File.Exists("spending.txt"))
        {
            string data = File.ReadAllText("spending.txt");
            string[] parts = data.Split(',');
            _userSpending = parts.Select(double.Parse).ToList();
        }
    }

    public override void Save()
    {
        File.WriteAllText("spending.txt", string.Join(",", _userSpending));
    }

    public override void Process()
    {
        Console.Write("Enter amount spent: $");
        if (double.TryParse(Console.ReadLine(), out double amount))
        {
            _userSpending.Add(amount);
            Budget.SubtractFromBudget(amount); 
            Console.WriteLine("Spending recorded.");
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
        Save();
        Console.WriteLine("Press Enter to return...");
        Console.ReadLine();
    }

    public override void Display()
    {
        Console.Clear();
        Console.WriteLine("Spending Entries\n");

        if (_userSpending.Count == 0)
        {
            Console.WriteLine("No spending records yet.");
        }
        else
        {
            double total = 0;
            for (int i = 0; i < _userSpending.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] ${_userSpending[i]:0.00}");
                total += _userSpending[i];
            }
            Console.WriteLine($"\nTotal spent: ${total:0.00}");
        }
    }
}
