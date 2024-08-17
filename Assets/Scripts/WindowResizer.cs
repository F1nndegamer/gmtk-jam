using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class WindowResizer : MonoBehaviour
{
    enum GraporSize { Size, Grap};
    private Vector3 originalMousePosition;
    private Vector3 originalPosition;
    private Vector3 originalScale;
    private float xScaleMultiplier;
    private float yScaleMultiplier;
    public void SizerFunc()
    {
        if (Input.GetMouseButtonDown(0))
        {
            InitializeResizeWindow();
        }
        if (Input.GetMouseButton(0))
        {
            ResizeWindow();
        }
    }
    private void InitializeResizeWindow()
    {
        originalMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        originalPosition = transform.position;
        originalScale = transform.localScale;
        Vector2 delta = originalMousePosition - originalPosition;

        if (delta.x > 0 && delta.y > 0) { xScaleMultiplier = 1; yScaleMultiplier = 1; } //Cursor starts at top right corner
        if (delta.x > 0 && delta.y < 0) { xScaleMultiplier = 1; yScaleMultiplier = -1; } //Cursor starts at bottom right corner
        if (delta.x < 0 && delta.y > 0) { xScaleMultiplier = -1; yScaleMultiplier = 1; } //Cursor starts at top left corner
        if (delta.x < 0 && delta.y < 0) { xScaleMultiplier = -1; yScaleMultiplier = -1; } //Cursor starts at bottom left corner
    }
    private void ResizeWindow()
    {
        Vector3 mousePositionDelta = Camera.main.ScreenToWorldPoint(Input.mousePosition) - originalMousePosition;
        transform.position = originalPosition + mousePositionDelta / 2;
        if (mousePositionDelta.magnitude > 0.1)
        {
            transform.localScale = new Vector3(originalScale.x + mousePositionDelta.x * xScaleMultiplier, originalScale.y + mousePositionDelta.y * yScaleMultiplier, 1);
        }
    }
}
