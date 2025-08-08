# 🎮 Unity Portfolio Project
This repository contains a Unity project created as part of my portfolio as a Junior Unity Developer. The project showcases my skills in UI system development, C# scripting, and working with core Unity Engine features.

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
  - Відображає прогрес завантаження та поточний процес  
- **Game UI:**  
  - Виводить час ігрової сесії  

### 2. SaveLoad System  
- **LoadGameData:**  
  - Затримка 1 секунда  
  - Повертає нові дані `GameData()`  

### 3. GameStateMachine  
- **LoadingState:**  
  - Відображення екрану завантаження  
  - Завантаження ігрових даних  
  - Ініціалізація ігрового стану (затримка 1 секунда)  
  - Закриття екрану завантаження  
  - Перехід у `GamePlayState`  
- **GamePlayState:**  
  - Виводить у UI час ігрової сесії  
