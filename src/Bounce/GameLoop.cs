namespace Bounce;

public static class GameLoop
{
    public static void Run(Game game, IInputSource input)
    {
        while (!game.IsOver)
        {
            input.WaitForTick();

            if (input.HasInput)
            {
                if (HandleKey(game, input.ReadKey()))
                {
                    break;
                }
            }

            game.Tick();
        }
    }

    private static bool HandleKey(Game game, ConsoleKey key)
    {
        if (key == ConsoleKey.LeftArrow)
        {
            game.MovePaddleLeft();
        }
        else if (key == ConsoleKey.RightArrow)
        {
            game.MovePaddleRight();
        }
        else if (key == ConsoleKey.Q)
        {
            return true;
        }

        return false;
    }
}
