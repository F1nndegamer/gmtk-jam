using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public float rotationSpeed = 90f;
    public bool isColliding = false;
    void Update()
    {
        if (isColliding)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
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
