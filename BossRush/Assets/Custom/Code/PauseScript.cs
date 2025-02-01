using UnityEngine;

public class PauseScript : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Animator playerAnimator;  // Add player animator reference

    private void Update()
    {
        if (pauseMenu.activeSelf)
        {
            Time.timeScale = 0; // Pause the game
            playerAnimator.enabled = false;  // Disable the Animator to stop animations
        }
        else
        {
            Time.timeScale = 1; // Resume the game
            playerAnimator.enabled = true;  // Enable the Animator to resume animations
        }
    }
}

