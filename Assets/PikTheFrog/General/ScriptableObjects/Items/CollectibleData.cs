using UnityEngine;


[CreateAssetMenu(fileName = "NewCollectible", menuName = "Collectibles/Collectible")]
public class CollectibleData : ScriptableObject
{
    public string itemName;
    public Sprite itemSprite;
}
