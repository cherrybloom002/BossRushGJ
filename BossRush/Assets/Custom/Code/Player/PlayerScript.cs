using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private Slider PlayerHealth;
    [SerializeField] private GameObject gameOverScreen; // Reference to the Game Over UI

    void Start()
    {
        PlayerHealth.value = 100;
        gameOverScreen.SetActive(false); // Ensure Game Over screen is hidden at start
    }

    public void TakeDamage(float damage)
    {
        PlayerHealth.value -= damage;

        if (PlayerHealth.value <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        gameOverScreen.SetActive(true); // Show Game Over screen
        Destroy(gameObject); // Destroy player object
    }
}

