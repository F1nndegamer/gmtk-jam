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
}
