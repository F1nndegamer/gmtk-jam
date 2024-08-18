using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public static CursorManager Instance;
    public enum CursorType { Default, Diagonal, DiagonalMirror, Horizontal, Vertical }
    private CursorType cursorType;

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
            Cursor.SetCursor(cursorArray[(int)cursorType], Vector2.zero, CursorMode.ForceSoftware);
        }
    }
}
