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
