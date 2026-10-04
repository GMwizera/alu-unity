# Unity Assets, Models and Textures

A 3D platformer prototype built with primitives, in Unity 6.

## Level01

- `Player`: a capsule prefab that moves with WASD (relative to the camera) and jumps with Space.
- `Platforms`: 20 floating cubes in two branches from the start platform to the end platform.
- `WinFlag`: a cylinder at the end with a trigger collider.
- `Main Camera`: follows the Player; hold right-click and drag the mouse to orbit it.
- Falling below the platforms drops the Player back onto the start from above.
- `TimerCanvas`: shows a timer that starts when the Player first moves, keeps running after a fall, and stops (bigger and green) at the WinFlag.

## Scripts

| Script | Attached to | Purpose |
|--------|-------------|---------|
| `PlayerController` | Player | Movement, jump and falling back to the start |
| `CameraController` | Main Camera | Follows the Player, mouse orbit |
| `Timer` | Player | Counts up and updates `TimerText` |
| `TimerTrigger` | TimerTrigger | Starts the timer when the Player moves off the start |
| `WinTrigger` | WinFlag | Stops the timer and highlights it |
