using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop2 : MonoBehaviour 
{
    public GameObject Canvas;
    public GameObject SafeZone;

    private bool isDragging = false;

    void Start()
    {
        Canvas = GameObject.Find("Main Canvas");
        SafeZone = GameObject.Find("SafeZone");
    }

    public void StartDrag()
    {
        isDragging = true;
    }

    public void EndDrag()
    {
        isDragging = false;
    }

    void Update()
    {
        if (isDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(Canvas.transform, true);
        }
    }
}
