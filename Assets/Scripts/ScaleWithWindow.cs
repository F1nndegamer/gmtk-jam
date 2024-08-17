using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleWithWindow : MonoBehaviour
{
    [SerializeField] private GameObject MaskWindow;
    [SerializeField] float scaleSpeed = 0.5f;
    private Vector3 initialScale;
    private Vector3 initialMaskScale;

    private void Start()
    {
        initialScale = transform.localScale;
        initialMaskScale = MaskWindow.transform.localScale;
    }

    private void Update()
    {
        Vector3 scaleDifference = MaskWindow.transform.localScale - initialMaskScale;
        Vector3 scaledDifference = scaleDifference * scaleSpeed;
        Vector3 newScale = initialScale + scaledDifference;
        float uniformScale = Mathf.Max(newScale.x, newScale.y);
        transform.localScale = new Vector3(uniformScale, uniformScale, transform.localScale.z);
        if (transform.localScale.x < 0.2f && transform.localScale.y < 0.2f)
        {
            Destroy(gameObject);
        }
    }
}
