using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDetect : MonoBehaviour
{
    [SerializeField] private WindowBehavior window;
    [SerializeField] private CursorType cursorType;

    private void OnMouseEnter()
    {
        if (CursorManager.Instance.IsDragging || CursorManager.Instance.IsResizing) return;
        CursorManager.Instance.ChangeCursor(CursorType.Hand_Open);
        window.IsHoveringOnDrag = true;
    }
    private void OnMouseExit()
    {
        if (CursorManager.Instance.IsDragging || CursorManager.Instance.IsResizing) return;
        window.IsHoveringOnDrag = false;
    }
    private void OnMouseDown()
    {
        window.OnDragClick();
    }
}
