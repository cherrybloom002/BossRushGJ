using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(string SceneName)
    {
        //int index = Random.Range(1, 4);
        
        SceneManager.LoadScene(SceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("You quit the game!");
    }
}
