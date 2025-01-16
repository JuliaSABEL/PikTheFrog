using UnityEngine;


public class EnemyMovingState : IEnemyState
{
    private readonly MovingEnemy _enemy;
    private readonly Rigidbody2D _rb;
    private readonly float _speed;


    public EnemyMovingState(MovingEnemy enemy, Rigidbody2D rb, float speed)
    {
        _enemy = enemy;
        _rb = rb;
        _speed = speed;
    }

    public void UpdateState()
    {
        _rb.MovePosition(_rb.position + _enemy.Direction * _speed * Time.fixedDeltaTime);
    }

    public void OnCollision(Collider2D collider)
    {
        if (collider.CompareTag("Forest"))
        {
            _enemy.ChooseRandomDirection();
        }
        else if (collider.CompareTag("Player"))
        {
            Player player = collider.GetComponentInParent<Player>();
            player?.TakeDamage(1);
        }
    }
}
