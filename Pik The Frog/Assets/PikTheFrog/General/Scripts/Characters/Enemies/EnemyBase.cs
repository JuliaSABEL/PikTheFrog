using UnityEngine;


public abstract class EnemyBase : MonoBehaviour
{
    protected IEnemyState currentState;


    public void SetState(IEnemyState newState)
    {
        currentState = newState;
    }


    private void Update()
    {
        currentState?.UpdateState();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentState?.OnCollision(collision.collider);
    }
}
