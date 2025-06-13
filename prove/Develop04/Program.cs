using System;

class Program
{
    static void Main()
    {
        bool running = true;
        GoalJournal goalJournal = new GoalJournal();

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program\n");
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Breathing Exercises");
            Console.WriteLine("2. Reflection Exercises");
            Console.WriteLine("3. Listing Exercises");
            Console.WriteLine("4. Set a New Goal");
            Console.WriteLine("5. Load Past Goals");
            Console.WriteLine("6. Quit");
            Console.Write("\nChoose an option (1-6): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingAct breathing = new BreathingAct();
                    breathing.Run();
                    break;
                case "2":
                    ReflectionActivity reflection = new ReflectionActivity();
                    reflection.Run();
                    break;
                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    break;
                case "4":
                    GoalEntry newGoal = new GoalEntry(); // uses your interactive constructor
                    goalJournal.AddGoal(newGoal);
                    goalJournal.SaveToFile("goals.txt");
                    Console.WriteLine("\nGoal saved! Press Enter to continue.");
                    Console.ReadLine();
                    break;
                case "5":
                    goalJournal.LoadFromFile("goals.txt");
                    goalJournal.DisplayGoals();
                    Console.WriteLine("\nPress Enter to continue.");
                    Console.ReadLine();
                    break;
                case "6":
                    running = false;
                    Console.WriteLine("\nThanks for using the Mindfulness Program. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Press Enter to try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
