namespace Bounce;

public record Paddle(int X, int Width)
{
    public Paddle MoveLeft()
    {
        if (X > 0)
        {
            return this with { X = X - 1 };
        }
        return this;
    }

    public Paddle MoveRight(int screenWidth)
    {
        if (X + Width < screenWidth)
        {
            return this with { X = X + 1 };
        }
        return this;
    }
}
