using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public float rotationSpeed = 90f;
    public bool isColliding = false;
    public Sprite sprite, sprite1;
    void Update()
    {
        if (isColliding)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite1;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isColliding = true;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        isColliding = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        isColliding = false;
    }
}
