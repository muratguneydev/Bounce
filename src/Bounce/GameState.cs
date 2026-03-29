namespace Bounce;

public record GameState(Ball Ball, Paddle Paddle, int Score, GameStatus Status)
{
    public GameState Tick()
    {
        var ball = CollisionDetector.CheckWalls(Ball);
        return this with { Ball = ball.Move() };
    }
}
