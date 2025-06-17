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