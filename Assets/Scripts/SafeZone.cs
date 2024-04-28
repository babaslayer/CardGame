using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SafeZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        DragDrop3 d = eventData.pointerDrag.GetComponent<DragDrop3>();
        if(d != null)
        {
            d.placeholderParent = this.transform;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        DragDrop3 d = eventData.pointerDrag.GetComponent<DragDrop3>();
        if(d != null && d.placeholderParent == this.transform){
            d.placeholderParent = d.parentToReturnTo;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {

        DragDrop3 d = eventData.pointerDrag.GetComponent<DragDrop3>();
        if(d != null)
        {
            d.parentToReturnTo = this.transform;
        }
    }

}
