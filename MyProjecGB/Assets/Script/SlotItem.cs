using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class SlotItem : MonoBehaviour , IDropHandler 
{
    [SerializeField]
    GameObject _objSlot;

    public void OnDrop(PointerEventData eventData)
    {
        var otherItemTransorm = eventData.pointerDrag.transform;
        if (_objSlot != null)
        {
            if (_objSlot == otherItemTransorm.gameObject)
            {
                otherItemTransorm.SetParent(transform);
                otherItemTransorm.localPosition = Vector3.zero;
            }
        }
        else 
        {
            otherItemTransorm.SetParent(transform);
            otherItemTransorm.localPosition = Vector3.zero;
        }
    }


   
}
