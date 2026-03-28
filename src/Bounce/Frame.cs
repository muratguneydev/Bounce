namespace Bounce;

public class Frame
{
    private readonly char[,] _grid;

    public int Width { get; }
    public int Height { get; }

    public Frame(int width, int height)
    {
        Width = width;
        Height = height;
        _grid = new char[height, width];

        for (var row = 0; row < height; row++)
        {
            for (var col = 0; col < width; col++)
            {
                _grid[row, col] = ' ';
            }
        }
    }

    public char CharAt(Position position)
    {
        return _grid[position.Y, position.X];
    }

    public void Set(Position position, char c)
    {
        _grid[position.Y, position.X] = c;
    }
}
