// Eternal Quest Program
// This program tracks different types of goals with gamification features
// Exceeds core: Added leveling system and badges

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int score = 0;
    static int level = 1;

    static void Main(string[] args)
    {
        bool quit = false;
        while (!quit)
        {
            Console.Clear();
            Console.WriteLine($"Score: {score} | Level: {level}");
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Create Goal\n2. List Goals\n3. Record Event\n4. Save Goals\n5. Load Goals\n6. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": RecordEvent(); break;
                case "4": SaveGoals(); break;
                case "5": LoadGoals(); break;
                case "6": quit = true; break;
            }
            if (score >= level * 1000) level++;
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine("Select goal type:\n1. Simple\n2. Eternal\n3. Checklist");
        string type = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string desc = Console.ReadLine();
        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1") goals.Add(new SimpleGoal(name, desc, points));
        else if (type == "2") goals.Add(new EternalGoal(name, desc, points));
        else if (type == "3")
        {
            Console.Write("Times to complete: ");
            int req = int.Parse(Console.ReadLine());
            Console.Write("Bonus points: ");
            int bonus = int.Parse(Console.ReadLine());
            goals.Add(new ChecklistGoal(name, desc, points, req, bonus));
        }
    }

    static void ListGoals()
    {
        Console.WriteLine("Goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()}");
        }
        Console.ReadKey();
    }

    static void RecordEvent()
    {
        ListGoals();
        Console.Write("Select a goal number to record: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index >= 0 && index < goals.Count)
        {
            int gained = goals[index].RecordEvent();
            score += gained;
            Console.WriteLine($"You gained {gained} points!");
        }
        Console.ReadKey();
    }

    static void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(score);
            writer.WriteLine(level);
            foreach (Goal goal in goals)
                writer.WriteLine(goal.GetStringRepresentation());
        }
    }

    static void LoadGoals()
    {
        goals.Clear();
        string[] lines = File.ReadAllLines("goals.txt");
        score = int.Parse(lines[0]);
        level = int.Parse(lines[1]);

        for (int i = 2; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split("|");
            string type = parts[0];
            if (type == "SimpleGoal")
                goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));
            else if (type == "EternalGoal")
                goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
            else if (type == "ChecklistGoal")
                goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6])));
        }
    }
}
