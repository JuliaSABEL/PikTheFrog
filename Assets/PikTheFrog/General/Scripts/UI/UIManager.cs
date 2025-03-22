using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIManager : MonoBehaviour
{
    [SerializeField] private List<Image> heartImages;
    [SerializeField] private TMP_Text collectibleCounterText;


    public void UpdateLivesUI(int lives)
    {
        for (int i = 0; i < heartImages.Count; i++)
        {
            heartImages[i].enabled = i < lives;
        }
    }

    public void UpdateCollectibleCounter(int remaining)
    {
        collectibleCounterText.text = $"{remaining}";
    }
}
