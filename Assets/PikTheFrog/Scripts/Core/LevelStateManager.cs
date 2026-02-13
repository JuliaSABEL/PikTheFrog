using UnityEngine;
using System;


public class LevelStateManager : MonoBehaviour, ILevelStateService
{
    public event Action OnGoalUnlocked;
    

    public void UnlockGoal() => OnGoalUnlocked?.Invoke();
}
