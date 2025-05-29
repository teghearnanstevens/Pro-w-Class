using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string filePath = Path.Combine(AppContext.BaseDirectory, @"..\..\..\Scriptures.txt");
        List<Scripture> scriptureList = Scripture.LoadScriptures(filePath);
        Scripture selectedScripture = null;

        bool running = true;

        while (running)
        {
            Console.Clear();

            if (selectedScripture != null)
            {
                Console.WriteLine("Current Scripture:\n");
                selectedScripture.DisplayScripture();
            }

            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Pick a Scripture");
            Console.WriteLine("2. Hide More Words");
            Console.WriteLine("3. Show All Words");
            Console.WriteLine("4. Practice Typing the Scripture");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option (1-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Available Scriptures:\n");
                    for (int i = 0; i < scriptureList.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {scriptureList[i].GetReference()}");
                    }

                    Console.Write("\nEnter the number of the scripture to select: ");
                    if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= scriptureList.Count)
                    {
                        selectedScripture = scriptureList[index - 1];
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection. Press Enter to continue.");
                        Console.ReadLine();
                    }
                    break;

                case "2":
                    if (selectedScripture != null)
                        selectedScripture.RemoveWord();
                    else
                        Console.WriteLine("Please select a scripture first.");
                    break;

                case "3":
                    if (selectedScripture != null)
                        selectedScripture.ShowAllWords();
                    else
                        Console.WriteLine("Please select a scripture first.");
                    break;

                case "4":
                    if (selectedScripture != null)
                    {
                        Console.Clear();
                        Console.WriteLine("Type the scripture from memory:");
                        string userInput = Console.ReadLine();

                        if (selectedScripture.CheckUserGuess(userInput))
                        {
                            Console.WriteLine("✅ Yes! You got it!");
                        }
                        else
                        {
                            Console.WriteLine("❌ Oops! That wasn't quite right. Try again!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please select a scripture first.");
                    }
                    break;

                    case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }
}
