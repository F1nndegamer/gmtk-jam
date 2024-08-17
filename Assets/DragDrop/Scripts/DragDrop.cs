using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class DragDrop : MonoBehaviour
{
    private bool _isDragging = false;
    private void Update()
    {
        if (!_isDragging) return;
        transform.position = GetFixedPos();
    }
    private void OnMouseDown()
    => _isDragging = true;
    private void OnMouseUp()
    => _isDragging = false;
    private Vector3 GetFixedPos()
    {
        Vector3 cameraPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return new Vector3(cameraPos.x, cameraPos.y, transform.position.z);
    }
}