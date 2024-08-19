using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    public event EventHandler OnCursorClicked;
    public event EventHandler OnCursorReleased;

    private Vector3 originalMousePosition;
    private Vector3 originalScale;
    private Vector3 originalWindowPosition;
    private Vector3 distanceFromPosToMousePos;
    private bool isResizing = false;
    private bool isDragging = false;
    private Collider2D windowColl;
    public enum ResizeDirection { None, Left, Right, Top, Bottom, TopLeft, TopRight, BottomLeft, BottomRight }
    private ResizeDirection resizeDirection = ResizeDirection.None;
    [SerializeField] private BoxCollider2D windowCollider;
    [SerializeField] private BoxCollider2D topLeftCollider, topRightCollider, bottomLeftCollider, bottomRightCollider;
    [SerializeField] private BoxCollider2D leftCollider, rightCollider, topCollider, bottomCollider;

    [SerializeField] private float maxWidth = 10f;  // Maximum width of the window
    [SerializeField] private float maxHeight = 10f; // Maximum height of the window
    [SerializeField] private float minWidth = 2f;  // Minimum width of the window
    [SerializeField] private float minHeight = 2f; // Minimum height of the window
    private Vector3 mousePosition;
    private RaycastHit2D hit;
    private void Update()
    {
        
        if (!CursorManager.Instance.GetWindow() == this) return;

        mousePosition = CursorManager.Instance.GetMouseWorldPosition();
        hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        if (hit.collider == null)
        {
            CursorManager.Instance.ChangeCursor(CursorType.Default);
        }
        else if (hit.collider == windowColl && !isResizing)
        {
            GraperFunc();
        }
        else if (hit.collider.CompareTag("Border") && !isDragging)
        {
            SizerFunc();
        }
    }
    
    private void Awake()
    {
        windowColl = GetComponent<Collider2D>();
    }

    public void GraperFunc()
    {
        if (!isDragging && CursorManager.Instance.GetWindow() == this)
        {
            CursorManager.Instance.ChangeCursor(CursorType.Hand_Open);
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (hit.collider == windowColl)
            {
                OnCursorClicked?.Invoke(this, EventArgs.Empty);

                CursorManager.Instance.ChangeCursor(CursorType.Hand_Closed);
                isDragging = true;
                distanceFromPosToMousePos = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        if (Input.GetMouseButton(0) && isDragging)
        {
            transform.position = GetPosInRelationWithMousePos();
        }
        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            OnCursorReleased?.Invoke(this, EventArgs.Empty);

            CursorManager.Instance.ChangeCursor(CursorType.Hand_Open);
            isDragging = false;
        }
    }
    private Vector3 GetPosInRelationWithMousePos()
    {
        Vector3 cameraPos = distanceFromPosToMousePos + Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return new Vector3(cameraPos.x, cameraPos.y, transform.position.z);
    }
    public void SizerFunc()
    {
        if (!isResizing && CursorManager.Instance.GetWindow() == this)
        {
            if (hit.collider != null)
            {
                if (hit.collider == topLeftCollider || hit.collider == bottomRightCollider)
                {
                    CursorManager.Instance.ChangeCursor(CursorType.DiagonalMirror);
                }
                else if (hit.collider == topRightCollider || hit.collider == bottomLeftCollider)
                {
                    CursorManager.Instance.ChangeCursor(CursorType.Diagonal);
                }
                else if (hit.collider == leftCollider || hit.collider == rightCollider)
                {
                    CursorManager.Instance.ChangeCursor(CursorType.Horizontal);
                }
                else if (hit.collider == topCollider || hit.collider == bottomCollider)
                {
                    CursorManager.Instance.ChangeCursor(CursorType.Vertical);
                }
                else if (hit.collider == windowCollider)
                {
                    CursorManager.Instance.ChangeCursor(CursorType.Default);
                }
            }
            else
            {
                CursorManager.Instance.ChangeCursor(CursorType.Default);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (hit.collider != null)
            {
                if (hit.collider == topLeftCollider)
                {
                    resizeDirection = ResizeDirection.TopLeft;
                }
                else if (hit.collider == topRightCollider)
                {
                    resizeDirection = ResizeDirection.TopRight;
                }
                else if (hit.collider == bottomLeftCollider)
                {
                    resizeDirection = ResizeDirection.BottomLeft;
                }
                else if (hit.collider == bottomRightCollider)
                {
                    resizeDirection = ResizeDirection.BottomRight;
                }
                else if (hit.collider == leftCollider)
                {
                    resizeDirection = ResizeDirection.Left;
                }
                else if (hit.collider == rightCollider)
                {
                    resizeDirection = ResizeDirection.Right;
                }
                else if (hit.collider == topCollider)
                {
                    resizeDirection = ResizeDirection.Top;
                }
                else if (hit.collider == bottomCollider)
                {
                    resizeDirection = ResizeDirection.Bottom;
                }
            }

            if (resizeDirection != ResizeDirection.None)
            {
                OnCursorClicked?.Invoke(this, EventArgs.Empty);

                isResizing = true;
                originalMousePosition = mousePosition;
                originalScale = transform.localScale;
                originalWindowPosition = transform.position;
            }
        }

        if (Input.GetMouseButton(0) && isResizing && CursorManager.Instance.GetWindow() == this)
        {
            Vector3 currentMousePosition = CursorManager.Instance.GetMouseWorldPosition();
            Vector3 delta = currentMousePosition - originalMousePosition;

            ResizeWindow(delta);
        }

        if (Input.GetMouseButtonUp(0) && isResizing)
        {
            OnCursorReleased?.Invoke(this, EventArgs.Empty);

            isResizing = false;
            resizeDirection = ResizeDirection.None;
        }
    }

    private void ResizeWindow(Vector3 delta)
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
