using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Fix Z Rotation
public class JumpingController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJump;
    public int exctraJumpValue;

    // Start is called before the first frame update
    void Start()
    {
        extraJump = exctraJumpValue;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);


        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        } else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded == true)
        {
            extraJump = exctraJumpValue;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)&& extraJump > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJump--;
        } else if (Input.GetKeyDown(KeyCode.UpArrow)&& extraJump == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }
}
