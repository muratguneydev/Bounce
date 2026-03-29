# Implementation Plan

## Status legend
- [ ] not started
- [x] done

---

## 1. Wire wall collision into `GameState.Tick()` ✅

- [x] Call `CollisionDetector.CheckWalls(ball)` before `Ball.Move()` in `GameState.Tick()`
- [x] Add wall collision tests in `GameStateTests`

---

## 2. Paddle collision detection ✅

- [x] Add `HasReachedPaddleRow` property to `Ball` (Y >= `GameDimensions.Height - 2`)
- [x] Add `BounceRight/Left/Up/Down` methods to `Ball` to encapsulate reversal logic
- [x] Add `CollisionDetector.CheckPaddle(ball, paddle)` — reverses DY when ball hits paddle
- [x] Wire `CheckPaddle` into `GameState.Tick()` alongside `CheckWalls`
- [x] Unit tests in `BallTests` and `CollisionDetectorTests`
- [x] Integration tests in `GameStateTests`
- [x] Add `GameState.Initial`, `WithPlaying`, `WithGameOver` factory methods
- [x] Extract `PaddleWidth` constant into `GameDimensions`

---

## 3. Game over detection ✅

- [x] In `GameState.Tick()`: if ball moves below paddle row without a hit, set `Status = GameOver`
- [x] `Tick()` should be a no-op when `Status == GameOver`
- [x] Tests in `GameStateTests`

---

## 4. Score tracking ✅

- [x] Increment `Score` in `GameState.Tick()` when a paddle collision occurs
- [x] Tests in `GameStateTests`

---

## 5. Game loop and input (`Program.cs` + `Game`) ✅

- [x] Add `Game.MovePaddleLeft()` / `Game.MovePaddleRight()` that update `_state` and re-render
- [x] Extract `GameLoop.Run(Game, IInputSource)` — testable loop with fake input support
- [x] `ConsoleInputSource` — real implementation with 50ms tick interval and non-blocking key read
- [x] Replace `Console.ReadKey` stub in `Program.cs` with `GameLoop.Run(game, new ConsoleInputSource())`
- [x] Integration test: `ShouldStopRunning_WhenGameIsOver`
