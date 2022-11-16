using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Forest : MonoBehaviour
{
    private Vector3 positOff;
    private Vector3 positOn;


    // Start is called before the first frame update
    void Awake()
    {
        transform.gameObject.SetActive(true);
        positOn = transform.position;
        positOff = positOn;
        positOff.x += 100;
        transform.position = positOff;
    }

    public void gameObj ( bool On)
    {
        transform.gameObject.SetActive(true);
        if (On == true)
        { onClickOn(); }
        else
            { onClickOff(); }

    }

    private void onClickOn()
    {

        transform.position = positOn;
    }
    private void onClickOff()
    {

        transform.position = positOff;
    }


}
