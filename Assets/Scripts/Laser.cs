using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform laserPoint;
    LineRenderer lineRenderer;
    Trap trap;
    public GameObject player;
    public LayerMask layerMask;
    public LayerMask layerMask1;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        trap = GetComponent<Trap>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.Raycast(transform.position, -transform.up, 100, layerMask1))
        {
            trap.Death(Physics2D.Raycast(transform.position, -transform.up, 100, layerMask1).transform.gameObject);
        }
        if (Physics2D.Raycast(transform.position, -transform.up, 100, layerMask))
        {
            RaycastHit2D _hit = Physics2D.Raycast(laserPoint.position, -transform.up, 100, layerMask);
            Draw2DRay(laserPoint.position, _hit.point);
        }
        else
        {
            Draw2DRay(laserPoint.position, -laserPoint.transform.up * 100);
        }
    }
    void Draw2DRay(Vector2 startPoint, Vector2 endPoint)
    {
        lineRenderer.SetPosition(0, startPoint);
        lineRenderer.SetPosition(1, endPoint);
    }
}
