# 🎮 Unity Portfolio Project
This repository contains a Unity project created as part of my portfolio as a Junior Unity Developer. The project showcases my skills in UI system development, C# scripting, and working with core Unity Engine features.

**[Build APK(Full сhangelog in release description)](https://github.com/Vladislav1221224/UnityUISystem/releases/tag/1.0.0)**

## 📌 About the Project
**Project Title**: _UISystem_
**Description:**  
This project was built to demonstrate the following Unity skills:
- C# scripting
    - Async programming
    - Systems Development:
      - Using FSM pattern
      - Using DI pattern
- Scene and object management

## 🔧 Tools & Technologies
Unity 6000.0.40f1
Zenject



# Short Project Documentation

### 1. UI System  
- **Loading Screen:**  
  - Displays loading progress and current process  
- **Game UI:**  
  - Shows game session time  

### 2. SaveLoad System  
- **LoadGameData:**  
  - 1-second delay  
  - Returns new `GameData()`  

### 3. GameStateMachine  
- **LoadingState:**  
  - Displays loading screen  
  - Loads game data  
  - Initializes game state (1-second delay)  
  - Closes loading screen  
  - Switches to `GamePlayState`  
- **GamePlayState:**  
  - Displays game session time in UI  
