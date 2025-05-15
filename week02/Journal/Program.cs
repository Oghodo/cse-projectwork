using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Journal
{
    private List<JournalEntry> _entries = new List<JournalEntry>();
    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What did I learn about myself today?",
        "What was something unexpected that happened today?"
    };

    private Random _rand = new Random();

    public void WriteEntry()
    {
        string prompt = _prompts[_rand.Next(_prompts.Count)];
        Console.WriteLine($"\nPrompt: {prompt}");

        Console.Write("Title: ");
        string title = Console.ReadLine();

        Console.Write("Your response: ");
        string response = Console.ReadLine();

        Console.Write("Mood (e.g., Happy, Sad, Anxious, Excited): ");
        string mood = Console.ReadLine();

        _entries.Add(new JournalEntry
        {
            Date = DateTime.Now,
            Title = title,
            Prompt = prompt,
            Response = response,
            Mood = mood
        });

        Console.WriteLine("✅ Entry saved!\n");
    }

    public void DisplayEntries()
    {
        Console.WriteLine("\n--- Journal Entries ---");
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries found.");
        }
        else
        {
            foreach (var entry in _entries)
            {
                Console.WriteLine(entry);
            }
        }
    }

    public void SaveToCsv()
    {
        Console.Write("Enter filename to save to (with .csv extension): ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine("Date,Title,Prompt,Mood,Response");
            foreach (var entry in _entries)
            {
                writer.WriteLine(entry.ToCsv());
            }
        }

        Console.WriteLine("✅ Journal saved to CSV.\n");
    }

    public void SaveToJson()
    {
        Console.Write("Enter filename to save to (with .json extension): ");
        string filename = Console.ReadLine();
        string json = JsonSerializer.Serialize(_entries, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filename, json);
        Console.WriteLine("✅ Journal saved to JSON.\n");
    }

    public void LoadFromCsv()
    {
        Console.Write("Enter CSV filename to load from: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("❌ File not found.\n");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        for (int i = 1; i < lines.Length; i++)
        {
            _entries.Add(JournalEntry.FromCsv(lines[i]));
        }

        Console.WriteLine("✅ Journal loaded from CSV.\n");
    }

    public void LoadFromJson()
    {
        Console.Write("Enter JSON filename to load from: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("❌ File not found.\n");
            return;
        }

        string json = File.ReadAllText(filename);
        _entries = JsonSerializer.Deserialize<List<JournalEntry>>(json);
        Console.WriteLine("✅ Journal loaded from JSON.\n");
    }

    public void SearchByKeyword()
    {
        Console.Write("Enter keyword to search for: ");
        string keyword = Console.ReadLine().ToLower();

        var matches = _entries.FindAll(e =>
            e.Title.ToLower().Contains(keyword) ||
            e.Prompt.ToLower().Contains(keyword) ||
            e.Response.ToLower().Contains(keyword) ||
            e.Mood.ToLower().Contains(keyword));

        if (matches.Count == 0)
        {
            Console.WriteLine("❌ No matching entries found.");
        }
        else
        {
            Console.WriteLine($"\n🔍 Found {matches.Count} matching entries:\n");
            foreach (var entry in matches)
            {
                Console.WriteLine(entry);
            }
        }
    }
}
