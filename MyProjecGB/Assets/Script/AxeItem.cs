using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AxeItem : MonoBehaviour , IDragHandler, IBeginDragHandler, IEndDragHandler
{
    /// <summary>
    /// ������� �������
    /// </summary>
    private RectTransform _rectTransform;
    /// <summary>
    /// ����� �� ������� ��������� ������
    /// </summary>
    private Canvas _mainCanvas;
    private CanvasGroup _canvasGroup;

    [SerializeField]
    GameObject _objWood;
    [SerializeField]
    GameObject _objWood1;

    // Start is called before the first frame update
    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _mainCanvas = GetComponentInParent<Canvas>();
    }





    public void OnBeginDrag(PointerEventData eventData)
    {
        // throw new System.NotImplementedException();
        var slotTransform = _rectTransform.parent; // Transform ��������
        slotTransform.SetAsLastSibling(); // � ����� ������ ��������
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.blocksRaycasts = false; // ������� ������ ������� canvasGroup
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += (eventData.delta / _mainCanvas.scaleFactor) ;


    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //  throw new System.NotImplementedException();
        //if( )
        {


        }
        transform.localPosition = Vector3.zero;
        _canvasGroup.blocksRaycasts = true;


    }





    // Update is called once per frame
   // void Update()
    
}
