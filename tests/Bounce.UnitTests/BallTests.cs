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
    public void ShouldHaveReachedPaddleRow_WhenBallIsAtPaddleRow()
    {
        // Arrange
        var ball = new Ball(new Position(10, GameDimensions.Height - 2), DX: 1, DY: 1);

        // Act & Assert
        ball.HasReachedPaddleRow.ShouldBeTrue();
    }

    [Test]
    public void ShouldNotHaveReachedPaddleRow_WhenBallIsAbovePaddleRow()
    {
        // Arrange
        var ball = new Ball(new Position(10, GameDimensions.Height - 3), DX: 1, DY: 1);

        // Act & Assert
        ball.HasReachedPaddleRow.ShouldBeFalse();
    }
}
