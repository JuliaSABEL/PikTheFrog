using UnityEngine;


public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;
    
    private Vector2 _lastMovementDirection = Vector2.zero;


    public void UpdateMovementAnimations(Vector2 movement)
    {
        float speed = movement.magnitude;
        animator.SetFloat("Speed", speed);

        if (speed > 0.01f) _lastMovementDirection = movement.normalized;
        
        animator.SetFloat("DirectionX", _lastMovementDirection.x);
        animator.SetFloat("DirectionY", _lastMovementDirection.y);
    }
}
