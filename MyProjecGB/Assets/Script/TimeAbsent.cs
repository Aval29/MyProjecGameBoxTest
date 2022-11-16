using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TimeAbsent : MonoBehaviour
{
    [SerializeField]
    private Text textDay;
    [SerializeField]
    private Text textHour;
    [SerializeField]
    private Text textMinute;
    [SerializeField]
    private Text textSecond;

    [SerializeField]
    private Text textWood;
    [SerializeField]
    private Text textFireWood;

    public System.DateTime timeStartGames;
    public System.DateTime timeExitGames;


    private void Start()
    {
        LoadUpdate(timeStartGames, timeExitGames);

    }


    public void LoadUpdate(System.DateTime timeStart, System.DateTime timeExit)
    {
        int passedSeconds =
            timeStart.Second - timeExit.Second +
            (timeStart.Minute - timeExit.Minute) * 60 +
            (timeStart.Hour - timeExit.Hour) * 60 * 60 +
            (timeStart.Day - timeExit.Day) * 60 * 60 * 24;
        
        if (passedSeconds < 5)
        {
            transform.gameObject.SetActive(false);
        }


        var ProfitWood = EventWorld.woodMan * passedSeconds ;
        var ProfitFireWood = EventWorld.fireWoodMan * passedSeconds *0.75f ;


        EventWorld.wood += ProfitWood ;
        if (EventWorld.wood > ProfitFireWood)
        {
            EventWorld.wood -= ProfitFireWood;
            ProfitWood -= ProfitFireWood;
            EventWorld.fireWood += ProfitFireWood *4 ;
        }
        else
        {
            ProfitWood -= EventWorld.wood;
            EventWorld.wood = 0;
            EventWorld.fireWood += EventWorld.wood *4;
        }
        ProfitFireWood *= 4;


        textWood.text =Convert.ToInt32 (ProfitWood).ToString();
        textFireWood.text = Convert.ToInt32(ProfitFireWood).ToString();



        checkTime(timeStart.Day, timeExit.Day, timeStart.Hour, timeExit.Hour, textDay, textHour, " Дней ", " Часов ");
        checkTime(timeStart.Hour, timeExit.Hour, timeStart.Minute, timeExit.Minute, textHour, textMinute, " Часов ", " Минут ");
        checkTime(timeStart.Minute, timeExit.Minute, timeStart.Second, timeExit.Second, textMinute, textSecond, " Минут ", " Секунды ");

        if (timeStart.Second - timeExit.Second > 0)
        {
            textSecond.text = (timeStart.Second - timeExit.Second + " Секунд ");
        }
        else
        {
            textSecond.text = (" ");
        }



    }





    private void checkTime(int timeSt,int timeEx, int timeStDown , int timeExDown,
        Text time, Text timeDown,string timeName, string timeNameDown)
    {
        if (timeSt - timeEx > 0)
        {
            if (timeStDown - timeExDown < 0)
            {
                time.text = (" ");
                timeDown.text = timeExDown - timeStDown + timeNameDown;
            }
            else
            {
                time.text = (timeSt - timeEx + timeName);
            }
        }
        else if (timeSt - timeEx == 0)
        {
            time.text = (" ");
        }
    }




}
