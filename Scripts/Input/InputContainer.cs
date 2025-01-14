using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputContainer", menuName = "CoreGame/InputContainer")]
public class InputContainer : ScriptableObject
{
    public InputActionAsset inputActionAsset;

    public InputActionReference lookAction;
    public InputActionReference moveAction;

    public InputActionReference jumpAction;
    public InputActionReference sprintAction;
}
