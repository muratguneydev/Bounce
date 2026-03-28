namespace Bounce;

public record Ball(Position Position, double DX, double DY)
{
    public Ball Move()
    {
        return this with { Position = Position.Translate(DX, DY) };
    }
}
