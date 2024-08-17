using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb2d;
    Vector2 moveDir;
    public float speed = 5;
    public float jumpForce = 12;
    public LayerMask ground;
    public float activiteGravityScale;
    [SerializeField] bool isGrounded;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
    }
    private void FixedUpdate()
    {
        GroundCheck();
    }
    void Jump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            rb2d.AddForce(new Vector2(rb2d.velocity.x, jumpForce), ForceMode2D.Impulse);
        if (rb2d.velocity.y < 0)
            rb2d.gravityScale = 1.5f * activiteGravityScale;
        else
            rb2d.gravityScale = activiteGravityScale;
    }
    void Movement()
    {
        moveDir = new Vector2(Input.GetAxis("Horizontal") * speed, rb2d.velocity.y);
        rb2d.velocity = moveDir;
    }
    void GroundCheck()
    {
        isGrounded = Physics2D.BoxCast(transform.position, new Vector2(0.4f, 0.4f), 0f, -transform.up, 1f, ground);
    }
}
