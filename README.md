# Pik The Frog
## 2D Top-Down Arcade Vertical Slice Prototype (Android)
___
### Overview
Pik The Frog is a 2D top-down arcade gameplay prototype developed for mobile devices (currently configured for Android).

The project represents a vertical slice of a mobile game, featuring adaptive UI, layered animation system, modular enemy system, and limited-visibility mechanics designed to create tension-driven gameplay.

The focus of the project is to demonstrate gameplay architecture, modular systems, and expandable core mechanics.
___
### Tech Stack
* Engine: Unity
* Language: C#
* Platform: Mobile devices (Android)
* Physics: Rigidbody2D & collision system
* Animation: Blend Trees + Animator Layers
* UI: UGUI + TextMeshPro
* Input: New Input System
* Level Design: Tilemaps
* Data Configuration: ScriptableObjects
* Version Control: Git
___
### Gameplay Overview
The player controls a frog navigating through a maze to reach the frog’s home.

But to complete the level, the player must:

1. Explore the maze with limited visibility (only nearby walls are visible).

2. Collect all 20 mosquitoes placed across different parts of the maze.

3. Avoid enemies with unique status effects.

4. Make sure the enemies don’t reduce your hearts to zero.

5. Reach the goal only after collecting all required items (mosquitoes).
___
## Core Gameplay Mechanics
___
### Player Controller
* Physics-based movement
* Temporary invulnerability window after taking damage
* Speed scales proportionally to joystick input magnitude:
* Collider shape dynamically adjustment with character visuals:
### Enemy Types & Status Effects
* Autonomous physics-based movement
* Automatic direction change on collision with environment colliders
* Physics-based collision detection to apply status effects to the player
* 