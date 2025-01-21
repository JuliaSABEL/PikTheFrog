using UnityEngine;


public class Goal : MonoBehaviour
{
    [SerializeField] private GameObject testWinScreen; //temp

    private LevelState _levelState;
    private bool _isGoalUnlocked;


    private void Start()
    {
        _levelState = FindObjectOfType<LevelState>();

        if (_levelState != null)
        {
            _isGoalUnlocked = _levelState.IsGoalUnlocked;

            _levelState.OnGoalUnlocked += HandleGoalUnlocked;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && _isGoalUnlocked)
        {
            EndGame();
        }
    }

    private void OnDestroy()
    {
         _levelState.OnGoalUnlocked -= HandleGoalUnlocked;
    }


    private void HandleGoalUnlocked()
    {
        _isGoalUnlocked = true;
    }

    private void EndGame()
    {
        testWinScreen.SetActive(true); //temp
    }
}
