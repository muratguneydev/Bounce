namespace Bounce;

using System.Collections.Concurrent;

public class ConsoleInputSource : IInputSource
{
    private const int TickIntervalMs = 50;
    private readonly ConcurrentQueue<ConsoleKey> _keys = new();

    public ConsoleInputSource()
    {
        var thread = new Thread(ReadKeys) { IsBackground = true };
        thread.Start();
    }

    private void ReadKeys()
    {
        while (true)
        {
            try
            {
                var key = Console.ReadKey(intercept: true).Key;
                _keys.Enqueue(key);
            }
            catch (InvalidOperationException)
            {
                break;
            }
        }
    }

    public bool HasInput => !_keys.IsEmpty;

    public ConsoleKey ReadKey()
    {
        _keys.TryDequeue(out var key);
        return key;
    }

    public void WaitForTick()
    {
        Thread.Sleep(TickIntervalMs);
    }
}
