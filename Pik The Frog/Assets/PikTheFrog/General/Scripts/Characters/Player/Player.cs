using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;

    private int _lives = 6;


    public void TakeDamage(int amount)
    {
        Debug.Log("damage");
        _lives = Mathf.Max(_lives - amount, 0);
        uiManager.UpdateLivesUI(_lives);
        if (_lives <= 0) Die();
    }


    private void Die()
    {
        Debug.Log("dead");
    }
}
