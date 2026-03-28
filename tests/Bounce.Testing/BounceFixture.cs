namespace Bounce.Testing;

using AutoFixture;

public static class BounceFixture
{
    public static Fixture Create()
    {
        var fixture = new Fixture();
        fixture.Customize<Paddle>(c => c.FromFactory<int>(i =>
            new Paddle(X: Math.Abs(i % 100) + 10, Width: 7)));
        return fixture;
    }
}
