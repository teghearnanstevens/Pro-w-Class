public class QuestionsCL
{
    private FinBackEnd.QuestionsBackEnd _backend;

    public QuestionsCL(FinBackEnd.QuestionsBackEnd backend)
    {
        _backend = backend;
    }

    public void AddQuestion(string question, string answer)
    {
        _backend.AddQuestion(question, answer);
        Console.WriteLine("✅ Question added.");
    }

    public void UserInterface()
    {
        Console.WriteLine("Do you have a financial question? y/n");
        string response = Console.ReadLine()?.ToLower();

        if (response == "y")
        {
            var allQuestions = _backend.GetAllQuestions();

            Console.WriteLine("\nPlease pick a question to get the answer:");
            for (int i = 0; i < allQuestions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {allQuestions[i]}");
            }

            Console.Write("\nEnter the number of your question: ");
            if (int.TryParse(Console.ReadLine(), out int choice) &&
                choice > 0 && choice <= allQuestions.Count)
            {
                string selectedQuestion = allQuestions[choice - 1];
                string answer = _backend.Ask(selectedQuestion);
                Console.WriteLine($"\nAnswer: {answer}");
            }
            else
            {
                Console.WriteLine("❌ Invalid selection.");
            }
        }
        else
        {
            Console.WriteLine("Okay, no problem!");
        }
    }
}
