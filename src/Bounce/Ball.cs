namespace Bounce;

public record Ball(Position Position, double DX, double DY)
{
    public bool HasReachedLeftWall => Position.X <= 1;
    public bool HasReachedRightWall => Position.X >= GameDimensions.Width - 2;
    public bool HasReachedTopWall => Position.Y <= 1;

    public Ball Move()
    {
        return this with { Position = Position.Translate(DX, DY) };
    }
}
