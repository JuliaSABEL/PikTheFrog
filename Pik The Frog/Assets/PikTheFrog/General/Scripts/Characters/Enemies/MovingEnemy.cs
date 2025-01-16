using UnityEngine;


public class MovingEnemy : EnemyBase
{
    [SerializeField] private float speed = 5f;

    private Rigidbody2D _rb;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        ChooseRandomDirection();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollide(collision.collider);
    }


    public override void Move()
    {
        _rb.MovePosition(_rb.position + direction * speed * Time.fixedDeltaTime);
    }

    public override void OnCollide(Collider2D collider)
    {
        if (collider.CompareTag("Forest"))
        {
            ChooseRandomDirection();
        }
        else if (collider.CompareTag("Player"))
        {
            Player player = collider.GetComponentInParent<Player>();
            if (player != null)
            {
                ApplyEffectOnPlayer(player);
            }
        }
    }

    public override void ApplyEffectOnPlayer(Player player)
    {
        player.TakeDamage(1);
        player.ApplyEffect();
    }


    private void ChooseRandomDirection()
    {
        direction = direction == Vector2.left ? Vector2.right : Vector2.left;
    }
}
