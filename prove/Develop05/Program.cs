using System;

class Program
{
    static GoalManager goalManager = new GoalManager();
    static AchievementTracker achievementTracker = new AchievementTracker();

    static void Main()
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine($"Score: {goalManager.GetScore()}\n");
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Show Achievements");
            Console.WriteLine("7. Quit");
            Console.Write("\nChoose an option (1-7): ");

            switch (Console.ReadLine())
            {
                case "1": goalManager.CreateGoal(); break;
                case "2": goalManager.ListGoals(); break;
                case "3":
                    goalManager.RecordEvent();
                    achievementTracker.RecordEvent(goalManager.GetScore());
                    break;
                case "4": goalManager.SaveGoals(); break;
                case "5": goalManager.LoadGoals(); break;
                case "6": achievementTracker.ShowBadges(); break;
                case "7": running = false; break;
                default: Console.WriteLine("Invalid input. Press Enter to continue."); Console.ReadLine(); break;
            }
        }
    }
}