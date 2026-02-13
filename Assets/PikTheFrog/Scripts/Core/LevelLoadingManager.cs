using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelLoadingManager : MonoBehaviour, ILevelLoadingService
{
    public void ReloadCurrentLevel()
    {
        var currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void LoadNextLevel()     //for the future
    {
        var currentIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentIndex + 1 < SceneManager.sceneCountInBuildSettings) 
        {
            SceneManager.LoadScene(currentIndex + 1);
        }
    }
}
