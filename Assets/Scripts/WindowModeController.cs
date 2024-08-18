using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowModeController : MonoBehaviour
{
    private enum GrapOrSize { SizeMode, GrapMode }
    [SerializeField] private GrapOrSize mode;

    WindowResizer windowResizer;
    DragAndDrop dragAndDrop;
    // Start is called before the first frame update
    void Start()
    {
        windowResizer = GetComponent<WindowResizer>();
        dragAndDrop = GetComponent<DragAndDrop>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) ChangeMode();
        if (mode == GrapOrSize.SizeMode)
            windowResizer.SizerFunc();
        if (mode == GrapOrSize.GrapMode)
            dragAndDrop.GraperFunc();
    }
    public void ChangeMode()
    {   
        if (mode == GrapOrSize.SizeMode)
        {
            mode = GrapOrSize.GrapMode;
            CursorManager.Instance.ChangeCursor(CursorType.Hand_Open);
        }
        else
        {
            mode = GrapOrSize.SizeMode;
            CursorManager.Instance.ChangeCursor(CursorType.Default);
        }
    }
}
