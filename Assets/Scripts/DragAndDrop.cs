using System;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class DragAndDrop : MonoBehaviour
{
    public event EventHandler OnCursorClicked;
    public event EventHandler OnCursorReleased;

   
}