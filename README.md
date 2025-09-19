# Submarine Survival

## Play the Game
**Unity Play Link**: [https://play.unity.com/en/games/0358e419-dbf8-41f2-a1b0-ac7d725e5eaf/submarine-survival]

## Game Overview
In **Submarine Survival**, your goal is to survive as long as possible as you are faced with an ever-increasing onslaught of bouncing sea-mines! As you survive and rack up points, mines will continue to spawn at regular intervals, making it more and more difficult to stay alive.   

### Controls
- To control your submarine, hold down left-click. The submarine will navigate towards your cursor whenever left-click is held. 

### How to Play
- Hold left-click to navigate your submarine around the dangerous sea-mines, dodging them as you survive for as long as possible!  

## Base Game Implementation

### Completion Status
- [x] Player movement and controls
- [x] Obstacle spawning system
- [x] Collision detection
- [x] Score system
- [x] Game over state
- [x] Mine spawning
- [x] Sound effects
- [x] Particles 

### Known Bugs
- Sometimes a new mine will be prevented from spawning when another mine is blocking its spawn location.

## Extensions Implemented

### 1. [Concept Overhaul] (3 points)
**Implementation**: I made my own assets using combinations of the shapes built in to unity, and created a moving water background and overlay using panning tiled illustrations of water.
**Game Impact**: Thematically overhausl the game.
**Technical Details**: Asset changes, used Lerp to pan the water panels.
**Known Issues**: The background sometimes has overly-consistent patterns or lines created by the tiling.

### 2. [Custom Sprites] (3 points)
**Implementation**: Layered base unity shape sprites to make custom sprites that align with the new theme.
**Game Impact**: Contributes to the thematic overhaul.
**Technical Details**: Layered and colored the existing unity shape sprites to create new custom sprites. 
**Known Issues**: None

### 3. [Destroy Borders on Game Over] (4 points)
**Implementation**: Added functionality to destroy the borders when they player collides with something.
**Game Impact**: Makes for a more interesting end screen.
**Technical Details**: Used Destroy() to remove the borders when the player collides. 
**Known Issues**: None

### 4. [Add Ambient Particles] (4 points)
**Implementation**: Added particles when mines collide and a custom bubble trail as the player thrusts.
**Game Impact**: Sells the theme and adds feedback to things happening in the game.
**Technical Details**: Added multiple additional particle systems to add ambience and feedback. 
**Known Issues**: None

### 5. [Increase Difficulty Over Time] (5 points)
**Implementation**: Mines fly in at a random height from either the left or right side of the screen at a constant interval.
**Game Impact**: Makes the game much more interesting to play and adds a constant pressure.
**Technical Details**: Used a coroutine to facilitate mine spawning sequence with warning.
**Known Issues**: Sometimes a new mine will be prevented from spawning when another mine is blocking its spawn location.

### 6. [Sound Effects] (5 points)
**Implementation**: Added sound effects for player explosion, mine-on-mine collisions, and mine-spawn warning.   
**Game Impact**: Adds audio feedback making the game more immersive.
**Technical Details**: Created an AudioManager gameobject that controls sound effects by subscribing to events invoked by other GameObjects.
**Known Issues**: None

## Credits
**Sound Effects**
- https://freesound.org/people/cabled_mess/sounds/350971/
- https://freesound.org/people/Rotaredom/sounds/686859/
- https://freesound.org/people/jorickhoofd/sounds/160025/

**Water Background Image**
- https://www.freepik.com/vectors/watery-texture/7

## Reflection
**Total Points Claimed**: 104
**Challenges**: The most challenging part for me was dealing with layering difficulties and re-building a few times to fix UI issues that only appeared on the web upload.
**Learning Outcomes**: Through this project I became much more comfortable with Unity's UI and Particle Systems, and got a good refresh on many of the important tools for building games in Unity.

## Development Notes
I had a lot of fun working on overhauling the theming for this project and designing my own custom assets!