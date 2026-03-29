# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Commands

No local .NET SDK — everything runs in Docker.

```bash
# Build
docker compose build

# Run all tests
docker compose build test
docker compose run --rm test

# Run the game
docker compose build bounce
docker compose run --rm bounce
```

## Architecture

This is a C# console Pong/breakout game. The solution has four projects:

- `src/Bounce` — game library + entry point
- `tests/Bounce.UnitTests` — unit tests (NUnit + Shouldly)
- `tests/Bounce.IntegrationTests` — integration tests using `FakeRenderer`
- `tests/Bounce.Testing` — shared test helpers (`FakeRenderer`, `BounceFixture`)

### Game loop

`Game` holds a `GameState` and an `IRenderer`. Each call to `Tick()` advances `GameState`, then renders. `GameState.Tick()` is the central mutation point — it currently only moves the ball; collision detection and paddle interaction belong here.

### Rendering pipeline

`FrameBuilder.Build(state, width, height)` converts `GameState` into a `Frame` (a `char[,]` grid). `ConsoleRenderer` writes that frame to the console; `FakeRenderer` stores the last frame and exposes `ShouldShow*` assertion helpers for tests.

### Domain model

- `Ball` — position + double velocity (DX/DY). Wall boundary checks are properties on the record (`HasReachedLeftWall`, etc.).
- `Paddle` — X position + width. `OccupiedColumns` enumerates the columns it covers.
- `CollisionDetector.CheckWalls(ball)` — reverses DX/DY when the ball hits a wall. Paddle collision is not yet implemented.
- `Position` — int X/Y with factory methods (`Origin()`, `OnTopEdge(x)`, `OnBottomEdge(x)`, `TopRight()`, etc.) derived from `GameDimensions` (60×20).
- `GameStatus` — `Playing` or `GameOver`.

### Test conventions

- Unit tests use `BounceFixture` (AutoFixture-based) for randomised valid game objects.
- Integration tests instantiate `Game` directly with a `FakeRenderer` and assert on frame state via `ShouldShow*` methods.
- Tests follow Arrange / Act / Assert with explicit comments.
