using UnityEngine;


public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] private Sprite leftSprite;
    [SerializeField] private Sprite rightSprite;
    [SerializeField] private Animator effectAnimator;
    [SerializeField] private BaseEnemyData _data;

    protected IMovingEnemy movingEnemy;
    protected IAttackEnemy attackEnemy;
    protected IEffect animatorEffect;
    protected int damage;


    protected virtual void Awake()
    {
        damage = GetDamage();
        
        movingEnemy = new MovingEnemy(GetComponent<Rigidbody2D>(), GetComponentInChildren<SpriteRenderer>(),
            leftSprite, rightSprite, _data.speed);
        attackEnemy = new AttackEnemy(damage, this);
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
    
    protected virtual int GetDamage() => _data.damage;
}
