using System;
using System.Collections.Generic;

class ListingActivity : Activity
{
    private List<string> _prompts;

    public ListingActivity()
        : base("Listing Activity", "By listing as many positive things as you can in a certain category, this exercise will assist you in thinking back on the positive aspects of your life.", 0)
    {
        _prompts = new List<string>
        {
            "What blessings have you received today?",
            "What are your strengths?",
            "What is one hobby that you're most proud of?",
            "Who are the people that hold dear to you?",
            "When have you felt the Holy Ghost this day/week?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("How long (in seconds) would you like for this activity to last? ");
        int duration = int.Parse(Console.ReadLine());

        SetDuration(duration);
        Console.WriteLine(GetRandomPrompt());
        ShowCountDown(3);

        List<string> userResponses = GetListFromUser(duration);

        DisplayEndingMessage();
        Console.WriteLine($"You listed {userResponses.Count} items.");
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    private List<string> GetListFromUser(int duration)
    {
        List<string> responses = new List<string>();
        int timeElapsed = 0;
        DateTime startTime = DateTime.Now;

        Console.WriteLine("Start listing: ");

        while (timeElapsed < duration)
        {
            string response = Console.ReadLine();
            responses.Add(response);

            timeElapsed = (int)(DateTime.Now - startTime).TotalSeconds;

            if (timeElapsed >= duration) break;
        }

        return responses;
    }

    private void SetDuration(int duration)
    {
        typeof(Activity).GetField("_duration", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(this, duration);
    }
}
