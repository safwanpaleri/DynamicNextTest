# DynamicNextTest
Scripts are Inside Assets/Scripts
All the codes are commented as well

## Task 2
Canvas Script: Created a script and attached to Canvas for managing UI items. Contains a CreateUI function which helps to create UI elements into the Events Tab.
EventUIItem script: attached to the UI elements which contains the references to title, description and time. It also updates time accordingly.
Made changes other scripts to achieve the result.

## EnemyScript: 
The main script responsible for finding all the soldiers regardless of color, moving towards them, attacking them, taking damage, and death

## RedEnemy: 
Inherited from EnemyScript, does everything as Enemy Script but coded to attack only blue soldiers, created for differentiating Red and blue. 

## BlueEnemy: 
Inherited from EnemyScript, does everything as Enemy Script but coded to attack only Red soldiers, created for differentiating Red and blue.

## SpawnManager:
Script responsible for spawning red and blue according to mouse click and mouse position

## SwordScript:
Attached to sword and detect collision to enemy and do damage to that enemy

## CanvasScript:
attached to canvas so that the health and other UI will be always facing towards the camera and in front of user.

