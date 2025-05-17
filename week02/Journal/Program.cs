using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the journal Project.");
         using System;
using System.Collections.Generic;
using System.IO;

namespace JournalApp
{
    // FEATURE: Added mood tracking to each entry
    // FEATURE: Modular design using abstraction

    public class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            PromptGenerator promptGenerator = new PromptGenerator();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nJournal Menu:");
                Console.WriteLine("1. Write New Entry");
                Console.WriteLine("2. Display All Entries");
                Console.WriteLine("3. Save Journal to File");
                Console.WriteLine("4. Load Journal from File");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        string prompt = promptGenerator.GetRandomPrompt();
                        Console.WriteLine($"Prompt: {prompt}");
                        Console.Write("Your response: ");
                        string response = Console.ReadLine();
                        Console.Write("Your mood (e.g., Happy, Sad, Calm): ");
                        string mood = Console.ReadLine();

                        Entry newEntry = new Entry
                        {
                            Date = DateTime.Now.ToShortDateString(),
                            Prompt = prompt,
                            Response = response,
                            Mood = mood
                        };
                        journal.AddEntry(newEntry);
                        break;

                    case "2":
                        journal.DisplayAll();
                        break;

                    case "3":
                        Console.Write("Enter filename to save to: ");
                        string saveFile = Console.ReadLine();
                        journal.SaveToFile(saveFile);
                        break;

                    case "4":
                        Console.Write("Enter filename to load from: ");
                        string loadFile = Console.ReadLine();
                        journal.LoadFromFile(loadFile);
                        break;

                    case "5":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
    }

    // ------------------ Journal Class (Abstraction) ------------------
    public class Journal
    {
        private List<Entry> _entries = new List<Entry>();

        public void AddEntry(Entry entry)
        {
            _entries.Add(entry);
        }

        public void DisplayAll()
        {
            if (_entries.Count == 0)
            {
                Console.WriteLine("No journal entries found.");
            }
            else
            {
                Console.WriteLine("\nJournal Entries:");
                foreach (var entry in _entries)
                {
                    entry.Display();
                }
            }
        }

        public void SaveToFile(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var entry in _entries)
                {
                    writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}|{entry.Mood}");
                }
            }
            Console.WriteLine("Journal saved successfully.");
        }

        public void LoadFromFile(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }

            _entries.Clear();
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                var parts = line.Split('|');
                if (parts.Length == 4)
                {
                    Entry entry = new Entry
                    {
                        Date = parts[0],
                        Prompt = parts[1],
                        Response = parts[2],
                        Mood = parts[3]
                    };
                    _entries.Add(entry);
                }
            }
            Console.WriteLine("Journal loaded successfully.");
        }
    }

    // ------------------ Entry Class (Abstraction) ------------------
    public class Entry
    {
        public string Date { get; set; }
        public string Prompt { get; set; }
        public string Response { get; set; }
        public string Mood { get; set; }

        public void Display()
        {
            Console.WriteLine($"\n[{Date}] Mood: {Mood}");
            Console.WriteLine($"Prompt: {Prompt}");
            Console.WriteLine($"Response: {Response}");
        }
    }

    // ------------------ PromptGenerator Class ------------------
    public class PromptGenerator
    {
        private List<string> _prompts = new List<string>
        {
            "What made you smile today?",
            "What are you grateful for?",
            "Describe a challenge you faced today.",
            "What did you learn today?",
            "How are you feeling right now?"
        };

        public string GetRandomPrompt()
        {
            Random rand = new Random();
            int index = rand.Next(_prompts.Count);
            return _prompts[index];
        }
    }
}

    }
}