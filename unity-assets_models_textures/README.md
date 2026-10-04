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

## Builds

Level01 is built as `Platformer` for Windows (x86_64), Linux (x86_64) and Mac into `Builds/`
(not committed; the zipped builds are shared separately):
`Platformer_Windows_x86_64.zip`, `Platformer_Linux_x86_64.zip`, `Platformer_Mac.zip`.

## Credits

- Models: [Kenney's Nature Pack Extended](https://kenney.nl/assets/nature-pack-extended) (now published as [Nature Kit](https://kenney.nl/assets/nature-kit), CC0)
- Skyboxes: [Farland Skies - Cloudy Crown](https://assetstore.unity.com/packages/2d/textures-materials/sky/farland-skies-cloudy-crown-60004)
