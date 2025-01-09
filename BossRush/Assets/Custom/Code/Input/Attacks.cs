using UnityEngine;
using UnityEngine.InputSystem;

public class Attacks : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    GameObject pos;

    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pos = GameObject.FindGameObjectWithTag("BulletPoint");
        bulletPos = pos.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void shoot(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            Instantiate(bullet, bulletPos.position, Quaternion.identity);
        }
    }
    
}
