namespace Bounce;

public class Ball
{
    public double X { get; private set; }
    public double Y { get; private set; }
    public double DX { get; set; }
    public double DY { get; set; }

    public Ball(double x, double y, double dx, double dy)
    {
        X = x;
        Y = y;
        DX = dx;
        DY = dy;
    }

    public void Move()
    {
        X += DX;
        Y += DY;
    }
}
