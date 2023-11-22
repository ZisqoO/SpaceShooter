# Space Shooter Game

![Game Screenshot](screenshots/screenshot.png)

This is a simple space shooter game developed using Unity. Players earn points by destroying enemy ships.

## Game Controls

- Movement: Right/Left/Up/Down arrow keys or W/A/S/D keys
- Fire: Spacebar
- Use Shield: E key

## Installation

1. Clone this repository to your computer.
2. Open the project using Unity 2022.3.4f1 or a newer version via Unity Hub.
3. Open the `MainScene`.
4. Press the "Play" button in Unity to start the game.

## Game Features

- Three different enemy types
- Boss enemies
- Scoring system
- Shield mechanism

## Script Files and Descriptions

### 1. BackgroundControl.cs

Controls the background by setting the offset to create a looping effect. Uses Unity's `MeshRenderer` and `Material` features.

### 2. Boss.cs

Manages the movements and attacks of the boss enemy that appears at the end of the game. Also tracks the boss's health.

### 3. Boss_Special_Attack.cs

Executes the boss's special attack. Spawns special bullets in a specific pattern.

### 4. Boundaries.cs

Creates invisible boundaries above and below the game screen to prevent objects from going beyond these limits and destroys them.

### 5. Bullet.cs

Controls the movement of bullets for both enemies and the player. Moves in the desired direction and is destroyed upon contact with specific objects.

### 6. Enemy.cs

Manages the behavior of enemy ships in the game. Contains different health values, damages, and scores based on enemy type.

### 7. Enemy_Type.cs

Defines different enemy types using Scriptable Objects. Includes values such as health, damage, score points, etc.

### 8. GameManager.cs

Handles the general management of the game. Includes scoring, player damage, spawning enemies, restarting the game, etc.

### 9. MainMenu.cs

Controls which scene to load in the main menu.

### 10. Particle_Bullets.cs

Controls the behavior of particle bullets used in the boss's special attack.

### 11. ShieldLoot.cs

Controls the behavior of shield loot dropped by enemies.

### 12. Shipcontroller.cs

Controls the movement of the player's ship. Also includes collision behaviors with enemy bullets and boss bullets.

### 13. SoundManager.cs

Controls the game's sound files.

### 14. UIManager.cs

Manages variables and interface elements on the canvas. Controls the screens displayed when the game is over and finished.

## Screenshots

![Screenshot 1](screenshots/screenshot2.png)
![Screenshot 2](screenshots/screenshot3.png)

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

**Note:** This README file is an example. You can customize it by adding specific information about your project.
