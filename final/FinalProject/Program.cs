using System;

class Program
{
    static void Main()
    {
        Budget budgetFeature = new();
        Spending spendingFeature = new();
        CheckList checklistFeature = new();
        var qBackend = new FinBackEnd.QuestionsBackEnd();
        var qInterface = new QuestionsCL(qBackend);

        budgetFeature.Load();
        spendingFeature.Load();
        checklistFeature.Load();

        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("=== Financial Tracker ===");
            Console.WriteLine($"Bi-weekly Budget: ${Budget.BiWeeklyBudget:F2}");
            Console.WriteLine($"Remaining Budget: ${Budget.RemainingBudget:F2}");
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Set Budget");
            Console.WriteLine("2. Record Spending");
            Console.WriteLine("3. Add Financial Goal");
            Console.WriteLine("4. Manage Goal Checklist");
            Console.WriteLine("5. Reset Budget");
            Console.WriteLine("6. View Spending History");
            Console.WriteLine("7. View Budget Overview");
            Console.WriteLine("8. Financial Questions");
            Console.WriteLine("9. Exit");
            Console.Write("\n> ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    budgetFeature.Process();
                    break;
                case "2":
                    spendingFeature.Process();
                    break;
                case "3":
                    checklistFeature.AddGoalOnly();  // Only add goal
                    break;
                case "4":
                    checklistFeature.ViewAndToggleChecklist();  // View and toggle
                    break; ;
                case "5":
                    Budget.ResetBudget();
                    Console.WriteLine("Press Enter to return...");
                    Console.ReadLine();
                    break;
                case "6":
                    spendingFeature.Display();
                    Console.WriteLine("\nPress Enter to return...");
                    Console.ReadLine();
                    break;
                case "7":
                    budgetFeature.Display();
                    break;
                case "8":
                    qInterface.UserInterface();
                    Console.WriteLine("\nPress Enter to return...");
                    Console.ReadLine();
                    break;
                case "9":
                    SaveAll(budgetFeature, spendingFeature, checklistFeature);
                    Console.WriteLine("Goodbye!");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Press Enter to try again...");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void SaveAll(Financial budget, Financial spending, Financial checklist)
    {
        budget.Save();
        spending.Save();
        checklist.Save();
    }
}
