using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public static CursorManager Instance;
    public enum CursorType { Default, Diagonal, DiagonalMirror, Horizontal, Vertical }
    private CursorType cursorType;
    private Vector2 cursorHotspot;
    [SerializeField] private Texture2D[] cursorArray;

    private void Awake()
    {
        Instance = this;
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
                cursorHotspot = new Vector2(cursorArray[(int)cursorType].width/2, cursorArray[(int)cursorType].height/2);
            }
            Cursor.SetCursor(cursorArray[(int)cursorType], cursorHotspot, CursorMode.ForceSoftware);
        }
    }
}
