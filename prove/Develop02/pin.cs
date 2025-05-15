using System;
using System.IO;

namespace JournalApp
{
    public class SecretJournal
    {
        private string _password = null; // Holds the password until the app closes

        public void StartSecretEntryFlow()
        {
            if (_password == null)
            {
                Console.Write("\nSet a password for secret journal access: ");
                string password1 = Console.ReadLine();
                Console.Write("Re-enter password to confirm: ");
                string password2 = Console.ReadLine();

                if (password1 != password2)
                {
                    Console.WriteLine("Passwords do not match. Try again.");
                    return;
                }

                _password = password1;
                Console.WriteLine("Password set successfully.");
            }

            Console.Write("Enter password to access secret journal: ");
            string verify = Console.ReadLine();

            if (verify != _password)
            {
                Console.WriteLine("Incorrect password. Access denied.");
                return;
            }

            Console.WriteLine("Access granted to secret journal.");
            Console.Write("Write your secret entry: ");
            string secretEntry = Console.ReadLine();
            string secretDate = DateTime.Now.ToShortDateString();

            string secretRecord = $"Date: {secretDate}\nSecret Entry: {secretEntry}\n---\n";
            File.AppendAllText("secret_journal.txt", secretRecord);
            Console.WriteLine("Secret entry saved.");
        }


        public void ViewSecretEntries()
{
    if (_password == null)
    {
        Console.WriteLine("No password has been set yet.");
        return;
    }

    Console.Write("Enter password to view secret journal: ");
    string input = Console.ReadLine();

    if (input != _password)
    {
        Console.WriteLine("Incorrect password. Access denied.");
        return;
    }

    if (!File.Exists("secret_journal.txt"))
    {
        Console.WriteLine("No secret journal entries found.");
        return;
    }

    Console.WriteLine("\n--- Secret Journal Entries ---\n");
    string[] lines = File.ReadAllLines("secret_journal.txt");

    foreach (string line in lines)
    {
        Console.WriteLine(line);
    }
}
    }
}
