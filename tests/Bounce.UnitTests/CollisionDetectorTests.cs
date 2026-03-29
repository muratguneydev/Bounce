namespace Bounce.UnitTests;

using NUnit.Framework;
using Shouldly;

public class CollisionDetectorTests
{
    [Test]
    public void ShouldReverseDX_WhenBallHitsLeftWall()
    {
        // Arrange
        var ball = new Ball(new Position(1, 5), DX: -1, DY: 1);

        // Act
        var result = CollisionDetector.CheckWalls(ball);

        // Assert
        result.ShouldBe(ball with { DX = 1 });
    }

    [Test]
    public void ShouldReverseDX_WhenBallHitsRightWall()
    {
        // Arrange
        var ball = new Ball(new Position(GameDimensions.Width - 2, 5), DX: 1, DY: 1);

        // Act
        var result = CollisionDetector.CheckWalls(ball);

        // Assert
        result.ShouldBe(ball with { DX = -1 });
    }

    [Test]
    public void ShouldReverseDY_WhenBallHitsTopWall()
    {
        // Arrange
        var ball = new Ball(new Position(10, 1), DX: 1, DY: -1);

        // Act
        var result = CollisionDetector.CheckWalls(ball);

        // Assert
        result.ShouldBe(ball with { DY = 1 });
    }

    [Test]
    public void ShouldNotChangeVelocity_WhenBallIsInOpenSpace()
    {
        // Arrange
        var ball = new Ball(new Position(10, 5), DX: 1, DY: 1);

        // Act
        var result = CollisionDetector.CheckWalls(ball);

        // Assert
        result.ShouldBe(ball);
    }

    [Test]
    public void ShouldReverseBothDXAndDY_WhenBallHitsTopLeftCorner()
    {
        // Arrange
        var ball = new Ball(new Position(1, 1), DX: -1, DY: -1);

        // Act
        var result = CollisionDetector.CheckWalls(ball);

        // Assert
        result.ShouldBe(ball with { DX = 1, DY = 1 });
    }

    [Test]
    public void ShouldReverseDY_WhenBallHitsPaddle()
    {
        // Arrange
        var paddle = new Paddle(X: 10, Width: GameDimensions.PaddleWidth);
        var ball = new Ball(new Position(10, GameDimensions.Height - 2), DX: 1, DY: 1);

        // Act
        var result = CollisionDetector.CheckPaddle(ball, paddle);

        // Assert
        result.ShouldBe(ball with { DY = -1 });
    }

    [Test]
    public void ShouldNotChangeDY_WhenBallMissesPaddle()
    {
        // Arrange
        var paddle = new Paddle(X: 10, Width: GameDimensions.PaddleWidth);
        var ball = new Ball(new Position(1, GameDimensions.Height - 2), DX: 1, DY: 1);

        // Act
        var result = CollisionDetector.CheckPaddle(ball, paddle);

        // Assert
        result.ShouldBe(ball);
    }

    [Test]
    public void ShouldNotChangeDY_WhenBallIsAbovePaddleRow()
    {
        // Arrange
        var paddle = new Paddle(X: 10, Width: GameDimensions.PaddleWidth);
        var ball = new Ball(new Position(10, GameDimensions.Height - 3), DX: 1, DY: 1);

        // Act
        var result = CollisionDetector.CheckPaddle(ball, paddle);

        // Assert
        result.ShouldBe(ball);
    }
}
