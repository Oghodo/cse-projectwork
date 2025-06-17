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