using UnityEngine;


public class AttackEnemy : IAttackEnemy
{
    private EnemyBase _attack;
    private int _damage;
    

    public AttackEnemy(int damage, EnemyBase attack)
    {
        _damage = damage;
        _attack = attack;
    }

    public void OnCollisionPlayer(Collider2D collider)
    {
        var victim = collider.GetComponentInParent<IPlayerVictim>();
        victim?.TakeDamage(_damage, _attack);
    }
}
