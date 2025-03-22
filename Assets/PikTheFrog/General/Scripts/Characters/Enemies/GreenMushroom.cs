using UnityEngine;


public class GreenMushroom : EnemyBase
{
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Forest"))
        {
            movingEnemy?.OnCollisionForest();
        }
        else if (collision.collider.CompareTag("Player"))
        {
            attackEnemy?.OnCollisionPlayer(collision.collider);
            animatorEffect.ApplyEffect("IsPoisoning", 6f, OnEffectEnd);
        }
    }
}
