using System;
using System.Threading;

public class BreathingAct : Activity
{
    public BreathingAct()
        : base("Breathing Activity", 
              "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        int totalTime = GetDuration();
        int elapsed = 0;

        while (elapsed < totalTime)
        {
            Console.Write("\nBreathe in... ");
            ShowCountdown(4);
            elapsed += 4;

            if (elapsed >= totalTime) break;

            Console.Write("Now breathe out... ");
            ShowCountdown(6);
            elapsed += 6;
        }

        DisplayEndingMessage();
    }
}
