using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public static CursorManager Instance;
    private CursorType cursorType;
    private Vector2 cursorHotspot;
    private WindowResizer currentWindow;
    
    [SerializeField] private CursorTexture2DArraySO cursorArraySO;

    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        Vector3 mousePosition = GetMouseWorldPosition();
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        if (hit && hit.collider.CompareTag("Window"))
        {
            currentWindow = hit.collider.GetComponent<WindowResizer>();
        }
    }
    
    public WindowResizer GetWindowResizer()
    {
        return currentWindow;
    }
    public Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);
        return Camera.main.ScreenToWorldPoint(mouseScreenPosition);
    }
    public void ChangeCursor(CursorType cursorType)
    {
        if (this.cursorType != cursorType)
        {
            this.cursorType = cursorType;
            if (cursorType == CursorType.Default)
            {
                cursorHotspot = new Vector2(0.3f, 0.83f);
            }
            else
            {
                cursorHotspot = new Vector2(cursorArraySO.GetTexture(cursorType).width/2, cursorArraySO.GetTexture(cursorType).height/2);
            }
            Cursor.SetCursor(cursorArraySO.GetTexture(cursorType), cursorHotspot, CursorMode.ForceSoftware);
        }
    }
}
