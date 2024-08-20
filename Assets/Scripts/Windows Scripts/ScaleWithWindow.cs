using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleWithWindow : MonoBehaviour
{
    private enum ScaleMode { Uniform, Independant }
    private enum IndependantAxis { BothAxis, X, Y }
    [SerializeField] private GameObject MaskWindow;
    [SerializeField] float scaleSpeed = 0.5f;
    [SerializeField] ScaleMode scaleMode = ScaleMode.Uniform;
    [SerializeField] IndependantAxis scalingAxis = IndependantAxis.BothAxis;
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
        switch (scaleMode)
        {
            case ScaleMode.Uniform:
                //float uniformScale = Mathf.Max(newScale.x, newScale.y);
                transform.localScale = new Vector3(newScale.x, newScale.y, transform.localScale.z);
                break;
            case ScaleMode.Independant:
                switch (scalingAxis)
                {
                    case IndependantAxis.BothAxis:
                        transform.localScale = new Vector3(newScale.x, newScale.y, transform.localScale.z);
                        break;
                    case IndependantAxis.X:
                        transform.localScale = new Vector3(newScale.x, transform.localScale.y, transform.localScale.z);
                        break;
                    case IndependantAxis.Y:
                        transform.localScale = new Vector3(transform.localScale.x, newScale.y, transform.localScale.z);
                        break;
                }
                break;
        }

        /*
        if (transform.localScale.x < 0.2f && transform.localScale.y < 0.2f)
        {
            Destroy(gameObject);
        }
        */
    }
}
