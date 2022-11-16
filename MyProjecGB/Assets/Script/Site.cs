using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Site : MonoBehaviour , IDropHandler 
{
    [SerializeField]
    GameObject _objWood;

    [SerializeField]
    GameObject  _objAxe ;

    [SerializeField]
    GameObject _objSlotWood;

    [SerializeField]
    private Transform _SlotSite ;

    public void OnDrop(PointerEventData eventData)
    {
        var otherItemTransorm = eventData.pointerDrag.transform;

            if ( transform.gameObject.GetComponent<Transform>().childCount == 0) //_objWood == otherItemTransorm.gameObject &&
        {
            _SlotSite = eventData.pointerDrag.transform;
                otherItemTransorm.SetParent(transform);
                otherItemTransorm.localPosition = Vector3.zero;
 
            otherItemTransorm.transform.gameObject.GetComponent<RectTransform>().rotation = Quaternion.Euler (0f, 0f, -90f); 

            }
     
  
            if (_SlotSite != null && otherItemTransorm.gameObject == _objAxe)
            //(transform.gameObject.GetComponent<Transform>().childCount != 0 && otherItemTransorm.gameObject == _objAxe)
            {
            //var wood = transform.GetChild(0).gameObject.transform;
            
            _SlotSite.transform.position = _objSlotWood.transform.position; ;
            _SlotSite.rotation = Quaternion.Euler(0f, 0f, 0f);
            _SlotSite.transform.SetParent(_objSlotWood.transform);
            _SlotSite = null ;
            EventWorld.wood -= 1;
            EventWorld.fireWood += 5;

            }
           // otherItemTransorm.SetParent(transform);
           // otherItemTransorm.localPosition = Vector3.zero;
  
    }


   
}
