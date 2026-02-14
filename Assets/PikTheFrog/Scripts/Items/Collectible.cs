using UnityEngine;


public class Collectible : MonoBehaviour
{
    [SerializeField] private CollectibleData data;
    [SerializeField] private ItemManager itemManager;

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player")) Collect();
    }
    
    private void Collect()
    {
        itemManager.CollectItem();
        Destroy(gameObject);
    }
}
