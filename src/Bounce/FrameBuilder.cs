namespace Bounce;

public static class FrameBuilder
{
    public static Frame Build(GameState state, int width, int height)
    {
        var frame = new Frame(width, height);

        DrawWalls(frame);
        DrawBall(frame, state.Ball);
        DrawPaddle(frame, state.Paddle);

        return frame;
    }

    private static void DrawWalls(Frame frame)
    {
        frame.PlaceCorner(Position.Origin());
        frame.PlaceCorner(Position.TopRight());

        for (var col = 1; col < frame.Width - 1; col++)
        {
            frame.PlaceHorizontalWall(Position.OnTopEdge(col));
        }

        for (var row = 1; row < frame.Height; row++)
        {
            frame.PlaceVerticalWall(Position.OnLeftEdge(row));
            frame.PlaceVerticalWall(Position.OnRightEdge(row));
        }
    }

    private static void DrawBall(Frame frame, Ball ball)
    {
        if (frame.Contains(ball.Position))
        {
            frame.PlaceBall(ball.Position);
        }
    }

    private static void DrawPaddle(Frame frame, Paddle paddle)
    {
        for (var col = 0; col < frame.Width; col++)
        {
            if (paddle.CoversColumn(col))
            {
                var position = Position.OnBottomEdge(col);
                if (frame.Contains(position))
                {
                    frame.PlacePaddle(position);
                }
            }
        }
    }
}
