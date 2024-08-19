using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowModeController : MonoBehaviour
{
    private enum GrapOrSize { SizeMode, GrapMode }
    [SerializeField] private GrapOrSize mode;

    WindowResizer windowResizer;

    // Start is called before the first frame update
    void Start()
    {
        windowResizer = GetComponent<WindowResizer>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
