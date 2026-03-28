namespace Bounce;

public record Ball(double X, double Y, double DX, double DY)
{
    public Ball Move()
    {
        return this with { X = X + DX, Y = Y + DY };
    }
}
