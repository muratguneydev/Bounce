namespace Bounce;

public class Game
{
    private readonly IRenderer _renderer;
    private GameState _state;

    public Game(IRenderer renderer, Ball initialBall, Paddle initialPaddle)
    {
        _renderer = renderer;
        _state = new GameState(initialBall, initialPaddle, Score: 0, Status: GameStatus.Playing);
    }

    public void Start()
    {
        _renderer.Render(_state);
    }

    public void Tick()
    {
        _state = _state.Tick();
        _renderer.Render(_state);
    }
}
