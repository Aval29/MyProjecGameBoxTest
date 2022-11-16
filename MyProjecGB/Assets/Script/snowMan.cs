using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class snowMan : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private int HP = 5;


    public void OnPointerClick(PointerEventData eventData)
    {
        HP -= 1;
        colorWood();
        if (HP <= 0)
        {
            Destroy(transform.gameObject);
            EventWorld.ManaPoint += 10;
            EventWorld.Temperature -= 5;
            if (EventWorld.Temperature <= 0)
               EventWorld.Temperature = 0;
        }
    }

    void colorWood()
    {
        float col;
        if (HP == 4)
        { col = 255; }
        else
        { col = transform.GetComponent<Image>().color.b; }

        col -= 255 / 5;
        transform.GetComponent<Image>().color = new Color(255, col, col);
    }



}
