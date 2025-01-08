using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    SpriteRenderer spRend;

    public int moveSpeed;

    public int jumpPower;
    
    Vector2 moveDirection;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spRend = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
   
    }

    public void Jump(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
        }
    }

    public void Move(InputAction.CallbackContext value)
    {
        moveDirection = value.ReadValue<Vector2>();
        spRend.flipX = rb.linearVelocity.x > 0f;
        
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, rb.linearVelocity.y);
    }
}
