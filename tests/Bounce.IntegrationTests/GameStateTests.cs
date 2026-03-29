namespace Bounce.IntegrationTests;

using Bounce.Testing;
using NUnit.Framework;

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
}
