using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovingPlatform : MonoBehaviour, IVisibilityCheck
{
    [SerializeField] private float speed;
    [SerializeField] private Vector2 direction;
    private Rigidbody2D rb2D;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    public void Activate()
    {
        rb2D.velocity = direction * speed;
        Debug.Log("up");
    }

    public void Deactivate()
    {
        rb2D.velocity = -direction * speed;
        Debug.Log("down");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            collision.gameObject.GetComponent<PlayerMovement>().environmentVelocity = rb2D.velocity;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
           collision.gameObject.GetComponent<PlayerMovement>().environmentVelocity = rb2D.velocity;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            collision.gameObject.GetComponent<PlayerMovement>().environmentVelocity = Vector2.zero;
    }
}
