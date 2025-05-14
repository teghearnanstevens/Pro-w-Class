using System;
using System.Collections.Generic;
using System.IO;

namespace JournalApp
{
    public class Journal
    {
        private List<JournalEntry> _entries = new List<JournalEntry>();

        public void AddEntry(JournalEntry entry)
        {
            _entries.Add(entry);
        }

        public void DisplayEntries()
        {
            if (_entries.Count == 0)
            {
                Console.WriteLine("No entries to display.");
                return;
            }

            foreach (var entry in _entries)
            {
                Console.WriteLine(entry.FormatEntry());
            }
        }

        public void SaveToFile(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var entry in _entries)
                {
                    writer.WriteLine(entry.ToFileLine());
                }
            }
            Console.WriteLine($"Journal saved to {filename}");
        }

        public void LoadFromFile(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }

            _entries.Clear();
            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                JournalEntry entry = JournalEntry.FromFileLine(line);
                if (entry != null)
                {
                    _entries.Add(entry);
                }
            }

            Console.WriteLine($"Journal loaded from {filename}");
        }
    }
}
