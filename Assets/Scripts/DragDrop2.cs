using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop2 : MonoBehaviour 
{
    public GameObject Canvas;
    public GameObject SafeZone;
    public GameObject ArenaSafeZone;

    private bool isDragging = false;
    private GameObject startParent;
    private Vector2 startPosition;
    private GameObject safeZone;
    private bool isOverSafeZone;

    void Start()
    {
        Canvas = GameObject.Find("Main Canvas");
        SafeZone = GameObject.Find("SafeZone");
        ArenaSafeZone = GameObject.Find("ArenaSafeZone");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOverSafeZone = true;
        safeZone = collision.gameObject;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOverSafeZone = false;
        safeZone = null;
    }

    public void StartDrag()
    {
        isDragging = true;
        startParent = transform.parent.gameObject;
        startPosition = transform.position;
    }

    public void EndDrag()
    {
        isDragging = false;
        if (isOverSafeZone)
        {
            transform.SetParent(safeZone.transform, false);
        }
        else
        {
            transform.position = startPosition;
            transform.SetParent(startParent.transform, false);
        }
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
