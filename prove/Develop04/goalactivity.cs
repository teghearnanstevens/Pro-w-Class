
public class GoalEntry : BreathingAct
{
    private string _date;
    private string _prompt;
    private string _response;

    public GoalEntry(string date, string prompt, string response)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
    }

    public string FormatEntry()
    {
        return $"Date: {_date}\nPrompt: {_prompt}\nResponse: {_response}\n----------------------------------------";
    }

    public string ToFileLine()
    {
        return $"{_date}~|~{_prompt}~|~{_response}";
    }

    public static GoalEntry FromFileLine(string line)
    {
        string[] parts = line.Split("~|~");
        if (parts.Length == 3)
        {
            return new GoalEntry(parts[0], parts[1], parts[2]);
        }
        return null;
    }
        
        public GoalEntry()
        {
            Console.Write("Enter the date (e.g., 2025-06-10): ");
            _date = Console.ReadLine();

            Console.Write("What is your goal for today? ");
            _prompt = "Today's Goal";
            _response = Console.ReadLine();
        }

    }

