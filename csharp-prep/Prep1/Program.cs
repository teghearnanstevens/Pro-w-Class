using System;

class Program
{
    static void Main(string[] args)
    {
        
        Console.Write("What is your first name? ");
        string first_name = Console.ReadLine();
        Console.Write("What is your last name? ");
        string last_name = Console.ReadLine();
        Console.WriteLine($"Your name is {first_name}, {first_name} {last_name}.");

        Console.Write("What is your first name? ");
        string first_name2 = Console.ReadLine();
        Console.Write("What is your last name? ");
        string last_name2 = Console.ReadLine();
        Console.WriteLine($"Your name is {last_name2}, {first_name2} {last_name2}.");
    }
}

