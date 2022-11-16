using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    [SerializeField]
    private SaveGames saveGames;

    /// <summary>
    /// Ползунок температуры
    /// </summary>
    [SerializeField]
    private Image temperatureIcon;
    /// <summary>
    /// Температура Погоды 
    /// </summary>
    [SerializeField]
    private Text  temperature;
    /// <summary>
    /// Древесина
    /// </summary>
    [SerializeField]
    private Text wood;

    /// <summary>
    /// Дрова (топлива)
    /// </summary>
    [SerializeField]
    private Text fireWood;
    /// <summary>
    /// Мана (деньги)
    /// </summary>
    [SerializeField]
    private Text ManaPoint;
    /// <summary>
    /// Lv Колличество лесорубов (сбор дров)
    /// </summary>
    [SerializeField]
    private Text woodMan;
    /// <summary>
    /// Lv Колличество Обработчик дривесины (создания дров (топлива))
    /// </summary>
    [SerializeField]
    private Text fireWoodMan;



    // private EventWorld Resurs;



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("weather", 1,1);
      
    }

    // Update is called once per frame
    void Update()
    {
        temp();
    }









    void weather()
    {
        if (EventWorld.Temperature < EventWorld.TemperatureMax)
        {
            EventWorld.Temperature += 1;

        }

         if (EventWorld.Temperature > EventWorld.TemperatureMax)
        { EventWorld.Temperature = EventWorld.TemperatureMax; }

    }




    void temp()
    {
        float temp = EventWorld.Temperature / EventWorld.TemperatureMax;
        temperatureIcon.fillAmount = temp;

        temperature.text = ("- " + (int)EventWorld.Temperature + " °C");
        wood.text = (Convert.ToInt32(EventWorld.wood).ToString());
        fireWood.text = (Convert.ToInt32(EventWorld.fireWood).ToString());
        ManaPoint.text = (Convert.ToInt32(EventWorld.ManaPoint).ToString());
        woodMan.text = (Convert.ToInt32(EventWorld.woodMan).ToString());
        fireWoodMan.text = (Convert.ToInt32(EventWorld.fireWoodMan).ToString());
    
    
    }





    public void ResetGames()
    {
        saveGames.SaveDel();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        worldRe();
        // SampleScene
    }

    private void worldRe()
    {
    EventWorld.Temperature = 0;
        EventWorld.TemperatureMax = 50;
     EventWorld.ManaPoint = 0;
        EventWorld.wood = 0;
        EventWorld.fireWood = 0;
        EventWorld.woodMan = 0;
        EventWorld.fireWoodMan = 0;
        EventWorld.crystalLv =1;

}

}
