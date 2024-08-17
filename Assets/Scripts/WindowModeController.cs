using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowModeController : MonoBehaviour
{
    enum GrapOrSize { SizeMode, GrapMode }
    [SerializeField] GrapOrSize mode;
    public GameObject MaskWindow;
    WindowResizer windowResizer;
    DragAndDrop dragAndDrop;
    // Start is called before the first frame update
    void Start()
    {
        windowResizer = MaskWindow.GetComponent<WindowResizer>();
        dragAndDrop = MaskWindow.GetComponent<DragAndDrop>();
    }

    // Update is called once per frame
    void Update()
    {
        ModeChanger();
        if (mode == GrapOrSize.SizeMode)
            windowResizer.SizerFunc();
        if (mode == GrapOrSize.GrapMode)
            dragAndDrop.GraperFunc();
    }
    void ModeChanger()
    {
        if (Input.GetKeyDown(KeyCode.F))
            if (mode == GrapOrSize.SizeMode)
                mode = GrapOrSize.GrapMode;
            else
                mode = GrapOrSize.SizeMode;

    }
}
