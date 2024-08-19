using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class WindowBehavior : MonoBehaviour
{
    public event EventHandler OnCursorClicked;
    public event EventHandler OnCursorReleased;

    private Vector3 originalMousePosition;
    private Vector3 originalScale;
    private Vector3 originalWindowPosition;
    private Vector3 distanceFromPosToMousePos;

    public enum ResizeDirection { None, Left, Right, Top, Bottom, TopLeft, TopRight, BottomLeft, BottomRight }
    private ResizeDirection resizeDirection = ResizeDirection.None;
    [SerializeField] private LayerMask cursorDetectLayer;
    [SerializeField] private BoxCollider2D windowCollider;
    [SerializeField] private BoxCollider2D topLeftCollider, topRightCollider, bottomLeftCollider, bottomRightCollider;
    [SerializeField] private BoxCollider2D leftCollider, rightCollider, topCollider, bottomCollider;

    [SerializeField] private float maxWidth = 10f;  // Maximum width of the window
    [SerializeField] private float maxHeight = 10f; // Maximum height of the window
    [SerializeField] private float minWidth = 2f;  // Minimum width of the window
    [SerializeField] private float minHeight = 2f; // Minimum height of the window
    private Vector3 mousePosition;
    public bool IsResizingOrDraging;
    public bool IsHoveringOnResize;
    public bool IsHoveringOnDrag;
    private void Update()
    {
        mousePosition = CursorManager.Instance.GetMouseWorldPosition();

        if (IsHoveringOnDrag)
        {
            GraperFunc();
        }
        if (IsHoveringOnResize)
        {
            SizerFunc();
        }
    }
    public void GraperFunc()
    {
        if (Input.GetMouseButton(0) && CursorManager.Instance.IsDragging)
        {
            transform.position = GetPosInRelationWithMousePos();
        }
        if (Input.GetMouseButtonUp(0) && CursorManager.Instance.IsDragging)
        {
            OnCursorReleased?.Invoke(this, EventArgs.Empty);

            CursorManager.Instance.ChangeCursor(CursorType.Hand_Open);
            CursorManager.Instance.IsDragging = false;
        }
    }
    public void OnDragClick()
    {
        OnCursorClicked?.Invoke(this, EventArgs.Empty);
        CursorManager.Instance.ChangeCursor(CursorType.Hand_Closed);
        CursorManager.Instance.IsDragging = true;
        distanceFromPosToMousePos = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private Vector3 GetPosInRelationWithMousePos()
    {
        Vector3 cameraPos = distanceFromPosToMousePos + Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return new Vector3(cameraPos.x, cameraPos.y, transform.position.z);
    }
    public void SizerFunc()
    {
        if (Input.GetMouseButton(0) && CursorManager.Instance.IsResizing)
        {
            Vector3 currentMousePosition = CursorManager.Instance.GetMouseWorldPosition();
            Vector3 delta = currentMousePosition - originalMousePosition;

            ResizeWindow(delta);
        }

        if (Input.GetMouseButtonUp(0) && CursorManager.Instance.IsResizing)
        {
            OnCursorReleased?.Invoke(this, EventArgs.Empty);

            CursorManager.Instance.IsResizing = false;
            resizeDirection = ResizeDirection.None;
        }
    }
    public void OnResizeClick(ResizeDirection resizeDirection)
    {
        OnCursorClicked?.Invoke(this, EventArgs.Empty);
        CursorManager.Instance.IsResizing = true;
        originalMousePosition = mousePosition;
        originalScale = transform.localScale;
        originalWindowPosition = transform.position;
        this.resizeDirection = resizeDirection;
    }

    public void ResizeWindow(Vector3 delta)
    {
        Vector3 newScale = originalScale;
        Vector3 newPosition = originalWindowPosition;

        switch (resizeDirection)
        {
            case ResizeDirection.Left:
                newScale.x = Mathf.Clamp(originalScale.x - delta.x, minWidth, maxWidth);
                newPosition.x = originalWindowPosition.x + delta.x / 2;
                break;
            case ResizeDirection.Right:
                newScale.x = Mathf.Clamp(originalScale.x + delta.x, minWidth, maxWidth);
                newPosition.x = originalWindowPosition.x + delta.x / 2;
                break;
            case ResizeDirection.Top:
                newScale.y = Mathf.Clamp(originalScale.y + delta.y, minHeight, maxHeight);
                newPosition.y = originalWindowPosition.y + delta.y / 2;
                break;
            case ResizeDirection.Bottom:
                newScale.y = Mathf.Clamp(originalScale.y - delta.y, minHeight, maxHeight);
                newPosition.y = originalWindowPosition.y + delta.y / 2;
                break;
            case ResizeDirection.TopLeft:
                newScale.x = Mathf.Clamp(originalScale.x - delta.x, minWidth, maxWidth);
                newScale.y = Mathf.Clamp(originalScale.y + delta.y, minHeight, maxHeight);
                newPosition.x = originalWindowPosition.x + delta.x / 2;
                newPosition.y = originalWindowPosition.y + delta.y / 2;
                break;
            case ResizeDirection.TopRight:
                newScale.x = Mathf.Clamp(originalScale.x + delta.x, minWidth, maxWidth);
                newScale.y = Mathf.Clamp(originalScale.y + delta.y, minHeight, maxHeight);
                newPosition.x = originalWindowPosition.x + delta.x / 2;
                newPosition.y = originalWindowPosition.y + delta.y / 2;
                break;
            case ResizeDirection.BottomLeft:
                newScale.x = Mathf.Clamp(originalScale.x - delta.x, minWidth, maxWidth);
                newScale.y = Mathf.Clamp(originalScale.y - delta.y, minHeight, maxHeight);
                newPosition.x = originalWindowPosition.x + delta.x / 2;
                newPosition.y = originalWindowPosition.y + delta.y / 2;
                break;
            case ResizeDirection.BottomRight:
                newScale.x = Mathf.Clamp(originalScale.x + delta.x, minWidth, maxWidth);
                newScale.y = Mathf.Clamp(originalScale.y - delta.y, minHeight, maxHeight);
                newPosition.x = originalWindowPosition.x + delta.x / 2;
                newPosition.y = originalWindowPosition.y + delta.y / 2;
                break;
        }
        transform.localScale = newScale;
        transform.position = newPosition;
    }
}
