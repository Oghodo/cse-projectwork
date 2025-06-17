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