namespace Bounce.IntegrationTests;

using AutoFixture;
using Bounce.Testing;
using NUnit.Framework;
using Shouldly;

public class GameStateTests
{
    private readonly Fixture _fixture = BounceFixture.Create();

    [Test]
    public void ShouldMoveBall_WhenTickCalled()
    {
        // Arrange
        var state = _fixture.Create<GameState>();
        var expected = state with { Ball = state.Ball.Move() };

        // Act
        var result = state.Tick();

        // Assert
        result.ShouldBe(expected);
    }

    [Test]
    public void ShouldNotChangePaddleOrScore_WhenTickCalled()
    {
        // Arrange
        var state = _fixture.Create<GameState>();

        // Act
        var result = state.Tick();

        // Assert
        result.Paddle.ShouldBe(state.Paddle);
        result.Score.ShouldBe(state.Score);
        result.Status.ShouldBe(state.Status);
    }
}
