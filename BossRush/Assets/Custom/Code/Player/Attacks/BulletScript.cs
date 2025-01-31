using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    LayerMask Player;
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    float force;
    float temp = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, 1f, Player);

        foreach (Collider2D hit in hitEnemies)
            hit.GetComponent<PlayerScript>().TakeDamage(20);
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
    }
}
