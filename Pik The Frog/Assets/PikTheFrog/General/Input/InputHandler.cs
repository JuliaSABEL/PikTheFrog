using UnityEngine;
using UnityEngine.InputSystem;


public class InputHandler : MonoBehaviour, IInputProvider
{
    private PlayerInputActions _inputActions;
    private Vector2 _movementInput;


    private void Awake()
    {
        _inputActions = new PlayerInputActions();

        _inputActions.Player.Movement.performed += OnMovePerformed;
        _inputActions.Player.Movement.canceled += OnMoveCanceled;
    }


    public Vector2 GetMovementInput()
    {
        return _movementInput;
    }


    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        _movementInput = context.ReadValue<Vector2>();
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        _movementInput = Vector2.zero;
    }

    private void OnEnable()
    {
        _inputActions.Player.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Player.Disable();
    }

    private void OnDestroy()
    {
        _inputActions.Player.Movement.performed -= OnMovePerformed;
        _inputActions.Player.Movement.canceled -= OnMoveCanceled;
    }
}
