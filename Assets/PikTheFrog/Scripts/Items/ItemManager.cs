using UnityEngine;
using System;


public class ItemManager : MonoBehaviour
{
    public event Action<int> OnItemCollected;
    public event Action OnAllItemsCollected;
    
    [SerializeField] private MonoBehaviour uiManager;
    [SerializeField] private MonoBehaviour levelState;
    [SerializeField] private int totalItems;

    private IUIManager _uiManager; 
    private ILevelStateService _levelStateService; 
    private int _collectedItems;
    

    private void Start()
    {
        _uiManager = uiManager as IUIManager;
        _levelStateService = levelState as ILevelStateService;
        
        OnAllItemsCollected += _levelStateService.UnlockGoal;
        OnItemCollected += _uiManager.UpdateCollectibleCounterBar;
    }

    private void OnDestroy()
    {
        OnAllItemsCollected -= _levelStateService.UnlockGoal;
        OnItemCollected -= _uiManager.UpdateCollectibleCounterBar;
    }

    public int RemainingItems => totalItems - _collectedItems;
    
    public void CollectItem()
    {
        _collectedItems++;
        OnItemCollected?.Invoke(RemainingItems);

        if (_collectedItems >= totalItems)
        {
            OnAllItemsCollected?.Invoke();
        }
    }
}
