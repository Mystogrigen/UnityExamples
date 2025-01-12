using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private void OnEnable() => mInputContainer.inputActionAsset.Enable();
    private void OnDisable() => mInputContainer.inputActionAsset.Disable();

    [SerializeField] private InputContainer mInputContainer;

    public Vector2 GetMoveInput() => mInputContainer.moveAction.action.ReadValue<Vector2>();
    public Vector2 GetLookInput() => mInputContainer.lookAction.action.ReadValue<Vector2>();

    public bool GetSprintInput() => mInputContainer.sprintAction.action.IsPressed();
    public bool GetJumpInput() => mInputContainer.jumpAction.action.IsPressed();
    public bool GetJumpThisFrame() => mInputContainer.jumpAction.action.WasPressedThisFrame();

    public bool GetInteractInput() => mInputContainer.interactAction.action.IsPressed();
    public bool GetInteractDown() => mInputContainer.interactAction.action.WasPressedThisFrame();
    public bool GetInteractUp() => mInputContainer.interactAction.action.WasReleasedThisFrame();

    public bool GetFlashLightDown() => mInputContainer.flashLightAction.action.WasPressedThisFrame();

    public bool GetReloadInput() => mInputContainer.reloadAction.action.IsPressed();

    public bool GetAimInput() => mInputContainer.aimProperty.action.IsPressed();
    public bool GetFireInputHeld() => mInputContainer.fireAction.action.IsPressed();
    public bool GetFireInputDown() => mInputContainer.fireAction.action.WasPressedThisFrame();
    public bool GetFireInputReleased() => mInputContainer.fireAction.action.WasReleasedThisFrame();
}
