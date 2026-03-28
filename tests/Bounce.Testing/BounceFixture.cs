namespace Bounce.Testing;

using AutoFixture;

public static class BounceFixture
{
    public static Fixture Create()
    {
        var fixture = new Fixture();

        fixture.Customize<Position>(c => c.FromFactory<int, int>((i, j) =>
            new Position(
                Math.Abs(i % (GameDimensions.Width - 2)) + 1,
                Math.Abs(j % (GameDimensions.Height - 2)) + 1)));

        fixture.Customize<Ball>(c => c.FromFactory<double, double>((dx, dy) =>
            new Ball(fixture.Create<Position>(), DX: dx % 3 + 1, DY: dy % 3 + 1)));

        fixture.Customize<Paddle>(c => c.FromFactory<int>(i =>
            new Paddle(X: Math.Abs(i % 100) + 10, Width: 7)));

        fixture.Customize<GameState>(c => c.FromFactory(() =>
            new GameState(
                fixture.Create<Ball>(),
                fixture.Create<Paddle>(),
                Score: 0,
                Status: GameStatus.Playing)));

        return fixture;
    }
}
