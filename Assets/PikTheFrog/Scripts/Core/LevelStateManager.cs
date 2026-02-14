using UnityEngine;
using System;


public class LevelStateManager : MonoBehaviour, ILevelStateService
{
    public event Action OnGoalUnlocked;
    
    [SerializeField] private MonoBehaviour itemManager;

    private IItemCollectionService _itemService;
    
    
    private void Start()
    {
        _itemService = itemManager as IItemCollectionService;
        _itemService.OnAllItemsCollected += UnlockGoal;
    }

    private void OnDestroy()
    {
        _itemService.OnAllItemsCollected -= UnlockGoal;
    }

    private void UnlockGoal() => OnGoalUnlocked?.Invoke();
}
