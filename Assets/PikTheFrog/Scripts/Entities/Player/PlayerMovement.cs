using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private MonoBehaviour cameraObserver;

    private Rigidbody2D _rb;
    private IInputProvider _inputProvider;
    private ICameraObserver _cameraObserver;
    private PlayerAnimator _playerAnimator;
    private Vector2 _movementInput;


    private void Awake()
    {
        _playerAnimator = GetComponent<PlayerAnimator>();
        _rb = GetComponent<Rigidbody2D>();
        _inputProvider = GetComponent<IInputProvider>();
        
        _cameraObserver = cameraObserver as ICameraObserver;
    }

    private void FixedUpdate()
    {
        _movementInput = _inputProvider.GetMovementInput();

        float speedFactor = _movementInput.magnitude;
        Vector2 newPosition = _rb.position + _movementInput.normalized * playerData.maxSpeed * speedFactor * Time.fixedDeltaTime;
        _rb.MovePosition(newPosition);

        _playerAnimator.UpdateMovementAnimations(_movementInput);
        _cameraObserver.UpdatePosition(transform.position);
    }
}
