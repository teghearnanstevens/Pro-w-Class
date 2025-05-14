namespace JournalApp
{
    public class JournalEntry
    {
        private string _date;
        private string _prompt;
        private string _response;

        public JournalEntry(string date, string prompt, string response)
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

        public static JournalEntry FromFileLine(string line)
        {
            string[] parts = line.Split("~|~");
            if (parts.Length == 3)
            {
                return new JournalEntry(parts[0], parts[1], parts[2]);
            }
            return null;
        }
    }
}
