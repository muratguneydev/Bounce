using Bounce;
using NUnit.Framework;

namespace Bounce.UnitTests;

[TestFixture]
public class BallTests
{
    [Test]
    public void Move_UpdatesPositionByVelocity()
    {
        var ball = new Ball(10.0, 5.0, dx: 1.0, dy: 1.0);

        ball.Move();

        Assert.That(ball.X, Is.EqualTo(11.0));
        Assert.That(ball.Y, Is.EqualTo(6.0));
    }

    [Test]
    public void Move_HandlesNegativeVelocity()
    {
        var ball = new Ball(10.0, 5.0, dx: -1.0, dy: -1.0);

        ball.Move();

        Assert.That(ball.X, Is.EqualTo(9.0));
        Assert.That(ball.Y, Is.EqualTo(4.0));
    }

    [Test]
    public void Move_HandlesFractionalVelocity()
    {
        var ball = new Ball(10.0, 5.0, dx: 0.5, dy: -0.5);

        ball.Move();

        Assert.That(ball.X, Is.EqualTo(10.5));
        Assert.That(ball.Y, Is.EqualTo(4.5));
    }

    [Test]
    public void Constructor_SetsInitialProperties()
    {
        var ball = new Ball(3.0, 7.0, dx: 2.0, dy: -1.0);

        Assert.That(ball.X, Is.EqualTo(3.0));
        Assert.That(ball.Y, Is.EqualTo(7.0));
        Assert.That(ball.DX, Is.EqualTo(2.0));
        Assert.That(ball.DY, Is.EqualTo(-1.0));
    }
}
