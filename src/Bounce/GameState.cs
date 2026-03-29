namespace Bounce;

public record GameState(Ball Ball, Paddle Paddle, int Score, GameStatus Status)
{
    public static GameState Initial(Ball ball, Paddle paddle) =>
        new(ball, paddle, Score: 0, Status: GameStatus.Playing);

    public static GameState WithPlaying(Ball ball, Paddle paddle, int score) =>
        new(ball, paddle, Score: score, Status: GameStatus.Playing);

    public static GameState WithGameOver(Ball ball, Paddle paddle, int score) =>
        new(ball, paddle, Score: score, Status: GameStatus.GameOver);

    public GameState Tick()
    {
        var ball = CollisionDetector.CheckWalls(Ball);
        ball = CollisionDetector.CheckPaddle(ball, Paddle);
        return this with { Ball = ball.Move() };
    }
}
