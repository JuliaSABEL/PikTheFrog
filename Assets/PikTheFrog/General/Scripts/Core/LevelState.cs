using UnityEngine;
using System;


public class LevelState : MonoBehaviour
{
    public event Action OnGoalUnlocked;

    public bool IsGoalUnlocked => _isGoalUnlocked;

    private bool _isGoalUnlocked;


    public void UnlockGoal()
    {
        if (!_isGoalUnlocked)
        {
            _isGoalUnlocked = true;
            OnGoalUnlocked?.Invoke();
        }
    }
}
