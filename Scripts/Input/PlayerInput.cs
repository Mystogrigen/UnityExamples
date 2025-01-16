using UnityEngine;

namespace UnityExamples
{
    public class PlayerInput : MonoBehaviour
    {
        private void OnEnable() => mInputContainer.inputActionAsset.Enable();
        private void OnDisable() => mInputContainer.inputActionAsset.Disable();
        
        [SerializeField] private InputContainer mInputContainer;
        public Vector2 GetMoveInput() => mInputContainer.moveAction.action.ReadValue<Vector2>();
        public Vector2 GetLookInput() => mInputContainer.lookAction.action.ReadValue<Vector2>();
        
        public bool GetSprintInput() => mInputContainer.sprintAction.action.IsPressed();
        public bool GetJumpThisFrame() => mInputContainer.jumpAction.action.WasPressedThisFrame();
    }
}
