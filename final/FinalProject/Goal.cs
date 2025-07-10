public class Goal : Financial
{
    private double _goal;

    public override void Load()
    {
        if (File.Exists("goal.txt"))
        {
            string data = File.ReadAllText("goal.txt");
            if (double.TryParse(data, out double result))
            {
                _goal = result;
                Console.WriteLine($"✅ Loaded budget: {_goal}");
            }
        }
    }

    public override void Save()
    { 
         File.WriteAllText("goal.txt", _goal.ToString());
    }

    public override void Process()
    {
        Console.Write("Enter your financial goal: ");
        _goal = double.Parse(Console.ReadLine());
        Console.WriteLine($"🎯 Goal set to: {_goal}");
    }

    public double GetGoal() => _goal;
}
