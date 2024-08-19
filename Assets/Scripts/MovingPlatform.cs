using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour, IVisibilityCheck
{
    [SerializeField] private float speed;
    [SerializeField] private Vector2 direction;
    [SerializeField] private Transform stopTransform; // The transform where the platform should stop
    private Rigidbody2D rb2D;
    private bool isActive = false;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void Activate()
    {
        isActive = true;
        rb2D.velocity = direction.normalized * speed;
        Debug.Log("up");
    }

    public void Deactivate()
    {
        isActive = false;
        rb2D.velocity = Vector2.zero;
        Debug.Log("down");
    }

    private void FixedUpdate()
    {
        if (isActive && HasReachedStopPosition())
        {
            rb2D.velocity = Vector2.zero;
            isActive = false;
            Debug.Log("Platform stopped");
        }
    }

    private bool HasReachedStopPosition()
    {
        Vector2 currentPosition = transform.position;
        Vector2 targetPosition = stopTransform.position;

        if (direction.x != 0)
        {
            return (direction.x > 0 && currentPosition.x >= targetPosition.x) ||
                   (direction.x < 0 && currentPosition.x <= targetPosition.x);
        }
        else if (direction.y != 0)
        {
            return (direction.y > 0 && currentPosition.y >= targetPosition.y) ||
                   (direction.y < 0 && currentPosition.y <= targetPosition.y);
        }
        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            collision.gameObject.GetComponent<PlayerMovement>().SetEnvironmentVelocity(rb2D.velocity);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            collision.gameObject.GetComponent<PlayerMovement>().SetEnvironmentVelocity(rb2D.velocity);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            collision.gameObject.GetComponent<PlayerMovement>().SetEnvironmentVelocity(Vector2.zero);
    }
}
