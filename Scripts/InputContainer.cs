using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputContainer", menuName = "CoreGame/InputContainer")]
public class InputContainer : ScriptableObject
{
    public InputActionAsset inputActionAsset;

    public InputActionReference lookAction;
    public InputActionReference moveAction;

    public InputActionReference fireAction;
    public InputActionReference aimProperty;

    public InputActionReference jumpAction;
    public InputActionReference sprintAction;
    public InputActionReference interactAction;
    public InputActionReference flashLightAction;
    public InputActionReference reloadAction;
}
