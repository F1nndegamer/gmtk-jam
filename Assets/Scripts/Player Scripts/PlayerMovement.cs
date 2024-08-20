using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpForce = 12;
    [SerializeField] private LayerMask ground;
    [SerializeField] private LayerMask trapTarget;

    private Vector2 environmentVelocity;
    private bool isGrounded; 
    private Rigidbody2D rb2d;
    private Vector2 moveDir;
    private float horizontal;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        LevelManagement.Instance.OnVictory += StopMovement;
    }
    private void StopMovement()
    {
        Debug.Log("stopmovement");
        horizontal = 0;
        moveDir = Vector2.zero;
        rb2d.velocity = Vector2.zero;
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
        {
            rb2d.AddForce(new Vector2(rb2d.velocity.x, jumpForce), ForceMode2D.Impulse);
        }
        if (rb2d.velocity.y < 0)
            rb2d.gravityScale = 1.5f * 3f;
        else
            rb2d.gravityScale = 3f;
    }
    void Movement()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        moveDir = new Vector2(horizontal * speed, rb2d.velocity.y);
        rb2d.velocity = moveDir + environmentVelocity;
        if (Mathf.Abs(moveDir.x) > 0.01f)
        {
            transform.rotation = Quaternion.Euler(0, horizontal > 0 ? 0 : 180, 0);
        }
    }
    void GroundCheck()
    {
        isGrounded = Physics2D.BoxCast(transform.position, new Vector2(1f, 1f), 0f, -transform.up, 1f, ground);
    }
    public bool IsWalking()
    {
        return Mathf.Abs(moveDir.x) > 0.01f && isGrounded;
    }
    public bool IsJumping()
    {
        return !isGrounded;
    }

    public void SetEnvironmentVelocity(Vector2 velocity)
    {
        environmentVelocity = velocity;
    }
}
