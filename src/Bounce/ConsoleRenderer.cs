namespace Bounce;

public class ConsoleRenderer : IRenderer
{
    private readonly int _width;
    private readonly int _height;

    public ConsoleRenderer(int width = GameDimensions.Width, int height = GameDimensions.Height)
    {
        _width = width;
        _height = height;
    }

    public void Render(GameState state)
    {
        var frame = FrameBuilder.Build(state, _width, _height);

        Console.CursorVisible = false;
        Console.SetCursorPosition(0, 0);

        for (var row = 0; row < _height; row++)
        {
            for (var col = 0; col < _width; col++)
            {
                Console.Write(frame.CharAt(new Position(col, row)));
            }
            Console.WriteLine();
        }

        Console.WriteLine($" Score: {state.Score}  Status: {state.Status}  (Q to quit)");
    }
}
