using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIManager : MonoBehaviour, IUIManager
{
    [SerializeField] private List<Image> heartImages;
    [SerializeField] private TMP_Text collectibleCounterText;
    [SerializeField] private MonoBehaviour itemManager;

    private IItemCollectionService _itemService;


    public void UpdateHealthBar(int lives)
    {
        for (int i = 0; i < heartImages.Count; i++)
        {
            heartImages[i].enabled = i < lives;
        }
    }

    
    private void Start()
    {
        _itemService = itemManager as IItemCollectionService;
        _itemService.OnItemCollected += UpdateCollectibleCounterBar;
    }

    private void OnDestroy()
    {
        _itemService.OnItemCollected -= UpdateCollectibleCounterBar;
    }
    
    private void UpdateCollectibleCounterBar(int remaining) => collectibleCounterText.text = $"{remaining}";
}
