using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameoverMenu;
    [SerializeField] private Animator playerAnimator;  // Add player animator reference

    private void Over()
    {
        if (gameoverMenu.activeSelf)
        {
            Time.timeScale = 0; // Pause the game
            playerAnimator.enabled = false;  // Disable the Animator to stop animations
        }
    }
}
