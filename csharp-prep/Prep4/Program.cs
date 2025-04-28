using System;

class Program
{
    static void Main(string[] args)
    {
        
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter Numbers in the list, when done enter 0");

        int userNumber = -1;
       
        while (userNumber != 0)
        {
            Console.Write("Enter number: ");
            userNumber = int.Parse(Console.ReadLine());

            if (userNumber != 0) // Don't add the final 0 to the list
            {
                numbers.Add(userNumber);
            }
        }
        
        
        int sum = 0;

        foreach (int number in numbers)
        {
            sum += number; 
        }

        Console.WriteLine($"The sum is: {sum}");

        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        int max = numbers[0]; // Start by assuming the first number is the biggest

        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number; // Found a new bigger number
            }
        }
        
        Console.WriteLine($"The largest number is: {max}");

    }
}