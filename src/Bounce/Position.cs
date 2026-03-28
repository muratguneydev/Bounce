namespace Bounce;

public record Position(int X, int Y)
{
    public Position Translate(double dx, double dy) => new((int)(X + dx), (int)(Y + dy));

    // Fully known — no parameters
    public static Position Origin() => new(0, 0);

    // One axis is 0 — only the other is needed
    public static Position OnTopEdge(int x) => new(x, 0);
    public static Position OnLeftEdge(int y) => new(0, y);

    // One axis is at the far end — only the other is needed
    public static Position OnRightEdge(int y) => new(GameDimensions.Width - 1, y);
    public static Position OnBottomEdge(int x) => new(x, GameDimensions.Height - 1);

    // Corners — fully derivable from GameDimensions
    public static Position TopRight() => new(GameDimensions.Width - 1, 0);
    public static Position BottomLeft() => new(0, GameDimensions.Height - 1);
    public static Position BottomRight() => new(GameDimensions.Width - 1, GameDimensions.Height - 1);
}
