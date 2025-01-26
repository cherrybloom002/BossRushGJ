using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Attacks : MonoBehaviour
{
    public GameObject bullet;
    [SerializeField]
    GameObject attackPoint;
    [SerializeField]
    float attackRange = 5.5f;
    public LayerMask enemyLayers;
    [SerializeField]
    Slider specialSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void shoot(int damage)
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.transform.position, attackRange, enemyLayers);

        foreach (Collider2D hit in hitEnemies) 
        {
            hit.GetComponent<EnemyScript>().TakeDamage(damage);
            specialSlider.value += 10;
        }
    }

    private void OnDrawGizmos()
    {
        if(attackPoint == null) {  return; }
        Gizmos.DrawWireSphere(attackPoint.transform.position, attackRange);
    }

}
