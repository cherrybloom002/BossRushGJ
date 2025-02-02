using UnityEngine;

public class PauseScript : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Animator playerAnimator;  // Add player animator reference

    public void Pause()
    {
        if (pauseMenu.activeSelf)
        {
            Time.timeScale = 0; // Pause the game
            playerAnimator.enabled = false;  // Disable the Animator to stop animations

        }
    }

    public void Restart()
    {
        if (!pauseMenu.activeSelf)
        {
            Time.timeScale = 1; // restart game
            playerAnimator.enabled = true;  // Disable the Animator to stop animations
        }
        
    }
}

