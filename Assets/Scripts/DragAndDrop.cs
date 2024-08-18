using System;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class DragAndDrop : MonoBehaviour
{
    public event EventHandler OnCursorClicked;
    public event EventHandler OnCursorReleased;

    private bool isDragging = false;
    private Vector3 distanceFromPosToMousePos;
    private Collider2D coll;
    private void Awake()
    {
        coll = GetComponent<Collider2D>();
    }

    public void GraperFunc()
    {
        if(!isDragging && CursorManager.Instance.GetWindowResizer() == this)
        {
            CursorManager.Instance.ChangeCursor(CursorType.Hand_Open);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = CursorManager.Instance.GetMouseWorldPosition();
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.collider == coll)
            {
                OnCursorClicked?.Invoke(this, EventArgs.Empty);

                CursorManager.Instance.ChangeCursor(CursorType.Hand_Closed);
                isDragging = true;
                distanceFromPosToMousePos = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        if (Input.GetMouseButton(0) && isDragging)
        {
            transform.position = GetFixedPos();
        }
        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            OnCursorReleased?.Invoke(this, EventArgs.Empty);

            CursorManager.Instance.ChangeCursor(CursorType.Hand_Open);
            isDragging = false;
        }
    }
    private Vector3 GetFixedPos()
    {
        Vector3 cameraPos = distanceFromPosToMousePos + Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return new Vector3(cameraPos.x, cameraPos.y, transform.position.z);
    }
}