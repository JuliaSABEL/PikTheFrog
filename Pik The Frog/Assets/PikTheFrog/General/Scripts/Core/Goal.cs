using UnityEngine;


public class Goal : MonoBehaviour
{
    [SerializeField] private GameObject testWinScreen; //temp

    private LevelState _levelState;


    private void Start()
    {
        _levelState = FindObjectOfType<LevelState>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && _levelState.isGoalUnlocked)
        {
            EndGame();
        }
    }


    private void EndGame()
    {
        testWinScreen.SetActive(true); //temp
    }
}
