using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class SnowFlake : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerUpHandler  , IPointerDownHandler
{


    //private EventWorld Resurs;
    /// <summary>
    /// ������� �������
    /// </summary>
    private RectTransform _rectTransform;

    /// <summary>
    /// ����� �� ������� ��������� ������
    /// </summary>
    private Canvas _mainCanvas;

    /// <summary>
    /// ��������� �� �������
    /// </summary>
    private CanvasGroup _canvasGroup;

    /// <summary>
    /// ����������� ������ ��� �������
    /// </summary>
    public GameObject snowBall; // �� snowFlake;

    /// <summary>
    /// ��������� ������� �� �������
    /// </summary>
    private Vector3 _startPosition;


    private float _tempUp = 0.5f;
    private float _manaUp = 1 ;


    // Start is called before the first frame update
    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _mainCanvas = GetComponentInParent<Canvas>();
        _startPosition = transform.position;
        startObj();


    }

    void startObj()
    {
        if (transform.name == "snowFlake")
        {
            _tempUp = 0.5f;
            _manaUp = 1;
        }
    }



    public void OnPointerDown(PointerEventData eventData)
    {

    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (transform.position == _startPosition)
        {
            snowFlakeMelted();
        }
    }

    




    public void OnBeginDrag(PointerEventData eventData)
    {
        _rectTransform.SetAsLastSibling(); // � ����� ������ ��������
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.blocksRaycasts = false; // ������� ������ ������� canvasGroup
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += (eventData.delta / _mainCanvas.scaleFactor);


    }


    public void OnEndDrag(PointerEventData eventData)
    {
        Collider2D colls = checkDouble(transform.position, 0.28f);
        if (colls != null && colls.transform.gameObject.GetComponent<SnowFlake>() == true)
        {
            mergerFlakeMelted(colls.transform);
            // _canvasGroup.blocksRaycasts = true;
            /// OnDrop
        }
        else // if (colls == null)
        {
            snowFlakeMelted();
        }
        




    }


    /// <summary>
    /// ����, �������� �������
    /// </summary>
    private void snowFlakeMelted()
    {
        Destroy(transform.gameObject);
        EventWorld.Temperature -= _tempUp*2;
        if (EventWorld.Temperature <0)
        {
            EventWorld.Temperature= 0;  
        }



    }

    /// <summary>
    /// ������� � �������� _megObj
    /// </summary>
    /// <param name="_megObj">������ �������</param>
    private void mergerFlakeMelted(Transform _megObj)
    {
        newSnowBall(snowBall, _megObj.transform.position);
        Destroy(_megObj.transform.gameObject);
        Destroy(transform.gameObject);
        EventWorld.ManaPoint += _manaUp;
        EventWorld.Temperature -= _tempUp;
        if (EventWorld.Temperature < 0)
        {
            EventWorld.Temperature = 0;
        }

    }




    /// <summary>
    /// ������� ������ � �����
    /// </summary>
    /// <param name="newObj">����������� ������ </param>
    /// <param name="positionNewObj">����� �������� </param>
    private void newSnowBall(GameObject newObj, Vector3 positionNewObj)
    {
        var _newObj = Instantiate(newObj, positionNewObj, Quaternion.identity);
        _newObj.transform.SetParent(transform.parent);
    }



/// <summary>
/// �������� � ������ radius �� ������� position.
/// </summary>
/// <param name="position">������� ������</param>
/// <param name="radius">������ ������</param>
private Collider2D checkDouble (Vector2 position, float radius)
    {
        transform.GetComponent<BoxCollider2D>().enabled = false;
        Collider2D colls = Physics2D.OverlapCircle(position, radius);
        transform.GetComponent<BoxCollider2D>().enabled = true;
        return colls;
    }


}

