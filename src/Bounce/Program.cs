namespace Bounce;

public class Program
{
    public static void Main(string[] args)
    {
        Console.Clear();

        var ball = new Ball(
            X: GameDimensions.Width / 2,
            Y: GameDimensions.Height / 2,
            DX: 0,
            DY: 0);

        var paddle = new Paddle(
            X: GameDimensions.Width / 2 - 3,
            Width: 7);

        var renderer = new ConsoleRenderer();
        var game = new Game(renderer, ball, paddle);
        game.Start();

        Console.ReadKey(intercept: true);
    }
}
