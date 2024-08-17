using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderCollider : MonoBehaviour
{
    private const string PLAYER = "Player";
    private Collider2D coll;
    private void Awake()
    {
        coll = GetComponent<Collider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit");
        if (collision.collider.CompareTag(PLAYER))
        {
            coll.isTrigger = true;
            Debug.Log("true" + name);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(PLAYER))
        {
            coll.isTrigger = false;
            Debug.Log("false" + name);
        }
    }
}
