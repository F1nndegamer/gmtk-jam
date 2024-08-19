using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class VisibilityMark : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 90f;
    [SerializeField] private GameObject[] linkedObjects;
    private IVisibilityCheck[] visibilityCheckArray;
    private bool isColliding = false;
    private void Awake()
    {
        visibilityCheckArray = new IVisibilityCheck[linkedObjects.Length];
        for (int i = 0; i < linkedObjects.Length; i++)
        {
            visibilityCheckArray[i] = linkedObjects[i].GetComponent<IVisibilityCheck>();
            if (visibilityCheckArray[i] == null)
            {
                Debug.LogError("Game Object does not implements IVisibilityCheck");
            }
        }
    }
    void Update()
    {
        if (isColliding)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
            foreach (var visibilityItem in visibilityCheckArray)
            {
                visibilityItem.Activate();
            }
        }
        else
        {
            foreach (var visibilityItem in visibilityCheckArray)
            {
                visibilityItem.Deactivate();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Window"))
        {
            isColliding = true;
            SoundManager.Instance.PlayTurnStart(transform);
            SoundManager.Instance.PlayTurning(transform);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Window"))
        {
            isColliding = true;
            SoundManager.Instance.turning = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Window"))
        {
            isColliding = false;
            SoundManager.Instance.PlayTurnStart(transform);
            SoundManager.Instance.turning = false;
        }
    }
}
