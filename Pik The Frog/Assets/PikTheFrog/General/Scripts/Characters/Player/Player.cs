using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private PlayerEffectController playerEffectController;

    private bool _isInvulnerable;
    private int _lives = 6;


    public void TakeDamage(int amount)
    {
        if (_isInvulnerable) return;

        _isInvulnerable = true;
        playerEffectController.ApplyEffect("IsDamaged", 3f, OnEffectEnd);

        _lives = Mathf.Max(_lives - amount, 0);
        uiManager.UpdateLivesUI(_lives);
        if (_lives <= 0) Die();
    }


    private void OnEffectEnd()
    {
        _isInvulnerable = false;
    }

    private void Die()
    {
        FindObjectOfType<LevelManager>().ReloadCurrentLevel();
    }
}
