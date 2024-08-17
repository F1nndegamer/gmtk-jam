using System.Collections;
using UnityEngine;

public class Key : MonoBehaviour
{
    private bool isPickedUp;
    public bool doormove;
    private Vector2 targetPosition;
    public Transform door;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Key"))
        {
            PickUpKey(collision.gameObject);
        }
        else if (collision.collider.CompareTag("Door") && isPickedUp)
        {
            UseKeyOnDoor(collision.transform);
        }
    }

    private void PickUpKey(GameObject key)
    {
        isPickedUp = true;
        Destroy(key);
        Debug.Log("Key picked up");
    }

    private void UseKeyOnDoor(Transform door)
    {
        doormove = true;
        targetPosition = new Vector2(door.position.x, door.position.y + 3f); // Set the target position for the door
         // Destroy the key after using it
    }

    private void Update()
    {
        if (doormove)
        {
            door.position = Vector2.MoveTowards(door.position, targetPosition, Time.deltaTime * 5f);
            if (Vector2.Distance(door.position, targetPosition) < 0.01f)
            {
                doormove = false;
            }
        }
    }

    private IEnumerator OpenDoor(Transform door)
    {
        targetPosition = new Vector2(door.position.x, door.position.y + 3f); // Move the door up by 3 units
        while (Vector2.Distance(door.position, targetPosition) > 0.01f)
        {
            door.position = Vector2.MoveTowards(door.position, targetPosition, Time.deltaTime * 5f);
            yield return null;
        }
    }
}
