using UnityEngine;


public class Collectible : MonoBehaviour, ICollectible
{
    public CollectibleData data;

    private ItemManager _itemManager;


    public void Collect()
    {
        _itemManager.CollectItem();
        Destroy(gameObject);
    }


    private void Start()
    {
        _itemManager = FindObjectOfType<ItemManager>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("nyyya");
        if (collider.CompareTag("Player"))
        {
            Collect();
        }
    }
}
