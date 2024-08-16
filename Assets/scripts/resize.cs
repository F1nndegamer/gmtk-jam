using UnityEngine;

public class SpriteMaskDrag : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    isDragging = true;
                    offset = transform.position - hit.point;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane plane = new Plane(Vector3.up, transform.position);
            float distance;
            if (plane.Raycast(ray, out distance))
            {
                Vector3 point = ray.GetPoint(distance);
                transform.position = point + offset;
            }
        }
    }
}
