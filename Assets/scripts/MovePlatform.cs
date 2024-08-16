using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float speed;

    int direction = 1;
    private void Update()
    {
        Vector2 target = currentMovementTarger();

        transform.position = Vector2.Lerp(transform.position, target, speed * Time.deltaTime); //I will try to make this code more effective, I don't like it at the moment.

        Debug.Log(Vector2.Lerp(transform.position, target, speed * Time.deltaTime));

        float distance = (target - (Vector2)transform.position).magnitude;

        if (distance < speed)
            direction *= -1;
    }
    Vector2 currentMovementTarger()
    {
        if (direction == 1)
        {
            return startPoint.position;
        }
        else
        {
            return endPoint.position;
        }
    }
}
