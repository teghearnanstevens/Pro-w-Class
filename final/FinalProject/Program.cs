using System;

class Program
{

    static void Main()
    {
        Budget budget = new Budget();
        Spending spending = new Spending();
        Goal goal = new Goal();
        Checklist checklist = new Checklist();
        var backend = new FinBackEnd.QuestionsBackEnd();
        QuestionsCL questions = new QuestionsCL(backend);

        bool running = true;

        while (running)
        {
            Console.WriteLine("1. Set Budget");
            Console.WriteLine("2. Record Spending");
            Console.WriteLine("3. Set Goal");
            Console.WriteLine("4. Show Financial Questions");
            Console.WriteLine("5. View Checklist");
            Console.WriteLine("6. Add Financial Question");
            Console.WriteLine("7. Quit");

            switch (Console.ReadLine())
            {
                case "1":
                    budget.Process();
                    break;

                case "2":
                    spending.Process();
                    break;

                case "3":
                    goal.Process();
                    break;

                case "4":
                    questions.UserInterface();
                    break;

                case "5":
                    checklist.ShowChecklist();
                    break;

                case "6":
                    Console.Write("Enter your question: ");
                    string q = Console.ReadLine();
                    Console.Write("Enter the answer: ");
                    string a = Console.ReadLine();
                    questions.AddQuestion(q, a);
                    break;

                case "7":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid input. Press Enter to continue.");
                    Console.ReadLine();
                    break;
            }

        }
    }
}