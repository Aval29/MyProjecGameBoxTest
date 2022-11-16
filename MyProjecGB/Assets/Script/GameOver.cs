using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    [SerializeField]
    GameObject canvasGameOver;

    private void Update()
    {
        if (EventWorld.Temperature == EventWorld.TemperatureMax)
        {
            gameOver();
        }
    }
    public void gameOver()
    {
        canvasGameOver.SetActive(true);

    }

}
