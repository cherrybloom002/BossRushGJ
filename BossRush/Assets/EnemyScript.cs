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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HealthBar.value = 100;
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.transform.position, attackRange, Player);

        foreach (Collider2D hit in hitPlayer)
        {
            //hit.GetComponent<PlayerScript>().TakeDamage(10);
            animator.SetBool("atk", true);
        }
    }

    public void TakeDamage(int damage)
    {
        HealthBar.value -= damage;

        if (HealthBar.value <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void shoot(Collider2D hit)
    {
        //Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.transform.position, attackRange, Player);

        //foreach (Collider2D hit in hitEnemies)
        //{
            hit.GetComponent<PlayerScript>().TakeDamage(10);
            //animator.SetBool("atk", true);
        //}
    }

    private void OnDrawGizmos()
    {
        if (attackPoint == null) { return; }
        Gizmos.DrawWireSphere(attackPoint.transform.position, attackRange);
    }

    //public void OnCollisionStay2D(Collision2D collision)
    //{
    //    if(collision.collider == PlayerCollider)
    //    {
    //        animator.SetBool("atk", true);
    //    }
    //}

    public void EndAtk()
    {
        animator.SetBool("atk", false);
    }

}
