using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sawmill : MonoBehaviour
{

    [SerializeField]
    GameObject objWood;

    [SerializeField]
    GameObject objWoodBack;

    [SerializeField]
    Text amountWood;



    // Start is called before the first frame update
    void Start()
    {
    //    EventWorld.wood += 5;
    }

    // Update is called once per frame
    void Update()
    {
        woodd();
    }


    void woodd()
    {
        if (EventWorld.wood > 1)
        {
            objWood.SetActive(true);
            objWoodBack.SetActive(true);
        }
        else if (EventWorld.wood == 1)
        {
            objWood.SetActive(true);
            objWoodBack.SetActive(false);
        }
        else
        {
            objWood.SetActive(false); 
            objWoodBack.SetActive(false);

        }
        amountWood.text= Convert.ToInt32(EventWorld.wood).ToString();    



    }
}
