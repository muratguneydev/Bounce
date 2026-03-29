namespace Bounce;

public class Program
{
    public static void Main(string[] args)
    {
        Console.Clear();

        var ball = new Ball(
            Position: new Position(GameDimensions.Width / 2, GameDimensions.Height / 2),
            DX: 1,
            DY: 1);

        var paddle = new Paddle(
            X: GameDimensions.Width / 2 - GameDimensions.PaddleWidth / 2,
            Width: GameDimensions.PaddleWidth);

        var renderer = new ConsoleRenderer();
        var game = new Game(renderer, ball, paddle);
        game.Start();

        GameLoop.Run(game, new ConsoleInputSource());
    }
}
