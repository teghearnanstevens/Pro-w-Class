using System;
using System.Collections.Generic;

public class AchievementTracker
{
    private List<string> _earnedBadges = new();
    private int _eventsRecorded = 0;

    public void RecordEvent(int currentScore)
    {
        _eventsRecorded++;
        CheckAchievements(currentScore);
    }

    private void CheckAchievements(int score)
    {
        if (_eventsRecorded == 1 && !_earnedBadges.Contains("First Blood"))
        {
            _earnedBadges.Add("First Blood");
            Console.WriteLine("Achievement Unlocked: First Blood (Recorded your first goal event!)");
        }

        if (_eventsRecorded == 10 && !_earnedBadges.Contains("Crazy Recorder"))
        {
            _earnedBadges.Add("Crazy Recorder");
            Console.WriteLine("Achievement Unlocked: Crazy Recorder (10 events recorded!)");
        }

        if (score >= 500 && !_earnedBadges.Contains("Halfway Hero"))
        {
            _earnedBadges.Add("Halfway Hero");
            Console.WriteLine("Badge Earned: Halfway Hero (500+ points!)");
        }

        if (score >= 1000 && !_earnedBadges.Contains("OverLord"))
        {
            _earnedBadges.Add("OverLord");
            Console.WriteLine("Badge Earned: OverLord (1000+ points!)");
        }
    }

    public void ShowBadges()
    {
        Console.WriteLine("\n🏆 Earned Achievements & Badges:");
        if (_earnedBadges.Count == 0)
            Console.WriteLine("No achievements earned yet.");
        else
            foreach (var badge in _earnedBadges)
                Console.WriteLine("- " + badge);

        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }
}