using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private bool isGrounded;    //raycast ground
    public Transform groundCheck;   //gameObject under player   
    public float checkRadius;
    public LayerMask whatIsGround;     //layer that indicate ground
    private int extraJumps;
    public int extraJumpInput;
    public KeyCode key, keyW;
    ////Animator
    //public Animator animator;
    private Animator animator;

    ////wall
    bool isTouchingFront;
    public Transform frontCheck;
    bool wallSliding;
    public float wallSlidingSpeed;
    public float checkWallRadius;

    ////DUSTT
    public ParticleSystem dust;


    void Start()
    {
        extraJumps = extraJumpInput;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate() //for physic
    {
        int whatIsGround = LayerMask.GetMask("door", "RoomTile", "spike", "Enemy");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(moveInput));
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        //GetAxisRaw snap -1,0,1
        if (facingRight == false && moveInput > 0) {
            Flip();
        } else if (facingRight == true && moveInput < 0) {
            Flip();
        }
    }

    void Update()
    {
        if (isGrounded == true) {
            extraJumps = extraJumpInput;
        }

        if ((Input.GetKeyDown(key) || Input.GetKeyDown(keyW)) && extraJumps > 0) {
            CreateDust();
            //animator.SetTrigger("IsJumping");
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        } else if ((Input.GetKeyDown(key) || Input.GetKeyDown(keyW)) && extraJumps == 0 && isGrounded == true) {
            CreateDust();
            //animator.SetTrigger("IsJumping");
            ////Vector2.up short for Vector2(0, 1)
            rb.velocity = Vector2.up * jumpForce;
        }
            //animator.SetBool("IsJumping", false);

        //for touching wall
        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, checkWallRadius, whatIsGround);

        if (isTouchingFront == true && isGrounded == false && moveInput != 0)
        {
            wallSliding = true;
        } else {
            wallSliding = false;
        }

        if (wallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue)); //clamp for floor and ceiling
        }
    }

    void Flip()
    {
        if (isGrounded == true) 
        {
            CreateDust();
        }
        facingRight = !facingRight;
        Vector3 Scalar = transform.localScale;
        //matrix scale -1 flip
        Scalar.x *= -1;
        transform.localScale = Scalar;
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck == null)
            return;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
        Gizmos.DrawWireSphere(frontCheck.position, checkWallRadius);
    }

    void CreateDust()
    {
        dust.Play();
    }
}
