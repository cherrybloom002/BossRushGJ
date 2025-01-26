using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    
    Vector2 moveDirection;

    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private LayerMask collisionMask;
    [SerializeField]
    public Animator animator;
    [SerializeField]
    public int moveSpeed;
    [SerializeField]
    public int jumpPower;
    [SerializeField]
    private int maxJump = 2;
    private int jumpLeft;
    [SerializeField]
    private float groundCheckRadius;
    [SerializeField]
    ChargeBarScript charge;
    [SerializeField]
    Attacks attack;
    int damage = 10;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        charge = GetComponentInChildren<ChargeBarScript>();
        jumpLeft = maxJump;
        attack = GetComponent<Attacks>();
    }
    
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(moveDirection.x));

        bool flipped = moveDirection.x < 0;
        this.transform.rotation = Quaternion.Euler(new Vector3(0f, flipped ? 180f : 0f, 0f));
    }

    public void Jump(InputAction.CallbackContext value)
    {

        if(isGrounded() && rb.linearVelocity.y <= 0)
        {
            jumpLeft = maxJump;
        }

        if (value.started && jumpLeft > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
            jumpLeft -= 1;
        }
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionMask);
    }

    public void Spec()
    {
        attack.shoot(25);
    }
    public void endSpec()
    {
        animator.SetBool("spec", false);
    }
    public void startSpec()
    {
        animator.SetBool("spec", true);
    }


    public void Spin(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            animator.SetBool("TG", true);
        }else if (value.canceled)
        {
            animator.SetBool("TG", false);
            attack.shoot(damage);
            damage = 10;
        }
    }

    public void Move(InputAction.CallbackContext value)
    {
        moveDirection = value.ReadValue<Vector2>();
        
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, rb.linearVelocity.y);
    }
}
