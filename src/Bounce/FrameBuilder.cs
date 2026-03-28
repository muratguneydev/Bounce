namespace Bounce;

public static class FrameBuilder
{
    public static Frame Build(GameState state, int width, int height)
    {
        var frame = new Frame(width, height);

        DrawWalls(frame, width, height);
        DrawBall(frame, state.Ball);
        DrawPaddle(frame, state.Paddle, height);

        return frame;
    }

    private static void DrawWalls(Frame frame, int width, int height)
    {
        for (var col = 0; col < width; col++)
        {
            frame.Set(new Position(col, 0), col == 0 || col == width - 1 ? '+' : '-');
        }

        for (var row = 1; row < height; row++)
        {
            frame.Set(new Position(0, row), '|');
            frame.Set(new Position(width - 1, row), '|');
        }
    }

    private static void DrawBall(Frame frame, Ball ball)
    {
        var position = new Position((int)ball.X, (int)ball.Y);

        if (position.X >= 0 && position.X < frame.Width && position.Y >= 0 && position.Y < frame.Height)
        {
            frame.Set(position, 'O');
        }
    }

    private static void DrawPaddle(Frame frame, Paddle paddle, int height)
    {
        for (var col = paddle.X; col < paddle.X + paddle.Width; col++)
        {
            if (col >= 0 && col < frame.Width)
            {
                frame.Set(new Position(col, height - 1), '=');
            }
        }
    }
}
