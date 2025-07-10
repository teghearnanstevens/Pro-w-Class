using System;
using System.Collections.Generic;
using System.IO;


public abstract class FinBackEnd
{

    protected string _saves;
    public List<Saves> saves = new List<Saves>();

    public FinBackEnd(string saveFile)
    {
        _saves = saveFile;
    }

    public void Saver(string filename = "saves.txt")
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Saves g in saves)
            {
                writer.WriteLine(g.Serialize());
            }
        }
    }

    public class Saves
    {
        public string Data { get; set; }

        public string Serialize()
        {
            return Data;
        }
    }

    public class Calculations
    {

    public static double TotalSpent(List<double> amounts)
    {
        double total = 0;
        foreach (double amount in amounts)
        {
            total += amount;
        }
        return total;
    }

    public static double BudgetUtilization(double spent, double budget)
    {
        if (budget == 0) return 0;
        return (spent / budget) * 100;
    }

    public static double RemainingBudget(double budget, double spent)
    {
        return budget - spent;
    }

    public static double GoalProgress(double saved, double goal)
    {
        if (goal == 0) return 0;
        return (saved / goal) * 100;
    }

    }

    public class QuestionsBackEnd
    {
        private Dictionary<string, string> _faq = new Dictionary<string, string>()
    {
        { "What is a budget?", "A budget is a plan for how to spend and save your money." },
        { "Why track spending?", "Tracking spending helps you stay within your budget and reach goals." },
        { "How do I save more?", "Reduce unnecessary expenses and set aside money regularly." }
    };

        public string Ask(string question)
        {
            if (_faq.ContainsKey(question))
            {
                return _faq[question];
            }
            else
            {
                return "Sorry, I don't have an answer to that question yet.";
            }
        }

        public void AddQuestion(string question, string answer)
        {
            _faq[question] = answer;
        }

        public void PrintAll()
        {
            foreach (var pair in _faq)
            {
                Console.WriteLine($"{pair.Key} => {pair.Value}");
            }
        }
    
           public List<string> GetAllQuestions()
        {
             return new List<string>(_faq.Keys);
        }

}

    

}