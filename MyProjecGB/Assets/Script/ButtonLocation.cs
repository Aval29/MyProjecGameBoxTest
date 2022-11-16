using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonLocation : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    GameObject[] button;

    [SerializeField]
    GameObject[] location;







    public void OnPointerClick(PointerEventData eventData)
    {
        for (int i = 0; i < button.Length; i++)
        {
            if (eventData.pointerClick.transform.gameObject == button[i])
            {
                for (int j = 0; j < location.Length; j++)
                {
                    if (j ==i)
                    {
                        location[j].SetActive(true);
                    }
                    else
                    {
                        location[j].SetActive(false);   
                    }
                }

            }


        }   
    }












}
