using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    Slider HealthBar;
    [SerializeField]
    GameObject attackPoint;
    [SerializeField]
    LayerMask Player;
    [SerializeField]
    LayerMask BossLayer;
    [SerializeField]
    float attackRange = 2.5f;
    [SerializeField]
    Animator animator;
    [SerializeField]
    Collider2D PlayerCollider;
    [SerializeField]
    Collider2D AttackCollider;
    [SerializeField]
    GameObject player;
    [SerializeField]
    Collider2D bodyCollider;
    [SerializeField]
    GameObject bullet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HealthBar.value = 500;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float damage)
    {
        HealthBar.value -= damage;

        if (HealthBar.value <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void shoot()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.transform.position, attackRange, Player);

        foreach (Collider2D hit in hitEnemies)
                hit.GetComponent<PlayerScript>().TakeDamage(10);
    }
    public void underAtk()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.transform.position, attackRange, Player);

        foreach (Collider2D hit in hitEnemies)
            hit.GetComponent<PlayerScript>().TakeDamage(20);
    }
    public void lavaThrow()
    {
        var bull = Instantiate(bullet, attackPoint.transform.position, attackPoint.transform.rotation);
        bull.GetComponent<Rigidbody2D>().linearVelocityX = player.transform.position.x * 3;
    }
    private void OnDrawGizmos()
    {
        if (attackPoint == null) { return; }
        Gizmos.DrawWireSphere(attackPoint.transform.position, attackRange);
        if (gameObject == null) { return; }
        Gizmos.DrawWireCube(gameObject.transform.position + new Vector3(0.45f, -1.3f, 1f), new Vector3(6.4f, 5f, 5f));
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider == PlayerCollider)
        {
            if (HealthBar.value > 250)
                animator.SetBool("atk", true);
            else if (HealthBar.value < 251)
                animator.SetBool("Uatk", true);
        }
    }

    public void Underground()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        attackPoint.transform.position = transform.position;
    }

    public void EndAtk()
    {
        animator.SetBool("atk", false);
    }
    public void EndUAtk()
    {
        animator.SetBool("Uatk", false);
    }
    public void Eyet()
    {
        animator.SetBool("Eye", true);
    }
    public void Eyef()
    {
        animator.SetBool("Eye", false);
    }
    public void Sungexit()
    {
        animator.SetBool("Uexit", true);
    }
    public void Eungexit()
    {
        animator.SetBool("Uexit", false);
    }
}
