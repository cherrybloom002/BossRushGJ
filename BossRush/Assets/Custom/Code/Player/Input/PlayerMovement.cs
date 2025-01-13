using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    
    Vector2 moveDirection;

    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private LayerMask collisionMask;
    //SpriteRenderer spRend;
    [SerializeField]
    public Animator animator;
    [SerializeField]
    public int moveSpeed;
    [SerializeField]
    public int jumpPower;
    [SerializeField]
    private float groundCheckRadius;
    
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //spRend = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(moveDirection.x));

        bool flipped = moveDirection.x < 0;
        this.transform.rotation = Quaternion.Euler(new Vector3(0f, flipped ? 180f : 0f, 0f));

    }

    public void Jump(InputAction.CallbackContext value)
    {
        if (value.started && isGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
        }
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionMask);
    }

    public void Spin(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            animator.SetTrigger("tg");
        }
    }

    public void Move(InputAction.CallbackContext value)
    {
        moveDirection = value.ReadValue<Vector2>();
        //spRend.flipX = rb.linearVelocity.x > 0f;
        
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, rb.linearVelocity.y);
    }
}
