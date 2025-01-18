using UnityEngine;


public class MovingEnemy : EnemyBase
{
    public Vector2 Direction { get; private set; }

    [SerializeField] private float speed = 6f;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite leftSprite;
    [SerializeField] private Sprite rightSprite;

    private Rigidbody2D _rb;


    public void ChooseRandomDirection()
    {
        Direction = Direction == Vector2.left ? Vector2.right : Vector2.left;

        UpdateSprite();
    }


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        ChooseRandomDirection();

        SetState(new EnemyMovingState(this, _rb, speed));
    }


    private void UpdateSprite()
    {
        spriteRenderer.sprite = Direction == Vector2.left ? leftSprite : rightSprite;
    }
}
