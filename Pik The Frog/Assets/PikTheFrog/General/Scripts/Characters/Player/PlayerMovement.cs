using UnityEngine;
using System.Collections.Generic;


public class PlayerMovement : MonoBehaviour, ISubject
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D _rb;
    private IInputProvider _inputProvider;
    private PlayerAnimator _playerAnimator;
    private Vector2 _movementInput;

    private readonly List<IObserver> _observers = new();


    private void Awake()
    {
        _playerAnimator = GetComponent<PlayerAnimator>();
        _rb = GetComponent<Rigidbody2D>();
        _inputProvider = GetComponent<IInputProvider>();
    }

    private void FixedUpdate()
    {
        _movementInput = _inputProvider.GetMovementInput().normalized;

        Vector2 newPosition = _rb.position + _movementInput * moveSpeed * Time.fixedDeltaTime;
        _rb.MovePosition(newPosition);

        _playerAnimator.UpdateMovementAnimations(_movementInput);
        NotifyObservers();
    }


    public void AddObserver(IObserver observer) => _observers.Add(observer);

    public void RemoveObserver(IObserver observer) => _observers.Remove(observer);

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.UpdatePosition(transform.position);
        }
    }
}
