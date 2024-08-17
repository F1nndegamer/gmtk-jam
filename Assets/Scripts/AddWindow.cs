using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddWindow : MonoBehaviour
{
    public GameObject MaskWindow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            Instantiate(MaskWindow, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
    }
}
