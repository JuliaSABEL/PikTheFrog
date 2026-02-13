using UnityEngine;


[CreateAssetMenu(fileName = "NewCollectibleData", menuName = "SO/Collectibles/CollectibleData")]
public class CollectibleData : ScriptableObject
{
    [SerializeField] private string _itemName;
    [SerializeField] private Sprite _itemSprite;
    
    public string itemName => _itemName;
    public Sprite itemSprite => itemSprite;
}
