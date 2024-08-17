using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BorderCollider : MonoBehaviour
{
    private const string BORDER = "Border";
    private Collider2D coll;
    private void Awake()
    {
        coll = GetComponent<Collider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit");
        if (collision.collider.CompareTag(BORDER))
        {
            coll.isTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(BORDER))
        {
            coll.isTrigger = false;
        }
    }
}
