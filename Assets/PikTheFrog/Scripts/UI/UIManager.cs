using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIManager : MonoBehaviour, IUIManager
{
    [SerializeField] private List<Image> heartImages;
    [SerializeField] private TMP_Text collectibleCounterText;


    public void UpdateHealthBar(int lives)
    {
        for (int i = 0; i < heartImages.Count; i++)
        {
            heartImages[i].enabled = i < lives;
        }
    }

    public void UpdateCollectibleCounterBar(int remaining) => collectibleCounterText.text = $"{remaining}";
}
