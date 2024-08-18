using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MachineAndKey : MonoBehaviour
{
    public List<KeyController> controllerList;
    public GameObject machineObject;
    public int openSpeed;
    bool allTrue = false;
    private void Start()
    {
        KeyController[] Keys = GetComponentsInChildren<KeyController>();
        foreach (KeyController item in Keys)
        {
            controllerList.Add(item);
        }
    }
    private void Update()
    {
        allTrue = controllerList.All(x => x.isColliding);
        Debug.Log(allTrue);
        if (allTrue)
        {
            machineObject.GetComponent<BoxCollider2D>().enabled = false;
            machineObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            machineObject.GetComponent<BoxCollider2D>().enabled = true;
            machineObject.GetComponent<SpriteRenderer>().enabled = true;
        }

    }
    //public float rotationSpeed = 90f;
    //private bool isColliding = false;
    //public GameObject mech;
    //void Update()
    //{
    //    if (isColliding)
    //    {
    //        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    //        mech.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5);
    //    }
    //    else
    //    {
    //        mech.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);
    //    }
    //}

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    isColliding = true;
    //}
    //private void OnTriggerStay2D(Collider2D other)
    //{
    //    isColliding = true;
    //}
    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    isColliding = false;
    //}
}
