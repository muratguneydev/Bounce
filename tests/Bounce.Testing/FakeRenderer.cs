namespace Bounce.Testing;

using Shouldly;

public class FakeRenderer : IRenderer
{
    private readonly int _width;
    private readonly int _height;
    private Frame? _lastFrame;

    public FakeRenderer(int width = GameDimensions.Width, int height = GameDimensions.Height)
    {
        _width = width;
        _height = height;
    }

    public void Render(GameState state)
    {
        _lastFrame = FrameBuilder.Build(state, _width, _height);
    }

    public void ShouldShowBallAt(Position position)
    {
        CharAt(position).ShouldBe('O', $"Expected ball 'O' at {position}");
    }

    public void ShouldShowEmptyAt(Position position)
    {
        CharAt(position).ShouldBe(' ', $"Expected empty ' ' at {position}");
    }

    public void ShouldShowPaddleAt(Position position)
    {
        CharAt(position).ShouldBe('=', $"Expected paddle '=' at {position}");
    }

    public void ShouldShowCharAt(char expected, Position position)
    {
        CharAt(position).ShouldBe(expected, $"Expected '{expected}' at {position}");
    }

    private char CharAt(Position position)
    {
        _lastFrame.ShouldNotBeNull("Render() has not been called yet.");
        return _lastFrame.CharAt(position);
    }
}
