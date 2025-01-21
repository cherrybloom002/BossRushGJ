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

        if (HealthBar.value <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void shoot()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.transform.position, attackRange, Player);

        foreach (Collider2D hit in hitEnemies)
        {
            hit.GetComponent<PlayerScript>().TakeDamage(10);
        }
    }
    public void underAtk()
    {
        //attackPoint.transform.position = new Vector3(player.transform.position.x, attackPoint.transform.position.y, attackPoint.transform.position.z);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.transform.position, attackRange, Player);

        foreach (Collider2D hit in hitEnemies)
        {
            hit.GetComponent<PlayerScript>().TakeDamage(10);
        }
    }
    private void OnDrawGizmos()
    {
        if (attackPoint == null) { return; }
        Gizmos.DrawWireSphere(attackPoint.transform.position, attackRange);
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider == PlayerCollider)
        {
            if (HealthBar.value > 50)
                animator.SetBool("atk", true);
            else if (HealthBar.value < 51)
                animator.SetBool("Uatk", true);
        }
    }

    //public void Underground()
    //{
        
    //    transform.position -= new Vector3(0f, 7f, 0f);
    //    attackPoint.transform.position = new Vector3(0f, 4f, 0f);
    //}

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
