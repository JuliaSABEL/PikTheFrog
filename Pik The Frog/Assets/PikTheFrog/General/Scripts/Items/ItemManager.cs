using UnityEngine;


public class ItemManager : MonoBehaviour
{
    public int totalItems;

    private int _collectedItems;


    public void CollectItem()
    {
        _collectedItems++;
        UpdateUI();
        if (_collectedItems >= totalItems)
        {
            UnlockGoal();
        }
    }


    private void UpdateUI()
    {
        UIManager uiManager = FindObjectOfType<UIManager>();
        if (uiManager != null)
        {
            int remaining = totalItems - _collectedItems;
            uiManager.UpdateCollectibleCounter(remaining);
        }
    }

    private void UnlockGoal()
    {
        LevelState levelState = FindObjectOfType<LevelState>();
        levelState.SetGoalUnlocked();
    }
}
