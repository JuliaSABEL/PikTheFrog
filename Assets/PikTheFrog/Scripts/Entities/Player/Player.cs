using UnityEngine;


public class Player : MonoBehaviour, IPlayerVictim
{
    [SerializeField] private MonoBehaviour uiManager;
    [SerializeField] private MonoBehaviour levelLoadingManager;
    [SerializeField] private Collider2D playerCollider;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private EffectData damageEffectData;

    private ILevelLoadingService _levelLoadingService;
    private IUIManager _uiManager; 
    private IEffect _animatorEffect;
    private bool _isInvulnerable;
    private int _lives;


    private void Awake()
    {
        _lives = playerData.lives;
        _animatorEffect = new AnimatorEffect(GetComponent<Animator>(), this);
        
        _uiManager = uiManager as IUIManager;
        _levelLoadingService = levelLoadingManager as ILevelLoadingService;
    }

    
    public void TakeDamage(int amount, EnemyBase enemy)
    {
        if (_isInvulnerable) return;

        _isInvulnerable = true;
        SetEnemyCollisions(false, enemy);
        _animatorEffect.ApplyEffect(damageEffectData.transName, damageEffectData.duration, () =>
        {
            _isInvulnerable = false;
            SetEnemyCollisions(true, enemy);
        });

        _lives = Mathf.Max(_lives - amount, 0);
        _uiManager.UpdateHealthBar(_lives);
        
        if (_lives <= 0) Die();
    }

    
    private void SetEnemyCollisions(bool enable, EnemyBase enemy)
    {
        Physics2D.IgnoreCollision(playerCollider, enemy.GetComponentInChildren<Collider2D>(), !enable);
    }

    private void Die()
    {
        _levelLoadingService.ReloadCurrentLevel();
    }
}
