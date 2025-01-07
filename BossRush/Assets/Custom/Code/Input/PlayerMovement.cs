using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public float moveSpeed;

    public int JumpPower;
    
    Vector2 _moveDirection;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
   
    }

    public void Jump(InputAction.CallbackContext value)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(rb.linearVelocity.x, JumpPower));
        }
    }

    public void Move(InputAction.CallbackContext value)
    {
        _moveDirection = value.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(_moveDirection.x * moveSpeed, _moveDirection.y * moveSpeed);
    }
}
