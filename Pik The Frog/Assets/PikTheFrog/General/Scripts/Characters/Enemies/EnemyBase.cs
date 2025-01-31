using UnityEngine;


public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] private Sprite leftSprite;
    [SerializeField] private Sprite rightSprite;
    [SerializeField] private Animator effectAnimator;

    protected IMovingEnemy movingEnemy;
    protected IAttackEnemy attackEnemy;
    protected IEffect animatorEffect;
    protected float speed = 6f;
    protected int damage = 1;
    protected bool isInvulnerable;


    protected virtual void Awake()
    {
        movingEnemy = new MovingEnemy(GetComponent<Rigidbody2D>(), GetComponentInChildren<SpriteRenderer>(), leftSprite, rightSprite, speed);
        attackEnemy = new AttackEnemy(damage);
        animatorEffect = new AnimatorEffect(effectAnimator, this);
    }

    protected virtual void Start()
    {
        movingEnemy?.StartMovement();
    }

    protected virtual void Update()
    {
        movingEnemy?.Movement();
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Forest"))
        {
            movingEnemy?.OnCollisionForest();
        }
        else if (collision.collider.CompareTag("Player"))
        {
            attackEnemy?.OnCollisionPlayer(collision.collider);
        }
    }

    protected void OnEffectEnd()
    {
        isInvulnerable = false;
    }
}
