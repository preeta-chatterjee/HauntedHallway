# Haunted Hallway

A 2D browser-based survival game built in Unity for CSYE 7270 — Building Virtual Environments at Northeastern University. A rigged zombie walks toward the player while five glowing keys spawn at random positions on screen. Click all five before the zombie reaches you to escape.

This project was built as Assignment 6 for the animation requirement, and serves as a 2D companion piece to the main final project Hallway Hunters — a first-person survival horror game set in a zombie-infected apartment building.

---

## Play

[Play in browser on itch.io](https://lunosstar.itch.io/haunted-hallway) 

Works on desktop and mobile browsers. Click or tap the keys to collect them.

---

## Gameplay

A zombie walks in from the right side of the screen. Thirteen keys spawn one at a time at random positions. Click or tap each key before the zombie reaches the left edge. Collect all thirteen to escape. Let the zombie through and it is over.

- Win condition: collect all 13 keys before the zombie exits the screen
- Lose condition: zombie reaches the left edge before all keys are collected
- Restart and Exit buttons appear after every win or lose state

---

## Animations

This project demonstrates three animations built for the course assignment.

**Animation 1 — Rotating key (simple object animation)**
A key sprite rotates continuously on the Z axis at 90 degrees per second using a KeyRotator script. No rig required. The key is a Prefab instantiated at runtime by the KeySpawner, so the rotation begins fresh on every spawn.

**Animation 2 — Rigged sprite**
A zombie character assembled from six individually generated limb sprites: head, torso, right arm, left arm, right leg, and left leg. Each sprite has a custom pivot point set in Unity's Sprite Editor — top center for arms and legs so they rotate from the joint, bottom center for the head so it pivots from the neck. The six parts are assembled in a parent-child hierarchy with Torso, Leg_Right, and Leg_Left as direct children of the Zombie root, and Head, Arm_Right, and Arm_Left as children of Torso.

**Animation 3 — Walk cycle**
A manually keyframed walk cycle on the rigged zombie. Sample rate is 12 frames per second. Loop Time is enabled on the animation clip.

---

## Controls

| Input | Action |
|-------|--------|
| Left click / Tap | Collect key |
| Restart button | Reload the scene |
| Exit button | Quit the application |

---

## Project Structure
```
Assets/
├── Animations/
│   └── ZombieWalk.anim
├── Prefabs/
│   └── Key.prefab
├── Scenes/
│   └── MainScene.unity
├── Scripts/
│   ├── GameManager.cs
│   ├── KeyPickup.cs
│   ├── KeyRotator.cs
│   ├── KeySpawner.cs
│   └── ZombieWalker.cs
└── Sprites/
├── zombie_head.png
├── zombie_torso.png
├── zombie_arm_right.png
├── zombie_arm_left.png
├── zombie_leg_right.png
├── zombie_leg_left.png
└── key.png
```
---

## Scripts

**GameManager.cs** — Singleton that tracks game state. Exposes WinGame, LoseGame, RestartGame, and ExitGame methods. Reveals the Restart button on game end. No Time.timeScale is used — the event system stays active after win and lose states so buttons remain clickable.

**KeyRotator.cs** — Rotates the key GameObject on the Z axis every frame using transform.Rotate.

**KeyPickup.cs** — Detects mouse clicks and touch taps using Unity's new Input System package. Casts a Physics2D.Raycast from the input position converted to world space. If the raycast hits the key's own collider, calls KeyCollected on the KeySpawner.

**KeySpawner.cs** — Manages the key collection sequence. Instantiates the Key Prefab at a random world position within defined screen bounds. Tracks keys collected and calls WinGame when all five are collected. Calls LoseGame when the zombie reaches the edge.

**ZombieWalker.cs** — Translates the Zombie root object left at 1.5 units per second. Checks the game over state each frame and disables the Animator component when the game ends, freezing the walk animation in place.

---

## Assets

Zombie limb sprites and key sprite were generated using Google Gemini and cleaned up in Adobe Photoshop. 

No third-party code assets or Unity Asset Store packages were used.

---

## Built With

- Unity 6
- Unity Input System package
- TextMeshPro
- WebGL build target

---

## Related Project

Hallway Hunters - The main final project. A first-person survival horror game in Unreal Engine 5 set in a zombie-infected apartment building. Haunted Hallway shares the same core premise and horror aesthetic.
Currently in progress.

---

## License

MIT License — Copyright 2026 Preeta Chatterjee. See LICENSE for full terms.

Zombie and key sprites generated using Google Gemini (Google DeepMind). Per Google's usage policy, users retain ownership of content created using the service.
