using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Wood : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private int HP = 2;


    public void OnPointerClick(PointerEventData eventData)
    {
        HP -= 1;
        colorWood();
        if (HP <= 0)
        {
            Destroy(transform.gameObject);
            EventWorld.wood += 1;
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
