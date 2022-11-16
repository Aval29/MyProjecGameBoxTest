using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WoodItem : MonoBehaviour , IDragHandler, IBeginDragHandler, IEndDragHandler
{
    /// <summary>
    /// позиция обьекта
    /// </summary>
    private RectTransform _rectTransform;
    /// <summary>
    /// холст на котором находится объект
    /// </summary>
    private Canvas _mainCanvas;
    private CanvasGroup _canvasGroup;

    // Start is called before the first frame update
    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _mainCanvas = GetComponentInParent<Canvas>();
    }





    public void OnBeginDrag(PointerEventData eventData)
    {
        // throw new System.NotImplementedException();
        var slotTransform = _rectTransform.parent; // Transform родителя
        slotTransform.SetAsLastSibling(); // в конец списка родителя
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.blocksRaycasts = false; // простел сквозь текушей canvasGroup
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += (eventData.delta / _mainCanvas.scaleFactor);
        

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //  throw new System.NotImplementedException();
        transform.localPosition = Vector3.zero;
        _canvasGroup.blocksRaycasts = true;
        var rotationObjZ = transform.gameObject.GetComponent<RectTransform>().rotation.z;
        rotationObjZ = 0;

    }





    // Update is called once per frame
   // void Update()
    
}
