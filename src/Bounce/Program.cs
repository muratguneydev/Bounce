namespace Bounce;

public class Program
{
    private const int Width = 60;
    private const int Height = 20;

    public static void Main(string[] args)
    {
        Console.Clear();

        var ball = new Ball(X: Width / 2, Y: Height / 2, DX: 0, DY: 0);
        var paddle = new Paddle(X: Width / 2 - 3, Width: 7);
        var state = new GameState(ball, paddle, Score: 0, Status: GameStatus.Playing);

        var renderer = new ConsoleRenderer();
        renderer.Render(state);

        Console.ReadKey(intercept: true);
    }
}
