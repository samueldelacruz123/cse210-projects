using System;

class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity", 
            "By practicing calm inhalation and exhalation, this exercise will help you unwind. This exercise will help you relax by teaching you how to breathe softly in and out. Quit your thoughts and concentrate on your breathing. Shut your thoughts and concentrate on your breathing.",
            0)
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("How long (in seconds) would you like for this activity to last? ");
        int duration = int.Parse(Console.ReadLine());

        SetDuration(duration);

        int timeElapsed = 0;
        while (timeElapsed < duration)
        {
            Console.WriteLine("Breathe in...");
            ShowCountDown(3);
            timeElapsed += 3;

            if (timeElapsed >= duration) break;

            Console.WriteLine("Breathe out...");
            ShowCountDown(3);
            timeElapsed += 3;
        }

        DisplayEndingMessage();
    }

    private void SetDuration(int duration)
    {
        typeof(Activity).GetField("_duration", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(this, duration);
    }
}