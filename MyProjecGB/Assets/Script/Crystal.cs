using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Crystal : MonoBehaviour , IPointerClickHandler
{
    [SerializeField]
    private GameObject buttUp;

    
    [SerializeField]
    private Text textCrystalLv;



    [SerializeField]
    private Text textWoodLvUp;
    [SerializeField]
    private Text textFireWoodLvUp;


    public void OnPointerClick(PointerEventData eventData)
    {
        EventWorld.ManaPoint += EventWorld.crystalLv;

    }



    public void Update()
    {
        textCrystalLv.text = EventWorld.crystalLv.ToString();
        textWoodLvUp.text = (Convert.ToInt32(EventWorld.crystalLv * 10).ToString());
        textFireWoodLvUp.text = (Convert.ToInt32(EventWorld.crystalLv * 100).ToString());


        if (EventWorld.wood >= EventWorld.crystalLv * 10 && EventWorld.fireWood >= EventWorld.crystalLv * 100)
        {
            buttUp.SetActive(true);
        }
        else
        { buttUp.SetActive(false); }

    }

    public void clickLvUp()
    {
        EventWorld.wood -= EventWorld.crystalLv * 10;
        EventWorld.fireWood -= EventWorld.crystalLv * 100;
        EventWorld.crystalLv += 1;


    }



}
