namespace Bounce.IntegrationTests;

using System;
using Bounce.Testing;
using NUnit.Framework;
using Shouldly;

public class GameTests
{
    private readonly FakeRenderer _renderer = new();
    private readonly Ball _initialBall = new(Position: new Position(10, 5), DX: 1, DY: 1);
    private readonly Paddle _initialPaddle = new(X: 26, Width: 7);

    [Test]
    public void ShouldRenderBallAtInitialPosition_WhenGameStarts()
    {
        // Arrange
        var game = new Game(_renderer, _initialBall, _initialPaddle);

        // Act
        game.Start();

        // Assert
        _renderer.ShouldShowBallAt(new Position(10, 5));
    }

    [Test]
    public void ShouldRenderPaddleAcrossItsWidth_WhenGameStarts()
    {
        // Arrange
        var game = new Game(_renderer, _initialBall, _initialPaddle);

        // Act
        game.Start();

        // Assert
        for (var col = _initialPaddle.X; col < _initialPaddle.X + _initialPaddle.Width; col++)
        {
            _renderer.ShouldShowPaddleAt(Position.OnBottomEdge(col));
        }
    }

    [Test]
    public void ShouldRenderBallAtNewPosition_AfterOneTick()
    {
        // Arrange
        var game = new Game(_renderer, _initialBall, _initialPaddle);
        game.Start();

        // Act
        game.Tick();

        // Assert
        _renderer.ShouldShowBallAt(new Position(11, 6));
        _renderer.ShouldShowEmptyAt(new Position(10, 5));
    }

    [Test]
    public void ShouldRenderTopWallWithCorrectCharacters_WhenGameStarts()
    {
        // Arrange
        var game = new Game(_renderer, _initialBall, _initialPaddle);

        // Act
        game.Start();

        // Assert
        _renderer.ShouldShowCornerAt(Position.Origin());
        _renderer.ShouldShowHorizontalWallAt(Position.OnTopEdge(1));
        _renderer.ShouldShowCornerAt(Position.TopRight());
    }

    [Test]
    public void ShouldRenderPaddleOneColumnLeft_AfterMovePaddleLeft()
    {
        // Arrange
        var game = new Game(_renderer, _initialBall, _initialPaddle);
        game.Start();

        // Act
        game.MovePaddleLeft();

        // Assert
        _renderer.ShouldShowPaddleAt(Position.OnBottomEdge(_initialPaddle.X - 1));
        _renderer.ShouldShowEmptyAt(Position.OnBottomEdge(_initialPaddle.X + _initialPaddle.Width - 1));
    }

    [Test]
    public void ShouldBeOver_WhenBallMissesPaddle()
    {
        // Arrange
        var ball = new Ball(new Position(1, GameDimensions.BottomY - 1), DX: 1, DY: 1);
        var paddle = new Paddle(X: 10, Width: GameDimensions.PaddleWidth);
        var game = new Game(_renderer, ball, paddle);
        game.Start();

        // Act
        game.Tick();

        // Assert
        game.IsOver.ShouldBeTrue();
    }

    [Test]
    public void ShouldNotBeOver_WhenGameStarts()
    {
        // Arrange
        var game = new Game(_renderer, _initialBall, _initialPaddle);

        // Act
        game.Start();

        // Assert
        game.IsOver.ShouldBeFalse();
    }

    [Test]
    public void ShouldRenderPaddleOneColumnRight_AfterMovePaddleRight()
    {
        // Arrange
        var game = new Game(_renderer, _initialBall, _initialPaddle);
        game.Start();

        // Act
        game.MovePaddleRight();

        // Assert
        _renderer.ShouldShowPaddleAt(Position.OnBottomEdge(_initialPaddle.X + _initialPaddle.Width));
        _renderer.ShouldShowEmptyAt(Position.OnBottomEdge(_initialPaddle.X));
    }

    [Test]
    public void ShouldStopRunning_WhenGameIsOver()
    {
        // Arrange
        var ball = new Ball(new Position(1, GameDimensions.BottomY - 1), DX: 1, DY: 1);
        var paddle = new Paddle(X: 50, Width: GameDimensions.PaddleWidth);
        var game = new Game(_renderer, ball, paddle);
        game.Start();
        var input = new FakeInputSource();

        // Act
        GameLoop.Run(game, input);

        // Assert
        game.IsOver.ShouldBeTrue();
    }

    [Test]
    public void ShouldMovePaddleLeft_WhenLeftArrowPressed()
    {
        // Arrange
        var game = new Game(_renderer, _initialBall, _initialPaddle);
        game.Start();
        var input = new FakeInputSource(ConsoleKey.LeftArrow, ConsoleKey.Q);

        // Act
        GameLoop.Run(game, input);

        // Assert
        _renderer.ShouldShowPaddleAt(Position.OnBottomEdge(_initialPaddle.X - 1));
    }

    [Test]
    public void ShouldMovePaddleRight_WhenRightArrowPressed()
    {
        // Arrange
        var game = new Game(_renderer, _initialBall, _initialPaddle);
        game.Start();
        var input = new FakeInputSource(ConsoleKey.RightArrow, ConsoleKey.Q);

        // Act
        GameLoop.Run(game, input);

        // Assert
        _renderer.ShouldShowPaddleAt(Position.OnBottomEdge(_initialPaddle.X + _initialPaddle.Width));
    }

    [Test]
    public void ShouldStop_WhenQPressed()
    {
        // Arrange
        var game = new Game(_renderer, _initialBall, _initialPaddle);
        game.Start();
        var input = new FakeInputSource(ConsoleKey.Q);

        // Act
        GameLoop.Run(game, input);

        // Assert
        game.IsOver.ShouldBeFalse();
    }
}
