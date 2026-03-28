namespace Bounce;

public class Frame
{
    private const char BallChar = 'O';
    private const char PaddleChar = '=';
    private const char CornerChar = '+';
    private const char HorizontalWallChar = '-';
    private const char VerticalWallChar = '|';
    private const char EmptyChar = ' ';

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
                _grid[row, col] = EmptyChar;
            }
        }
    }

    // Write methods
    public void PlaceBall(Position position) => Set(position, BallChar);
    public void PlacePaddle(Position position) => Set(position, PaddleChar);
    public void PlaceCorner(Position position) => Set(position, CornerChar);
    public void PlaceHorizontalWall(Position position) => Set(position, HorizontalWallChar);
    public void PlaceVerticalWall(Position position) => Set(position, VerticalWallChar);

    // Query methods
    public bool IsBallAt(Position position) => CharAt(position) == BallChar;
    public bool IsPaddleAt(Position position) => CharAt(position) == PaddleChar;
    public bool IsEmptyAt(Position position) => CharAt(position) == EmptyChar;
    public bool IsCornerAt(Position position) => CharAt(position) == CornerChar;
    public bool IsHorizontalWallAt(Position position) => CharAt(position) == HorizontalWallChar;
    public bool IsVerticalWallAt(Position position) => CharAt(position) == VerticalWallChar;

    public bool Contains(Position position) =>
        position.X >= 0 && position.X < Width && position.Y >= 0 && position.Y < Height;

    // Used by ConsoleRenderer to iterate and write each cell
    public char CharAt(Position position) => _grid[position.Y, position.X];

    private void Set(Position position, char c) => _grid[position.Y, position.X] = c;
}
