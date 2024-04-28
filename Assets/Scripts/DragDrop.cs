using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler,IDragHandler, IEndDragHandler
{
    //Vector2 relativeStartPosition;
    Transform parentToReturnTo = null;
    Vector2 startPosition;

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = transform.position;
        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
        //relativeStartPosition = this.transform.position - Input.mousePosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
        //this.transform.position = eventData.position + relativeStartPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(parentToReturnTo);

        //var myPos = parentToReturnTo.position;
        //myPos.y -= 30f;
        //parentToReturnTo.position = myPos;

        this.transform.position = startPosition;
    }

}
