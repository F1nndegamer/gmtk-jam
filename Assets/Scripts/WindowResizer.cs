using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowResizer : MonoBehaviour
{
    private Vector3 originalMousePosition;
    private Vector3 originalScale;
    private Vector3 originalWindowPosition;
    private bool resizing;

    private enum ResizeDirection { None, Left, Right, Top, Bottom, TopLeft, TopRight, BottomLeft, BottomRight }
    private ResizeDirection resizeDirection = ResizeDirection.None;

    public BoxCollider2D topLeftCollider, topRightCollider, bottomLeftCollider, bottomRightCollider;
    public BoxCollider2D leftCollider, rightCollider, topCollider, bottomCollider;

    public float maxWidth = 10f;  // Maximum width of the window
    public float maxHeight = 10f; // Maximum height of the window
    public float minWidth = 2f;  // Minimum width of the window
    public float minHeight = 2f; // Minimum height of the window

    public void SizerFunc()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = GetMouseWorldPosition();
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

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
                resizing = true;
                originalMousePosition = mousePosition;
                originalScale = transform.localScale;
                originalWindowPosition = transform.position;
            }
        }

        if (Input.GetMouseButton(0) && resizing)
        {
            Vector3 currentMousePosition = GetMouseWorldPosition();
            Vector3 delta = currentMousePosition - originalMousePosition;

            ResizeWindow(delta);
        }

        if (Input.GetMouseButtonUp(0))
        {
            resizing = false;
            resizeDirection = ResizeDirection.None;
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);
        return Camera.main.ScreenToWorldPoint(mouseScreenPosition);
    }

    private void ResizeWindow(Vector3 delta)
    {
        Vector3 newScale = originalScale;
        Vector3 newPosition = originalWindowPosition;

        switch (resizeDirection)
        {
            case ResizeDirection.Left:
                newScale.x = Mathf.Clamp(originalScale.x - delta.x, minWidth, maxWidth);
                newPosition.x = originalWindowPosition.x + (originalScale.x - newScale.x) / 2;
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
                newPosition.y = originalWindowPosition.y + (originalScale.y - newScale.y) / 2;
                break;
            case ResizeDirection.TopLeft:
                newScale.x = Mathf.Clamp(originalScale.x - delta.x, minWidth, maxWidth);
                newScale.y = Mathf.Clamp(originalScale.y + delta.y, minHeight, maxHeight);
                newPosition.x = originalWindowPosition.x + (originalScale.x - newScale.x) / 2;
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
                newPosition.x = originalWindowPosition.x + (originalScale.x - newScale.x) / 2;
                newPosition.y = originalWindowPosition.y + (originalScale.y - newScale.y) / 2;
                break;
            case ResizeDirection.BottomRight:
                newScale.x = Mathf.Clamp(originalScale.x + delta.x, minWidth, maxWidth);
                newScale.y = Mathf.Clamp(originalScale.y - delta.y, minHeight, maxHeight);
                newPosition.x = originalWindowPosition.x + delta.x / 2;
                newPosition.y = originalWindowPosition.y + (originalScale.y - newScale.y) / 2;
                break;
        }

        transform.localScale = newScale;
        transform.position = newPosition;
    }
}
