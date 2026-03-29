namespace Bounce;

public interface IInputSource
{
    bool HasInput { get; }
    ConsoleKey ReadKey();
    void WaitForTick();
}
