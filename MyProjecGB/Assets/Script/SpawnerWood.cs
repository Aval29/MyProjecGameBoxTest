using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerWood : MonoBehaviour
{
    private Transform spawnPosArea;
    public Transform spawnPosAreaEdge;


    /// <summary>
    /// граници герерации обьекта
    /// </summary>
    [SerializeField]
    Vector2 range;

    /// <summary>
    /// Генерируемый обьект
    /// </summary>
    [SerializeField]
    GameObject snowFlake;


    
    // Start is called before the first frame update
    void Start()
    {
        spawnPosArea = GetComponent<Transform>();   
        StartCoroutine(Spawn());

        range.x = spawnPosArea.transform.position.x - spawnPosAreaEdge.transform.position.x;
        range.y = -spawnPosArea.transform.position.y + spawnPosAreaEdge.transform.position.y;

        // range.x = spawnPosArea.GetComponent<RectTransform>().rect.width /225 ;
        // range.y = spawnPosArea.GetComponent<RectTransform>().rect.height / 210 ;


    }



    private float Speed()
    {
        float Sp = ((EventWorld.Temperature / EventWorld.TemperatureMax) * 10f + 0.3f);

        return Sp;
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Speed());
        for (int i = 0; i < 3 ; i++) /// попытки найти сводобное место
        {       
        Vector3 pos = spawnPosArea.position + new Vector3(Random.Range(-range.x, range.x), Random.Range(-range.y , 0), 0);
        var rad = 0.29f; // new Vector3(0, (pos.y + 0.6f), 0) - длина/ширина  
            Collider2D colls = Physics2D.OverlapCircle(pos, rad); 
        if(colls == null)
            {
                newSnowFlake(snowFlake, pos);
               // i = 100;
            }

        }
        Repeat();
    }

    /// <summary>
    /// создать обьект в точке
    /// </summary>
    /// <param name="newObj">создаваемый обьект </param>
    /// <param name="positionNewObj">точка создания </param>
    void newSnowFlake (GameObject newObj , Vector3 positionNewObj)
    {
        var _newObj = Instantiate( newObj, positionNewObj, Quaternion.identity);
        _newObj.transform.SetParent(spawnPosArea);
    }

    // повтор действия 
    void Repeat ()
    {
        StartCoroutine(Spawn());

    }


}
