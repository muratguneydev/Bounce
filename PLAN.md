# Implementation Plan

## Status legend
- [ ] not started
- [x] done

---

## 1. Wire wall collision into `GameState.Tick()`

`CollisionDetector.CheckWalls()` exists but `Tick()` only calls `Ball.Move()`. Order matters: check walls first, then move.

- [ ] Call `CollisionDetector.CheckWalls(ball)` before `Ball.Move()` in `GameState.Tick()`
- [ ] Add/update integration tests in `GameStateTests`

---

## 2. Paddle collision detection

- [ ] Add `HasReachedPaddleRow` property to `Ball` (Y >= `GameDimensions.Height - 2`)
- [ ] Add `CollisionDetector.CheckPaddle(ball, paddle)` — if ball is on paddle row and within a paddle column, reverse DY upward
- [ ] Wire `CheckPaddle` into `GameState.Tick()` alongside `CheckWalls`
- [ ] Unit tests in `CollisionDetectorTests`
- [ ] Integration tests in `GameStateTests`

---

## 3. Game over detection

- [ ] In `GameState.Tick()`: if ball moves below paddle row without a hit, set `Status = GameOver`
- [ ] `Tick()` should be a no-op when `Status == GameOver`
- [ ] Integration tests

---

## 4. Score tracking

- [ ] Increment `Score` in `GameState.Tick()` when a paddle collision occurs
- [ ] Integration tests

---

## 5. Game loop and input (`Program.cs` + `Game`)

- [ ] Add `Game.MovePaddleLeft()` / `Game.MovePaddleRight()` that update `_state` and re-render
- [ ] Replace `Console.ReadKey` stub in `Program.cs` with a loop that:
  - Sleeps for a fixed tick interval (e.g. 50ms)
  - Checks `Console.KeyAvailable` for non-blocking input (left/right arrows move paddle, Q quits)
  - Calls `game.Tick()` each iteration
  - Exits when `Status == GameOver`
