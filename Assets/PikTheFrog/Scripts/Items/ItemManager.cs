using UnityEngine;
using System;


public class ItemManager : MonoBehaviour, IItemCollectionService
{
    public event Action<int> OnItemCollected;
    public event Action OnAllItemsCollected;
    
    [SerializeField] private int totalItems;

    private int _collectedItems;
    
    
    public void CollectItem()
    {
        _collectedItems++;

        int remaining = totalItems - _collectedItems;
        OnItemCollected?.Invoke(remaining);

        if (_collectedItems >= totalItems) OnAllItemsCollected?.Invoke();
    }
}
