using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        int activityCount = 0;
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Activities Menu:");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    Console.WriteLine($"\nYou completed {activityCount} activities today. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Press Enter to try again.");
                    Console.ReadLine();
                    continue;
            }

            activity.PerformActivity();
            activityCount++;
        }
    }
}

// Base class Activity with shared attributes and behaviors
abstract class Activity
{
    // Private member variables
    private string _activityName;
    private string _description;
    private int _durationSeconds;

    // Constructor
    public Activity(string activityName, string description)
    {
        _activityName = activityName;
        _description = description;
    }

    // Protected accessors for derived classes
    protected string ActivityName => _activityName;
    protected string Description => _description;
    protected int DurationSeconds => _durationSeconds;

    // Public method to run the full activity flow
    public void PerformActivity()
    {
        DisplayStartMessage();
        RunActivity();
        DisplayEndMessage();
    }

    // Prompt user for duration and display start message
    private void DisplayStartMessage()
    {
        Console.Clear();
        Console.WriteLine($"--- {ActivityName} ---");
        Console.WriteLine(Description);
        Console.Write("Enter duration in seconds: ");
        while (!int.TryParse(Console.ReadLine(), out _durationSeconds) || _durationSeconds <= 0)
        {
            Console.Write("Invalid input. Please enter a positive number: ");
        }
        Console.WriteLine("\nGet ready to begin...");
        ShowSpinner(3);
    }

    // Common ending message
    private void DisplayEndMessage()
    {
        Console.WriteLine("\nWell done!");
        ShowSpinner(3);
        Console.WriteLine($"You have completed the {ActivityName} for {DurationSeconds} seconds.");
        ShowSpinner(3);
    }

    // Abstract method to be implemented by derived classes
    protected abstract void RunActivity();

    // Spinner animation for pauses
    protected void ShowSpinner(int seconds)
    {
        string spinner = "|/-\\";
        int spinnerIndex = 0;
        DateTime endTime = DateTime.Now.AddSeconds(seconds);

        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[spinnerIndex]);
            spinnerIndex = (spinnerIndex + 1) % spinner.Length;
            Thread.Sleep(250);
            Console.Write("\b");
        }
    }

    // Countdown animation for pauses
    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}

// Breathing Activity
class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    protected override void RunActivity()
    {
        int elapsed = 0;
        int cycleDuration = 6; // 3 seconds breathe in + 3 seconds breathe out

        while (elapsed < DurationSeconds)
        {
            Console.Write("\nBreathe in...");
            ShowCountdown(3);
            elapsed += 3;

            if (elapsed >= DurationSeconds) break;

            Console.Write("\nBreathe out...");
            ShowCountdown(3);
            elapsed += 3;
        }
    }
}

// Reflection Activity
class ReflectionActivity : Activity
{
    private readonly List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private readonly List<string> _questions = new List<string>
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

    public ReflectionActivity()
        : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    protected override void RunActivity()
    {
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];

        Console.WriteLine("\n--- Reflection Prompt ---");
        Console.WriteLine(prompt);
        Console.WriteLine("\nPress Enter when you have something in mind...");
        Console.ReadLine();

        int elapsed = 0;
        int questionPause = 5; // seconds pause after each question

        while (elapsed < DurationSeconds)
        {
            string question = _questions[rand.Next(_questions.Count)];
            Console.WriteLine($"\n{question}");
            ShowSpinner(questionPause);
            elapsed += questionPause;
        }
    }
}

// Listing Activity
class ListingActivity : Activity
{
    private readonly List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
        : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    protected override void RunActivity()
    {
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];

        Console.WriteLine("\n--- Listing Prompt ---");
        Console.WriteLine(prompt);
        Console.WriteLine("\nYou have 5 seconds to think...");
        ShowCountdown(5);

        Console.WriteLine("\nStart listing items. Press Enter after each one:");
        List<string> responses = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(DurationSeconds);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(response))
            {
                responses.Add(response.Trim());
            }
        }

        Console.WriteLine($"\nYou listed {responses.Count} items!");
    }
}
