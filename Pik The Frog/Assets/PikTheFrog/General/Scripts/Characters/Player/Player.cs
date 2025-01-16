using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;

    private int _lives = 6;


    public void TakeDamage(int amount)
    {
        _lives -= amount;
        if (_lives < 0) _lives = 0;

        uiManager.UpdateLivesUI(_lives);

        if (_lives <= 0)
        {
            Die();
        }
    }

    public void ApplyEffect()
    {
        // logic
    }


    private void Die()
    {
        //Debug.Log("Player is dead");
    }
}
