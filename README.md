# UnityInputSystem

My approach to the new input system. I included a First Person Locomotion Controller.

### How to use Inputs:
1. Create InputActionAsset.
2. Create InputContainer, assign references and InputActionAsset.
3. Create PlayerInput component and add the container.
4. Reference PlayerInput and use like previous input system.

### How to use FirstPersonLocomotionController
 1. Add a new Layer for the Player/AI, I go with "Body", as this can also be used for combat.
 2. Create GameObject, set it to Body layer, Add camera as a child to GameObject, and set as MainCamera.
 3. On the created GameObject, add a PlayerInput, CharacterController, and PlayerLocomotion.
 4. Assign the InputContainer to the Input, and a groundlayer to the LocomotionController, change Height to 1.8, and the Center to 0,0.9,0.
 5. Set the Camera's height to 1.6.
 6. Add a plane to the scene at 0,0,0. and set the scale to 50,1,50. Change the Material if you wish.

### Scene Setup
![image](https://github.com/user-attachments/assets/4c0bb869-cb0b-4557-b0ea-fe64852a2c9d)

### Player Setup
![image](https://github.com/user-attachments/assets/ff6a3c06-1ef0-4c9e-8d22-ed9f1c169b64)

### Camera Setup
![image](https://github.com/user-attachments/assets/752faaf0-525f-4341-a74a-1adb96009a06)


You don't have to use my code, this is just an example.
