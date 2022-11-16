using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class furnace : MonoBehaviour , IPointerClickHandler 
{
    public void OnPointerClick(PointerEventData eventData)
    {

        if (EventWorld.fireWood > 0)
        {
            EventWorld.Temperature -= 1;
            EventWorld.fireWood -= 1;
            if (EventWorld.Temperature < 0)
            {
                EventWorld.Temperature = 0;
            }           
        }
        else
        {
            EventWorld.Temperature -= .1f;
        }
    }




}
