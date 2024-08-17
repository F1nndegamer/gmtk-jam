using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class DragAndDrop : MonoBehaviour
{
    private bool _isDragging = false;
    private Vector3 distanceFromPosToMousePos;
    private Vector3 mousePos;
    public void GraperFunc()
    {
        if (!_isDragging) return;
        transform.position = GetFixedPos();
    }
    private void OnMouseDown()
    {
        _isDragging = true;
        distanceFromPosToMousePos = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void OnMouseUp()
    => _isDragging = false;
    private Vector3 GetFixedPos()
    {
        Vector3 cameraPos = distanceFromPosToMousePos + Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return new Vector3(cameraPos.x, cameraPos.y, transform.position.z);
    }
}