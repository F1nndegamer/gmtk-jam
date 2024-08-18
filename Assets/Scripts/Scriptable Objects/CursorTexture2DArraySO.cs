using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CursorType { Default, Diagonal, DiagonalMirror, Horizontal, Vertical, Hand_Open, Hand_Closed }

public class CursorTexture2DArraySO : ScriptableObject
{
    public Texture2D[] cursorTextureArray;
    public Texture2D GetTexture(CursorType cursorType)
    {
        return cursorTextureArray[(int)cursorType];
    }
}
