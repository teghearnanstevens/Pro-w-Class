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
            Console.WriteLine($"✅ Loaded {parts.Length} spending entries.");
        }
    }

    public override void Save()
    { 
        File.WriteAllText("spending.txt", string.Join(",", _userSpending));
    }

    public override void Process()
    {
        Console.Write("Enter amount spent: ");
        double amount = double.Parse(Console.ReadLine());
        _userSpending.Add(amount);
        Console.WriteLine("💸 Spending recorded.");
    }

    public List<double> GetSpendings() => _userSpending;
}
