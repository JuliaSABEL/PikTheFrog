using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private MonoBehaviour cameraObserver;
    [SerializeField] private MonoBehaviour inputHandler;
    [SerializeField] private PlayerAnimator playerAnimator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private PlayerData playerData;
    
    private IInputProvider _inputProvider;
    private ICameraObserver _cameraObserver;
    private Vector2 _movementInput;


    private void Awake()
    {
        _inputProvider = inputHandler as IInputProvider;
        _cameraObserver = cameraObserver as ICameraObserver;
    }

    private void FixedUpdate()
    {
        _movementInput = _inputProvider.GetMovementInput();

        float speedFactor = _movementInput.magnitude;
        Vector2 newPosition = rb.position + _movementInput.normalized * playerData.maxSpeed * speedFactor * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);

        playerAnimator.UpdateMovementAnimations(_movementInput);
        _cameraObserver.UpdatePosition(transform.position);
    }
}
