using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PriceMan : MonoBehaviour
{
    [SerializeField]
    private int woodMan;
    [SerializeField]
    private int priceWoodMan;
    [SerializeField]
    private int fireWoodMan;
    [SerializeField]
    private int priceFireWoodMan;



    [SerializeField]
    private Text textWoodMan;
    [SerializeField]
    private Text textPriceWoodMan;
    [SerializeField]
    private Text textFireWoodMan;
    [SerializeField]
    private Text textPriceFireWoodMan;

    [SerializeField]
    private GameObject buttonWoodMan;
    [SerializeField]
    private GameObject buttonFireWoodMan;


    private void Start()
    {
        Invoke("updateWorkWoodMan", 1);
        Invoke("updateWorkFireWoodMan", 1.3f);
    }
    private void Update()
    {

        updateMan();
        updateFireMan();


    }



    void updateWorkWoodMan()
    {
        EventWorld.wood += EventWorld.woodMan * 2 / 3;
        Invoke("updateWorkWoodMan", 1);

    }

    void updateWorkFireWoodMan()
        {
            if (EventWorld.wood >= EventWorld.fireWoodMan)
        {
            EventWorld.wood -= EventWorld.fireWoodMan;
            EventWorld.fireWood += EventWorld.fireWoodMan*2;
        }
        else if (EventWorld.wood > 0)
        {
            EventWorld.wood -= EventWorld.wood;
            EventWorld.fireWood += EventWorld.wood * 2;

        }
        Invoke("updateWorkFireWoodMan", 1.3f);

    }



    void updateMan()
    {
        textWoodMan.text = (EventWorld.woodMan.ToString());

        var _price = (EventWorld.woodMan+1) * 10;
        textPriceWoodMan.text = (_price.ToString());

        if (EventWorld.ManaPoint >= _price ) // || EventWorld.woodMan > 0)
        {
            buttonWoodMan.SetActive(true);
        }
        else
        {
            buttonWoodMan.SetActive(false);
        }

    }
        void updateFireMan()
    { 
            textFireWoodMan.text = (EventWorld.fireWoodMan.ToString());

        var _price = (EventWorld.fireWoodMan+1) * 15 ;
        textPriceFireWoodMan.text = (_price.ToString());

        if (EventWorld.ManaPoint >= _price ) //|| EventWorld.fireWoodMan > 0 )
        {
            buttonFireWoodMan.SetActive(true);
        }
        else
        {
            buttonFireWoodMan.SetActive(false);
        }

    }




   public void clickWoodManUp()
    {
        var _price = (EventWorld.woodMan+1) * 10;
        if (EventWorld.ManaPoint >= _price)
        {
            EventWorld.ManaPoint -= _price;
            EventWorld.woodMan += 1;
        }

    }


    public void clickFireWoodManUp()
    {
        var _price = (EventWorld.fireWoodMan + 1) * 15;
        if (EventWorld.ManaPoint >= _price)
        {
            EventWorld.ManaPoint -= _price;
            EventWorld.fireWoodMan += 1;
        }

    }





}
