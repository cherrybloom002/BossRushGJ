using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    Slider HealthBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HealthBar.value = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        HealthBar.value -= damage;

        if(HealthBar.value <= 0 )
        {
            Destroy(gameObject);
        }
    }
}
