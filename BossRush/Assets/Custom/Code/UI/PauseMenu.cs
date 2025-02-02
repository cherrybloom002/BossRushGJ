using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void Menu(string menu)
    {
        SceneManager.LoadScene(menu);
    }
}
