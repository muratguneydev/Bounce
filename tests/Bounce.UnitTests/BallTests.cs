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
        var expected = ball with { X = ball.X + ball.DX, Y = ball.Y + ball.DY };

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
        var expected = ball with { X = ball.X + ball.DX * 2, Y = ball.Y + ball.DY * 2 };

        // Act
        var result = ball.Move().Move();

        // Assert
        result.ShouldBe(expected);
    }
}
