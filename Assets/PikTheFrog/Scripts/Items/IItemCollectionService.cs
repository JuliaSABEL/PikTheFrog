using System;


public interface IItemCollectionService
{
    public event Action<int> OnItemCollected;
    public event Action OnAllItemsCollected;
}
