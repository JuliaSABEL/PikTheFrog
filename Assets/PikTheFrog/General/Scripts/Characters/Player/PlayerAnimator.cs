using UnityEngine;


public class PlayerAnimator : MonoBehaviour, IPlayerAnimator
{
    private Animator _animator;
    private Vector2 _lastMovementDirection = Vector2.zero;


    public void UpdateMovementAnimations(Vector2 movement)
    {
        float speed = movement.magnitude;
        _animator.SetFloat("Speed", speed);

        if (speed > 0.01f)
        {
            _lastMovementDirection = movement.normalized;
        }

        _animator.SetFloat("DirectionX", _lastMovementDirection.x);
        _animator.SetFloat("DirectionY", _lastMovementDirection.y);
    }


    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
}
