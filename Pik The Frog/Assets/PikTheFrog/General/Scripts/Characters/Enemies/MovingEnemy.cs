using UnityEngine;


public class MovingEnemy : IMovingEnemy
{
    public Vector2 Direction { get; private set; }

    private float _speed;
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    private Sprite _leftSprite;
    private Sprite _rightSprite;


    public MovingEnemy(Rigidbody2D rb, SpriteRenderer spriteRenderer, Sprite leftSprite, Sprite rightSprite, float speed)
    {
        _rb = rb;
        _spriteRenderer = spriteRenderer;
        _leftSprite = leftSprite;
        _rightSprite = rightSprite;
        _speed = speed;
    }

    public void StartMovement()
    {
        ChangeDirection();
    }

    public void Movement()
    {
        _rb.MovePosition(_rb.position + Direction * _speed * Time.fixedDeltaTime);
    }

    public void OnCollisionForest()
    {
         ChangeDirection();
    }


    private void ChangeDirection()
    {
        Direction = Direction == Vector2.left ? Vector2.right : Vector2.left;

        UpdateSprite();
    }

    private void UpdateSprite()
    {
        _spriteRenderer.sprite = Direction == Vector2.left ? _leftSprite : _rightSprite;
    }
}
