namespace Bounce.Testing;

public class FakeInputSource : IInputSource
{
    private readonly Queue<ConsoleKey> _keys;

    public FakeInputSource(params ConsoleKey[] keys)
    {
        _keys = new Queue<ConsoleKey>(keys);
    }

    public bool HasInput => _keys.Count > 0;

    public ConsoleKey ReadKey() => _keys.Dequeue();

    public void WaitForTick()
    {
    }
}
