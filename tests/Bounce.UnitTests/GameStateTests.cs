namespace Bounce.UnitTests;

using NUnit.Framework;
using Shouldly;

public class GameStateTests
{
    [Test]
    public void ShouldReverseBallDX_WhenBallIsAtLeftWall_AfterTick()
    {
        // Arrange
        var ball = new Ball(new Position(1, 5), DX: -1, DY: 1);
        var paddle = new Paddle(X: 26, Width: 7);
        var state = GameState.Initial(ball, paddle);

        // Act
        var result = state.Tick();

        // Assert
        var expected = state with { Ball = ball with { DX = 1, Position = new Position(2, 6) } };
        result.ShouldBe(expected);
    }

    [Test]
    public void ShouldReverseBallDX_WhenBallIsAtRightWall_AfterTick()
    {
        // Arrange
        var ball = new Ball(new Position(GameDimensions.Width - 2, 5), DX: 1, DY: 1);
        var paddle = new Paddle(X: 26, Width: 7);
        var state = GameState.Initial(ball, paddle);

        // Act
        var result = state.Tick();

        // Assert
        var expected = state with { Ball = ball with { DX = -1, Position = new Position(GameDimensions.Width - 3, 6) } };
        result.ShouldBe(expected);
    }

    [Test]
    public void ShouldReverseBallDY_WhenBallIsAtTopWall_AfterTick()
    {
        // Arrange
        var ball = new Ball(new Position(10, 1), DX: 1, DY: -1);
        var paddle = new Paddle(X: 26, Width: 7);
        var state = GameState.Initial(ball, paddle);

        // Act
        var result = state.Tick();

        // Assert
        var expected = state with { Ball = ball with { DY = 1, Position = new Position(11, 2) } };
        result.ShouldBe(expected);
    }

    [Test]
    public void ShouldReverseBallDY_WhenBallHitsPaddle_AfterTick()
    {
        // Arrange
        var paddle = new Paddle(X: 10, Width: GameDimensions.PaddleWidth);
        var ball = new Ball(new Position(10, GameDimensions.BottomY - 1), DX: 1, DY: 1);
        var state = GameState.Initial(ball, paddle);

        // Act
        var result = state.Tick();

        // Assert
        var expected = GameState.WithPlaying(ball with { DY = -1, Position = new Position(11, GameDimensions.BottomY - 2) }, paddle, score: 1);
        result.ShouldBe(expected);
    }

    [Test]
    public void ShouldSetStatusToGameOver_WhenBallMissesPaddle_AfterTick()
    {
        // Arrange
        var paddle = new Paddle(X: 10, Width: GameDimensions.PaddleWidth);
        var ball = new Ball(new Position(1, GameDimensions.BottomY - 1), DX: 1, DY: 1);
        var state = GameState.Initial(ball, paddle);

        // Act
        var result = state.Tick();

        // Assert
        var expected = GameState.WithGameOver(ball.Move(), paddle, score: 0);
        result.ShouldBe(expected);
    }

    [Test]
    public void ShouldIncrementScore_WhenBallHitsPaddle_AfterTick()
    {
        // Arrange
        var paddle = new Paddle(X: 10, Width: GameDimensions.PaddleWidth);
        var ball = new Ball(new Position(10, GameDimensions.BottomY - 1), DX: 1, DY: 1);
        var state = GameState.Initial(ball, paddle);

        // Act
        var result = state.Tick();

        // Assert
        var expected = GameState.WithPlaying(ball with { DY = -1, Position = new Position(11, GameDimensions.BottomY - 2) }, paddle, score: 1);
        result.ShouldBe(expected);
    }

    [Test]
    public void ShouldNotIncrementScore_WhenBallMissesPaddle_AfterTick()
    {
        // Arrange
        var paddle = new Paddle(X: 10, Width: GameDimensions.PaddleWidth);
        var ball = new Ball(new Position(1, GameDimensions.BottomY - 1), DX: 1, DY: 1);
        var state = GameState.Initial(ball, paddle);

        // Act
        var result = state.Tick();

        // Assert
        var expected = GameState.WithGameOver(ball.Move(), paddle, score: 0);
        result.ShouldBe(expected);
    }

    [Test]
    public void ShouldNotChangeState_WhenTickCalledAfterGameOver()
    {
        // Arrange
        var paddle = new Paddle(X: 10, Width: GameDimensions.PaddleWidth);
        var ball = new Ball(new Position(1, GameDimensions.BottomY), DX: 1, DY: 1);
        var state = GameState.WithGameOver(ball, paddle, score: 3);

        // Act
        var result = state.Tick();

        // Assert
        result.ShouldBe(state);
    }
}
