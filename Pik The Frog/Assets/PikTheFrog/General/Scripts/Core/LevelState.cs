using UnityEngine;


public class LevelState : MonoBehaviour
{
    public bool isGoalUnlocked = false;


    public void SetGoalUnlocked()
    {
        isGoalUnlocked = true;
    }
}
