# 🎮 **BYTE BREAKERS 3D**

![Game Preview](README_pics/game-preview.png) <!-- Replace with your actual image path -->

Welcome to the **3D Adventure Game**, a dynamic and immersive experience where players interact with a rich environment to solve puzzles, complete objectives, and uncover new possibilities. 🌟

---

## 🌍 **Game Overview**

Explore a carefully crafted 3D world! 🏡 The main objective is to interact with the terminal by entering correct code commands to manipulate the environment, like raising a house to reveal a path. The game combines interactive gameplay with learning mechanics, making it both engaging and educational. 🎓✨

---

## 🚀 **Features**

- **💻 Interactive Terminal**:
  - Press **F** near a terminal to activate it.
  - Type commands like `house.raise();` to progress in the game.

- **🌳 3D Environment**:
  - A beautifully designed medium-sized room with trees, a path, and a functional door.
  - Terrain built using Unity’s Terrain Tools with realistic textures and lighting.

- **✅ Dynamic Objectives**:
  - Objectives are displayed on-screen and disappear upon completion for seamless gameplay.

- **🎮 Smooth Player Controls**:
  - Move forward, backward, left, and right using **W, A, S, D** keys.
  - Integrated with animations for walking, running, and idle states.

- **🎵 Audio Enhancements**:
  - Background music for an immersive experience.
  - Success and failure audio cues for feedback.
 
  - - **Life System**:
  - Start with 3 hearts.
  - Lose a heart on invalid commands.
  - Transition to a **Game Over Scene** after losing all lives.

- **Dynamic Score System**:
  - Start with 0 points.
  - Gain 100 points for every successful terminal command.

- **Audio and Feedback**:
  - Collectibles play sounds and display welcome messages.
  - Background music enhances the **Game Over Scene**.

---

## 🎮 **Controls**

- **🕹️ Movement**:
  - Use **W, A, S, D** to move around.
- **🔑 Interaction**:
  - Press **F** near the terminal to activate it.
  - Use the on-screen UI to type commands.
- **🎯 Objective**:
  - Follow the on-screen instructions to complete your tasks.

---

## 🧩 **How to Play**

1. Start the game and explore the environment. 🌟
2. Locate the terminal and press **F** to activate it. 💻
3. Follow the on-screen hints to type the correct code (`house.raise();`) and complete the objective. ✅
4. Progress through the game by solving puzzles and unlocking paths. 🚪

---

## 🛠️ **Development Details**

- **Engine**: Unity (Version 2021.3.24f1)
- **Key Tools**:
  - **ProBuilder**: For constructing the environment.
  - **Terrain Tools**: For creating realistic landscapes.
  - **Animator Controller**: For smooth player animations.

---

## 🎨 **Credits**

- **Developer**: [Your Name or Team Name] 👨‍💻👩‍💻
- **Special Thanks**: Unity community and tutorial contributors for guidance and assets. 🙌

---

## 📜 **License**

This project is for educational and personal use. Feel free to explore the code and mechanics for learning purposes. 🚀

---

## ⚠️ **Known Issues**

- Game runs smoothly on **Firefox** but may have compatibility issues on **Chrome** (WebGL-related). 🌐
- Complex shaders might not render properly on certain devices. 🖥️

---

## 🌟 **Future Improvements**

- 🌲 Expanding the environment with additional interactive elements.
- 🧩 Adding more puzzles and objectives for a richer gameplay experience.
- 🔧 Enhanced compatibility for all WebGL-supported browsers.

---
# 📜📜📜 **UML CHART**

+--------------------+           +--------------------+
|      GameManager   |           |      UIManager     |
+--------------------+           +--------------------+
| - score: int       |           | - feedbackText     |
| - lives: int       |           | - hearts[]: GameObj|
| + AddScore()       |<---------+| + UpdateScore()    |
| + ReduceLives()    |           | + UpdateLives()    |
| + GameOver()       |           | + DisplayMessage() |
+--------------------+           +--------------------+

            ^                             ^
            |                             |
+--------------------+           +--------------------+
| TerminalController |           | WelcomeCollectible |
+--------------------+           +--------------------+
| - isPlayerNearby   |           | - collectSound     |
| - interactKey      |           | + OnTriggerEnter() |
| + ValidateCode()   |           |                    |
| + RaiseHouse()     |           +--------------------+

                    ^
                    |
+--------------------+         +--------------------+
|   PlayerMovement   |         | GameOverManager    |
+--------------------+         +--------------------+
| - moveSpeed        |         | + RestartGame()    |
| - rotationSpeed    |         | + QuitGame()       |
| + MovePlayer()     |         +--------------------+

                    ^
                    |
+--------------------+
|  PlayerAlignment   |
+--------------------+
| + AlignToGround()  |
+--------------------+

# **Playtesting 🕹️**

To ensure the game runs smoothly and provides the intended experience, follow these steps to playtest:

### **1. Test Gameplay Mechanics** 🔄
- **Player Movement**: 
  - Use **W, A, S, D** keys to move the player around the environment.
  - Confirm smooth transitions over terrain and obstacles.
- **Terminal Interaction**:
  - Press **F** near a terminal to activate it.
  - Type commands like `house.raise();` and verify the house raises successfully.
  - Try invalid commands to ensure lives decrease properly.

### **2. Test Collectibles and Feedback** ✨
- **Collect the Shiny Sphere**:
  - Ensure the collectible disappears upon collection.
  - Confirm the welcome message appears and plays the audio.

### **3. Test UI Updates** 📊
- **Score**:
  - Verify the score starts at **0** and updates correctly for valid commands.
- **Hearts**:
  - Confirm the hearts decrease for invalid commands and disappear upon losing lives.
- **Game Over**:
  - Check that losing all hearts transitions to the Game Over scene.

### **4. Test Scenes** 🌌
- **Game Over Scene**:
  - Confirm the transition displays a black screen with a large "Game Over" message.
  - Test the restart functionality to ensure it reloads the main gameplay scene.

### **5. Browser Testing** 🌐
- **WebGL Compatibility**:
  - Test the game on multiple browsers (e.g., Firefox, Chrome).
  - Verify performance and shader compatibility.

### **6. Optional Feedback** 📝
- Gather feedback from friends or peers:
  - Was the game intuitive to play?
  - Did they encounter any bugs?
  - What did they enjoy most?

---

## **Known Issues** ⚠️
If applicable, add any known issues here, such as:
- The game may experience minor visual glitches on **Chrome** due to WebGL compatibility.



