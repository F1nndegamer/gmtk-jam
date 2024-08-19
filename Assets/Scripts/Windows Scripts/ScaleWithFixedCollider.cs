using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleWithFixedCollider : MonoBehaviour
{
    private Vector2 originalColliderSize;
    private Vector2 originalColliderOffset;
    private Vector3 originalScale;
    [SerializeField] private Transform originalWindowTransform;

    private BoxCollider2D boxCollider;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();

        if (boxCollider != null)
        {
            originalColliderSize = boxCollider.size;
            originalColliderOffset = boxCollider.offset;
        }

        originalScale = originalWindowTransform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (boxCollider != null)
        {
            boxCollider.size = new Vector2(originalColliderSize.x / originalWindowTransform.localScale.x * originalScale.x,
                                           originalColliderSize.y / originalWindowTransform.localScale.y * originalScale.y);
            boxCollider.offset = new Vector2(originalColliderOffset.x / originalWindowTransform.localScale.x * originalScale.x,
                                             originalColliderOffset.y / originalWindowTransform.localScale.y * originalScale.y);
        }
    }
}
