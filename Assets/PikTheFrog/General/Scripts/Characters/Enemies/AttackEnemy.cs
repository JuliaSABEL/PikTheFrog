using UnityEngine;


public class AttackEnemy : IAttackEnemy
{
    private int _damage;


    public AttackEnemy(int damage)
    {
        _damage = damage;
    }

    public void OnCollisionPlayer(Collider2D collider)
    {
        Player player = collider.GetComponentInParent<Player>();
        player?.TakeDamage(_damage);
    }
}
