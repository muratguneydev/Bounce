namespace Bounce;

public static class CollisionDetector
{
    public static Ball CheckWalls(Ball ball)
    {
        var dx = ball.DX;
        var dy = ball.DY;

        if (ball.HasReachedLeftWall)
        {
            dx = Math.Abs(dx);
        }

        if (ball.HasReachedRightWall)
        {
            dx = -Math.Abs(dx);
        }

        if (ball.HasReachedTopWall)
        {
            dy = Math.Abs(dy);
        }

        return ball with { DX = dx, DY = dy };
    }
}
