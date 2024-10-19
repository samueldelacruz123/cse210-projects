using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity() 
        : base("Reflecting Activity", 
              "This exercise will assist you in thinking back on instances throughout your life where you demonstrated fortitude and resiliency. This task will assist you in thinking back on instances in your life when you have demonstrated resilience and strength. It will also help you identify the power you possess and how you can apply it in other areas of your life. This will assist you in realizing your own power and how to apply it to various facets of your life.", 
              0)
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.Write("How long (in seconds) would you like for this activity to last? ");
        int duration = int.Parse(Console.ReadLine());

        SetDuration(duration);

        Console.WriteLine(GetRandomPrompt());

        ShowSpinner(3);

        DisplayQuestions(duration);

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    private void DisplayQuestions(int duration)
    {
        int timeElapsed = 0;
        Random random = new Random();
        DateTime startTime = DateTime.Now;

        while (timeElapsed < duration)
        {
            string question = GetRandomQuestion();
            Console.WriteLine(question);

            ShowSpinner(3);

            timeElapsed = (int)(DateTime.Now - startTime).TotalSeconds;

            if (timeElapsed >= duration) break;
        }
    }

    private string GetRandomQuestion()
    {
        Random random = new Random();
        int index = random.Next(_questions.Count);
        return _questions[index];
    }

    private void SetDuration(int duration)
    {
        typeof(Activity).GetField("_duration", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(this, duration);
    }
}
