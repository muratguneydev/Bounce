namespace Bounce;

public class ConsoleRenderer : IRenderer
{
    private const int Width = 60;
    private const int Height = 20;

    public void Render(GameState state)
    {
        Console.CursorVisible = false;
        Console.SetCursorPosition(0, 0);

        var ballX = (int)state.Ball.X;
        var ballY = (int)state.Ball.Y;

        for (var row = 0; row < Height; row++)
        {
            for (var col = 0; col < Width; col++)
            {
                if (IsWall(row, col))
                {
                    Console.Write(GetWallChar(row, col));
                }
                else if (IsBall(row, col, ballX, ballY))
                {
                    Console.Write('O');
                }
                else if (IsPaddle(row, col, state.Paddle))
                {
                    Console.Write('=');
                }
                else
                {
                    Console.Write(' ');
                }
            }
            Console.WriteLine();
        }

        Console.WriteLine($" Score: {state.Score}  Status: {state.Status}  (Q to quit)");
    }

    private static bool IsWall(int row, int col)
    {
        return row == 0 || col == 0 || col == Width - 1;
    }

    private static char GetWallChar(int row, int col)
    {
        if (row == 0 && (col == 0 || col == Width - 1))
        {
            return '+';
        }
        if (row == 0)
        {
            return '-';
        }
        return '|';
    }

    private static bool IsBall(int row, int col, int ballX, int ballY)
    {
        return col == ballX && row == ballY;
    }

    private static bool IsPaddle(int row, int col, Paddle paddle)
    {
        return row == Height - 1 && col >= paddle.X && col < paddle.X + paddle.Width;
    }
}
