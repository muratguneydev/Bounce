namespace Bounce;

public class ConsoleInputSource : IInputSource
{
    private const int TickIntervalMs = 50;

    public bool HasInput => Console.KeyAvailable;

    public ConsoleKey ReadKey() => Console.ReadKey(intercept: true).Key;

    public void WaitForTick()
    {
        Thread.Sleep(TickIntervalMs);
    }
}
