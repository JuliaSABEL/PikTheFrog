using UnityEngine;


public class ItemManager : MonoBehaviour
{
    public event System.Action<int> OnItemCollected;
    public event System.Action OnAllItemsCollected;

    public int RemainingItems => totalItems - _collectedItems;

    [SerializeField] private int totalItems;

    private int _collectedItems;


    public void CollectItem()
    {
        _collectedItems++;
        OnItemCollected?.Invoke(RemainingItems);

        if (_collectedItems >= totalItems)
        {
            OnAllItemsCollected?.Invoke();
        }
    }


    private void Start()
    {
        var levelState = FindObjectOfType<LevelState>();
        if (levelState != null)
        {
            OnAllItemsCollected += levelState.UnlockGoal;
        }

        var uiManager = FindObjectOfType<UIManager>();
        if (uiManager != null)
        {
            OnItemCollected += uiManager.UpdateCollectibleCounter;
        }
    }
}
