using System;


public interface ILevelStateService
{
    event Action OnGoalUnlocked;
    
    void UnlockGoal();
}
