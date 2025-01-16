using UnityEngine;


public abstract class EnemyBase : MonoBehaviour
{
    protected Vector2 direction;


    public abstract void Move();
    public abstract void OnCollide(Collider2D collider);
    public abstract void ApplyEffectOnPlayer(Player player);
}
