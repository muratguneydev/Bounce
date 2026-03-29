namespace Bounce;

public record Ball(Position Position, double DX, double DY)
{
    public bool HasReachedLeftWall => Position.X <= 1;
    public bool HasReachedRightWall => Position.X >= GameDimensions.Width - 2;
    public bool HasReachedTopWall => Position.Y <= 1;
    public bool HasReachedPaddleRow => Position.Y >= GameDimensions.BottomY - 1;

    public bool HasSameVerticalDirectionAs(Ball other) => DY == other.DY;

    public Ball BounceRight() => this with { DX = Math.Abs(DX) };
    public Ball BounceLeft() => this with { DX = -Math.Abs(DX) };
    public Ball BounceDown() => this with { DY = Math.Abs(DY) };
    public Ball BounceUp() => this with { DY = -Math.Abs(DY) };

    public Ball Move()
    {
        return this with { Position = Position.Translate(DX, DY) };
    }
}
