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
        frame.PlaceCorner(Position.Origin());
        frame.PlaceCorner(Position.TopRight());

        for (var col = 1; col < width - 1; col++)
        {
            frame.PlaceHorizontalWall(Position.OnTopEdge(col));
        }

        for (var row = 1; row < height; row++)
        {
            frame.PlaceVerticalWall(Position.OnLeftEdge(row));
            frame.PlaceVerticalWall(Position.OnRightEdge(row));
        }
    }

    private static void DrawBall(Frame frame, Ball ball)
    {
        if (ball.Position.X >= 0 && ball.Position.X < frame.Width && ball.Position.Y >= 0 && ball.Position.Y < frame.Height)
        {
            frame.PlaceBall(ball.Position);
        }
    }

    private static void DrawPaddle(Frame frame, Paddle paddle, int height)
    {
        for (var col = paddle.X; col < paddle.X + paddle.Width; col++)
        {
            if (col >= 0 && col < frame.Width)
            {
                frame.PlacePaddle(Position.OnBottomEdge(col));
            }
        }
    }
}
