using System;

namespace JournalApp
{
    class Program
    {
        static void Main()
        {
            Journal journal = new Journal();
            PromptGenerator promptGen = new PromptGenerator();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n--- Journal Menu ---");
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display journal entries");
                Console.WriteLine("3. Save journal to file");
                Console.WriteLine("4. Load journal from file");
                Console.WriteLine("5. Quit");
                Console.Write("Choose an option (1-5): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        string prompt = promptGen.GetRandomPrompt();
                        Console.WriteLine($"\nPrompt: {prompt}");
                        Console.Write("Your response: ");
                        string response = Console.ReadLine();
                        string date = DateTime.Now.ToShortDateString(); 
                        JournalEntry entry = new JournalEntry(date, prompt, response);
                        journal.AddEntry(entry);
                        break;

                    case "2":
                        journal.DisplayEntries();
                        break;

                    case "3":
                        Console.Write("Enter filename to save: ");
                        string saveFile = Console.ReadLine();
                        journal.SaveToFile(saveFile);
                        break;

                    case "4":
                        Console.Write("Enter filename to load: ");
                        string loadFile = Console.ReadLine();
                        journal.LoadFromFile(loadFile);
                        break;

                    case "5":
                        running = false;
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
    }
}

