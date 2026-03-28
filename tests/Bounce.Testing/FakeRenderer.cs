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
        Frame().IsBallAt(position).ShouldBeTrue($"Expected ball at {position}");
    }

    public void ShouldShowEmptyAt(Position position)
    {
        Frame().IsEmptyAt(position).ShouldBeTrue($"Expected empty at {position}");
    }

    public void ShouldShowPaddleAt(Position position)
    {
        Frame().IsPaddleAt(position).ShouldBeTrue($"Expected paddle at {position}");
    }

    public void ShouldShowCornerAt(Position position)
    {
        Frame().IsCornerAt(position).ShouldBeTrue($"Expected corner at {position}");
    }

    public void ShouldShowHorizontalWallAt(Position position)
    {
        Frame().IsHorizontalWallAt(position).ShouldBeTrue($"Expected horizontal wall at {position}");
    }

    private Frame Frame()
    {
        _lastFrame.ShouldNotBeNull("Render() has not been called yet.");
        return _lastFrame;
    }
}
