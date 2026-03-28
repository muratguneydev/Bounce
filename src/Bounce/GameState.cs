namespace Bounce;

public record GameState(Ball Ball, Paddle Paddle, int Score, GameStatus Status)
{
    public GameState Tick()
    {
        return this with { Ball = Ball.Move() };
    }
}
