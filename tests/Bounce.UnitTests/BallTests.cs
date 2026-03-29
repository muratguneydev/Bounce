namespace Bounce.UnitTests;

using AutoFixture;
using Bounce.Testing;
using NUnit.Framework;
using Shouldly;

public class BallTests
{
    private readonly Fixture _fixture = BounceFixture.Create();

    [Test]
    public void ShouldUpdatePositionByVelocity_WhenMoving()
    {
        // Arrange
        var ball = _fixture.Create<Ball>();
        var expected = ball with { Position = ball.Position.Translate(ball.DX, ball.DY) };

        // Act
        var result = ball.Move();

        // Assert
        result.ShouldBe(expected);
    }

    [Test]
    public void ShouldUpdatePositionByDoubleVelocity_WhenMovingTwice()
    {
        // Arrange
        var ball = _fixture.Create<Ball>();
        var expected = ball with { Position = ball.Position.Translate(ball.DX * 2, ball.DY * 2) };

        // Act
        var result = ball.Move().Move();

        // Assert
        result.ShouldBe(expected);
    }

    [Test]
    public void ShouldForceDXPositive_WhenBouncingRight()
    {
        // Arrange
        var ball = new Ball(new Position(10, 5), DX: -1, DY: 1);

        // Act & Assert
        ball.BounceRight().ShouldBe(ball with { DX = 1 });
    }

    [Test]
    public void ShouldForceDXNegative_WhenBouncingLeft()
    {
        // Arrange
        var ball = new Ball(new Position(10, 5), DX: 1, DY: 1);

        // Act & Assert
        ball.BounceLeft().ShouldBe(ball with { DX = -1 });
    }

    [Test]
    public void ShouldForceDYPositive_WhenBouncingDown()
    {
        // Arrange
        var ball = new Ball(new Position(10, 5), DX: 1, DY: -1);

        // Act & Assert
        ball.BounceDown().ShouldBe(ball with { DY = 1 });
    }

    [Test]
    public void ShouldForceDYNegative_WhenBouncingUp()
    {
        // Arrange
        var ball = new Ball(new Position(10, 5), DX: 1, DY: 1);

        // Act & Assert
        ball.BounceUp().ShouldBe(ball with { DY = -1 });
    }

    [Test]
    public void ShouldHaveSameVerticalDirection_WhenDYIsEqual()
    {
        // Arrange
        var ball = new Ball(new Position(10, 5), DX: 1, DY: 1);
        var other = new Ball(new Position(5, 3), DX: -1, DY: 1);

        // Act & Assert
        ball.HasSameVerticalDirectionAs(other).ShouldBeTrue();
    }

    [Test]
    public void ShouldNotHaveSameVerticalDirection_WhenDYDiffers()
    {
        // Arrange
        var ball = new Ball(new Position(10, 5), DX: 1, DY: 1);
        var other = new Ball(new Position(5, 3), DX: 1, DY: -1);

        // Act & Assert
        ball.HasSameVerticalDirectionAs(other).ShouldBeFalse();
    }

    [Test]
    public void ShouldHaveReachedPaddleRow_WhenBallIsAtPaddleRow()
    {
        // Arrange
        var ball = new Ball(new Position(10, GameDimensions.BottomY - 1), DX: 1, DY: 1);

        // Act & Assert
        ball.HasReachedPaddleRow.ShouldBeTrue();
    }

    [Test]
    public void ShouldNotHaveReachedPaddleRow_WhenBallIsAbovePaddleRow()
    {
        // Arrange
        var ball = new Ball(new Position(10, GameDimensions.BottomY - 2), DX: 1, DY: 1);

        // Act & Assert
        ball.HasReachedPaddleRow.ShouldBeFalse();
    }
}
