using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class DragAndDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 distanceFromPosToMousePos;
    private Collider2D coll;
    private void Awake()
    {
        coll = GetComponent<Collider2D>();
    }

    public void GraperFunc()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = GetMouseWorldPosition();
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.collider == coll)
            {
                SoundManager.Instance.PlayClickSound();
                isDragging = true;
                distanceFromPosToMousePos = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        if (Input.GetMouseButton(0) && isDragging)
        {
            transform.position = GetFixedPos();
        }
        if (Input.GetMouseButtonUp(0))
        {
            SoundManager.Instance.PlayReleaseSound();
            isDragging = false;
        }
    }
    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);
        return Camera.main.ScreenToWorldPoint(mouseScreenPosition);
    }
    private Vector3 GetFixedPos()
    {
        Vector3 cameraPos = distanceFromPosToMousePos + Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return new Vector3(cameraPos.x, cameraPos.y, transform.position.z);
    }
}