namespace Bounce.UnitTests;

using AutoFixture;
using Bounce.Testing;
using NUnit.Framework;
using Shouldly;

public class PaddleTests
{
    private readonly Fixture _fixture = BounceFixture.Create();

    [Test]
    public void ShouldDecreaseXByOne_WhenMovingLeft()
    {
        // Arrange
        var paddle = _fixture.Create<Paddle>();
        var expected = paddle with { X = paddle.X - 1 };

        // Act
        var result = paddle.MoveLeft();

        // Assert
        result.ShouldBe(expected);
    }

    [Test]
    public void ShouldIncreaseXByOne_WhenMovingRight()
    {
        // Arrange
        var paddle = _fixture.Create<Paddle>();
        var screenWidth = paddle.X + paddle.Width + 10;
        var expected = paddle with { X = paddle.X + 1 };

        // Act
        var result = paddle.MoveRight(screenWidth);

        // Assert
        result.ShouldBe(expected);
    }

    [Test]
    public void ShouldNotMove_WhenMovingLeftAtLeftBoundary()
    {
        // Arrange
        var paddle = new Paddle(X: 0, Width: 7);
        var expected = paddle with { };

        // Act
        var result = paddle.MoveLeft();

        // Assert
        result.ShouldBe(expected);
    }

    [Test]
    public void ShouldNotMove_WhenMovingRightAtRightBoundary()
    {
        // Arrange
        var paddle = new Paddle(X: 33, Width: 7);
        var screenWidth = paddle.X + paddle.Width;
        var expected = paddle with { };

        // Act
        var result = paddle.MoveRight(screenWidth);

        // Assert
        result.ShouldBe(expected);
    }
}
