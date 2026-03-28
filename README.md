# Bounce

A terminal-based bouncing ball game built with C# .NET 10. Move the paddle left and right to keep the ball bouncing.

## Prerequisites

- [Docker Desktop](https://www.docker.com/products/docker-desktop/)

## Build

Change directory to the project folder.

```bash
docker compose build
```

## Run Tests

Change directory to the tests folder.

```bash
docker compose build test
docker compose run --rm test
```

## Run the Game

Change directory to the Bounce folder.

```bash
docker compose build bounce
docker compose run --rm bounce
```

## Controls

- **Left Arrow** — Move paddle left
- **Right Arrow** — Move paddle right
- **Q** — Quit
