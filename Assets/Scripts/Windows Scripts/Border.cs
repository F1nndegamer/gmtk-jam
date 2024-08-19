using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    [SerializeField] private WindowBehavior window;
    [SerializeField] private CursorType cursorType;
    [SerializeField] private WindowBehavior.ResizeDirection resizeDirection;

    private void OnMouseEnter()
    {
        if (CursorManager.Instance.IsDragging || CursorManager.Instance.IsResizing) return;
        CursorManager.Instance.ChangeCursor(cursorType);
        window.IsHoveringOnResize = true;
    }
    private void OnMouseExit()
    {
        if (CursorManager.Instance.IsDragging || CursorManager.Instance.IsResizing) return;
        window.IsHoveringOnResize = false;
    }
    private void OnMouseDown()
    {
        window.OnResizeClick(resizeDirection);
    }
}
