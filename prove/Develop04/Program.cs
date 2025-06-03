using System;

class Program
{
    static void Main()
    {
        bool running = true;

        while (running)
        {
            Console.Clear();

            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Breathing Exercises");
            Console.WriteLine("2. Reflection Exercises");
            Console.WriteLine("3. Breathing Exercises");
            Console.WriteLine("4. Quit");
            Console.Write("Choose an option (1-4): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    
                    break;
                case "2":
                    
                    break;
                case "3":

                    break;
                    
                case "4":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        
    }
}