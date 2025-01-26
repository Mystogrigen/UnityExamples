using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Mysto
{
    [CreateAssetMenu(fileName = "InputReader", menuName = "UnityExamples/Core/Input Reader")]
    public class InputReader : ScriptableObject
    {
        private static InputReader instance;
        public static InputReader Instance => instance ??= Resources.Load("InputReader") as InputReader;

        [SerializeField] private InputActionAsset mAsset;

        public event UnityAction<Vector2> MoveEvent;
        public event UnityAction<Vector2> LookEvent;
        public event UnityAction<InputAction.CallbackContext> JumpEvent;
        public event UnityAction<InputAction.CallbackContext> SprintEvent;
        
        private InputAction _moveAction;
        private InputAction _lookAction;
        private InputAction _jumpAction;
        private InputAction _sprintAction;

        private void OnEnable()
        {
            instance = Resources.Load("InputReader") as InputReader;
            FindActions();
            Subscribe();
        }
        
        private void OnDisable() => Unsubscribe();
        
        private void FindActions()
        {
            _moveAction = mAsset.FindAction("Move");
            _lookAction = mAsset.FindAction("Look");
            _jumpAction = mAsset.FindAction("Jump");
            _sprintAction = mAsset.FindAction("Sprint");
        }
        
        private void Subscribe()
        {
            SubscribeDelegate(_moveAction, OnMove);
            SubscribeDelegate(_lookAction, OnLook);
            SubscribeDelegate(_jumpAction, OnJump);
            SubscribeDelegate(_sprintAction, OnSprint);
        }
        
        private void Unsubscribe()
        {
            UnsubscribeDelegate(_moveAction, OnMove);
            UnsubscribeDelegate(_lookAction, OnLook);
            UnsubscribeDelegate(_jumpAction, OnJump);
            UnsubscribeDelegate(_sprintAction, OnSprint);
        }
        
        private void SubscribeDelegate(InputAction inputAction, Action<InputAction.CallbackContext> del)
        {
            inputAction.Enable();
            inputAction.started += del;
            inputAction.performed += del;
            inputAction.canceled += del;
        }
        
        private void UnsubscribeDelegate(InputAction inputAction, Action<InputAction.CallbackContext> del)
        {
            inputAction.started -= del;
            inputAction.performed -= del;
            inputAction.canceled -= del;
            inputAction.Disable();
        }

        private void OnMove(InputAction.CallbackContext context) => MoveEvent?.Invoke(context.ReadValue<Vector2>());
        private void OnLook(InputAction.CallbackContext context) => LookEvent?.Invoke(context.ReadValue<Vector2>());
        private void OnJump(InputAction.CallbackContext context) => JumpEvent?.Invoke(context);
        private void OnSprint(InputAction.CallbackContext context) => SprintEvent?.Invoke(context);
    }
}
