public class RedMushroom : EnemyBase
{
    private readonly int _redDamage = 2;


    protected override void Awake()
    {
        damage = _redDamage;

        base.Awake();
    }
}
