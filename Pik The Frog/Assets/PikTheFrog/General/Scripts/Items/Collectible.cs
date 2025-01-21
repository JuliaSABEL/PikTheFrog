using UnityEngine;


public class Collectible : MonoBehaviour, ICollectible
{
    [SerializeField] private CollectibleData data;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Collect();
        }
    }
}
