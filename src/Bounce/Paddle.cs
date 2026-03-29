namespace Bounce;

public record Paddle(int X, int Width)
{
    public bool CoversColumn(int x) => x >= X && x < X + Width;

    public Paddle MoveLeft()
    {
        var newX = Math.Max(0, X - GameDimensions.PaddleMoveOffset);
        return this with { X = newX };
    }

    public Paddle MoveRight(int screenWidth)
    {
        var newX = Math.Min(screenWidth - Width, X + GameDimensions.PaddleMoveOffset);
        return this with { X = newX };
    }
}
