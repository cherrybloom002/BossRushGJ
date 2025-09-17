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
    [SerializeField]
    Slider specialSlider;
    [SerializeField] private GameObject pauseMenu;

    [SerializeField] private GameObject gameOver;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        charge = GetComponentInChildren<ChargeBarScript>();
        jumpLeft = maxJump;
        attack = GetComponent<Attacks>();
    }
    
    void Update()
    {
        if (IsGamePaused()) return;
        if (IsGameOver()) return;
        animator.SetFloat("Speed", Mathf.Abs(moveDirection.x));

        bool flipped = moveDirection.x < 0;
        transform.rotation = Quaternion.Euler(new Vector3(0f, flipped ? 180f : 0f, 0f));
    }

    public void Jump(InputAction.CallbackContext value)
    {

        if(isGrounded() /*&& rb.linearVelocity.y <= 0*/)
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
        if (specialSlider.value == 500)
        {
            animator.SetBool("spec", true);
            specialSlider.value = 0;
        }
    }


    public void Spin(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            animator.SetBool("TG", true);
        }else if (value.canceled)
        {
            animator.SetBool("TG", false);
        }
    }

    public void Move(InputAction.CallbackContext value)
    {
        if (IsGamePaused()) return;
        if (IsGameOver()) return;
        moveDirection = value.ReadValue<Vector2>();
        
    }

    private bool IsGamePaused()
    {
        return pauseMenu.activeSelf;
    }

    private bool IsGameOver()
    {
        return gameOver.activeSelf;
    }

    void FixedUpdate()
    {
        if (IsGamePaused()) return;
        if (IsGameOver()) return;
        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, rb.linearVelocity.y);
    }
}
