using UnityEngine;
using UnityEngine.InputSystem;

public class Attacks : MonoBehaviour
{
    public GameObject bullet;
    [SerializeField]
    public Transform attackPoint;
    GameObject pos;
    Rigidbody2D rb;
    Collider2D collider;
    [SerializeField]
    float attackRange = 5.5f;
    public LayerMask enemyLayers;
    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pos = GameObject.FindGameObjectWithTag("BulletPoint");
        attackPoint = pos.GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void shoot(int damage)
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D hit in hitEnemies) 
        {
            hit.GetComponent<EnemyScript>().TakeDamage(damage);
        }
        
    }

    private void OnDrawGizmos()
    {
        if(attackPoint == null) {  return; }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
