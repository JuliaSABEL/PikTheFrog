using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private Collider2D playerCollider;
    [SerializeField] private LayerMask enemyLayer;

    private IEffect _animatorEffect;
    private bool _isInvulnerable;
    private int _lives = 6;


    private void Awake()
    {
        _animatorEffect = new AnimatorEffect(GetComponent<Animator>(), this);
    }

    public void TakeDamage(int amount)
    {
        if (_isInvulnerable) return;

        _isInvulnerable = true;
        SetEnemyCollisions(false);
        _animatorEffect.ApplyEffect("IsDamaged", 3f, OnEffectEnd);

        _lives = Mathf.Max(_lives - amount, 0);
        uiManager.UpdateLivesUI(_lives);
        if (_lives <= 0) Die();
    }

    private void SetEnemyCollisions(bool enable)
    {
        var enemies = FindObjectsOfType<EnemyBase>();
        foreach (var enemy in enemies)
        {
            Physics2D.IgnoreCollision(playerCollider, enemy.GetComponentInChildren<Collider2D>(), !enable);
        }
    }

    private void OnEffectEnd()
    {
        _isInvulnerable = false;
        SetEnemyCollisions(true);
    }

    private void Die()
    {
        FindObjectOfType<LevelManager>().ReloadCurrentLevel();
    }
}
