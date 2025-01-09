using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float force;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.linearVelocity = new Vector2(rb.transform.position.x, rb.transform.position.y).normalized * force;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider != null)
        {
            Destroy(gameObject);
        }
    }
}
