namespace Bounce;

public static class CollisionDetector
{
    public static Ball CheckWalls(Ball ball)
    {
        if (ball.HasReachedLeftWall)
        {
            ball = ball.BounceRight();
        }

        if (ball.HasReachedRightWall)
        {
            ball = ball.BounceLeft();
        }

        if (ball.HasReachedTopWall)
        {
            ball = ball.BounceDown();
        }

        return ball;
    }

    public static Ball CheckPaddle(Ball ball, Paddle paddle)
    {
        if (ball.HasReachedPaddleRow && paddle.CoversColumn(ball.Position.X))
        {
            return ball.BounceUp();
        }

        return ball;
    }
}
