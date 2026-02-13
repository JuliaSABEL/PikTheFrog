using UnityEngine;


public class Goal : MonoBehaviour
{
    [SerializeField] private GameObject testWinScreen; //temp
    [SerializeField] private MonoBehaviour levelState;

    private ILevelStateService _levelStateService;
    private bool _isGoalUnlocked;


    private void Start()
    {
        _levelStateService = levelState as ILevelStateService;
        _levelStateService.OnGoalUnlocked += HandleGoalUnlocked;
    }

    private void OnDestroy()
    {
        _levelStateService.OnGoalUnlocked -= HandleGoalUnlocked;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && _isGoalUnlocked)
        {
            EndGame();
        }
    }
    
    
    private void HandleGoalUnlocked() => _isGoalUnlocked = true;

    private void EndGame()
    {
        testWinScreen.SetActive(true); //temp
    }
}
