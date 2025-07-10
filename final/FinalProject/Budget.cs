public class Budget : Financial
{
    private double _budgetAmount;

    public override void Load()
    {
            if (File.Exists("budget.txt"))
        {
            string data = File.ReadAllText("budget.txt");
            if (double.TryParse(data, out double result))
            {
                _budgetAmount = result;
                Console.WriteLine($"✅ Loaded budget: {_budgetAmount}");
            }
        }
    }

    public override void Save()
    {
        File.WriteAllText("budget.txt", _budgetAmount.ToString());
    }

    public override void Process()
    {
        Console.Write("Enter your budget: ");
        _budgetAmount = double.Parse(Console.ReadLine());
        Console.WriteLine($"✅ Budget set to: {_budgetAmount}");
    }

    public double GetBudget() => _budgetAmount;
}
