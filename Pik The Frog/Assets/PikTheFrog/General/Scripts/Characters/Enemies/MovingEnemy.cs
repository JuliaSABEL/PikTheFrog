using UnityEngine;


public class MovingEnemy : EnemyBase
{
    public Vector2 Direction { get; private set; }

    [SerializeField] private float speed = 5f;

    private Rigidbody2D _rb;


    public void ChooseRandomDirection()
    {
        Direction = Direction == Vector2.left ? Vector2.right : Vector2.left;
    }


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        ChooseRandomDirection();

        SetState(new EnemyMovingState(this, _rb, speed));
    }
}
