using System.Collections;
using System.Collections.Generic;
// using UnityEngine.UI;

using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Data;
using Unity.VisualScripting;
using UnityEngine.UIElements;

public class SaveGames : MonoBehaviour
{   
    bool _pause = false;
    [SerializeField]
    private Interface _interface;

    bool saveLoad = false;

    /// <summary>
    /// Префаб Снежинки
    /// </summary>
    [SerializeField]
    private GameObject objSnowFlake;
    /// <summary>
    /// Префаб Снежка
    /// </summary>
    [SerializeField]
    private GameObject objSnowBoll;
    /// <summary>
    /// Префаб дерева(для леса)
    /// </summary>
    [SerializeField]
    private GameObject objWood;
    /// <summary>
    /// Локация - лес (для создания оьектов)
    /// </summary>
    [SerializeField]
    private GameObject objForest;



    private void Awake()
    {

        StartNewGames();
        Load();

    }
    private void StartNewGames()
    {
        EventWorld.crystalLv = 1;
        EventWorld.TemperatureMax = 50;

    }





    private void Start()
    {
        _pause = true;
        
    }

    void OnApplicationPause(bool pause)
    {
        if (_pause)
        {
                if (pause)
            {
                Debug.Log("Пауза");
                if (saveLoad == false)
                    Save();
            }
        }
    }

    private void OnApplicationQuit()
    {
        if (saveLoad == false)
            Save();
    }

    public void SaveDel()
    {
        File.Delete(Application.persistentDataPath + "/SaveGames/Save.dat");

    }






    [SerializeField]
    private GameObject forestPares;



    public void Save()
    {
        saveLoad = true;
        BinaryFormatter bf = new BinaryFormatter();
        Directory.CreateDirectory(Application.persistentDataPath + "/SaveGames");
        FileStream file = File.Create(Application.persistentDataPath  + "/SaveGames/Save.dat"); //dataPath

        SaveData data = new SaveData();

        data.TimeSave = System.DateTime.Now;

        #region EventWorld

        data.Temperature = EventWorld.Temperature;
        data.TemperatureMax = EventWorld.TemperatureMax;
        data.ManaPoint = EventWorld.ManaPoint;
        data.wood = EventWorld.wood;
        data.fireWood = EventWorld.fireWood;
        data.woodMan = EventWorld.woodMan;
        data.fireWoodMan = EventWorld.fireWoodMan;
        data.crystalLv = EventWorld.crystalLv ;
        #endregion


        #region Forest
        //if (data.ForestPosit != null)
        //{
        //    data.ForestPosit.Clear();
        //    data.ForestOjb.Clear();
        //}
        //if (forestPares.transform.childCount > 0)
        //{
        //    var ChildObj = new List<Transform>(forestPares.GetComponentsInChildren<Transform>());
        //    for (int i = 0; i < ChildObj.Count; i++)
        //    {
        //        data.ForestPosit.Add(ChildObj[i].position);
        //        if(ChildObj[i].GetComponent<SnowFlake>() == true)
        //        { data.ForestOjb.Add(1); }
        //        else if (ChildObj[i].GetComponent<SnowBoll>() == true)
        //        { data.ForestOjb.Add(2); }
        //        else if (ChildObj[i].GetComponent<Wood>() == true)
        //        { data.ForestOjb.Add(10); }
        //        else
        //        { data.ForestOjb.Add(0); }

        //    }

        //}
        //else
        //{
        //    data.ForestPosit.Clear();
        //    data.ForestOjb.Clear();

        //}




        //if (data.Forest != null) 
        //{ 
        //data.Forest.Clear();
        //}
        //if (forestPares.transform.childCount > 0)
        //{
        //    data.Forest = new List<Transform>(forestPares.GetComponentsInChildren<Transform>());
        //}
        //else
        //{
        //    data.Forest.Clear();

        //}
        #endregion



        bf.Serialize(file, data);
        saveLoad = false;
        Debug.Log("Игра Сохранена!");
    }





    [SerializeField]
    private TimeAbsent timeAbsent;


    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/SaveGames/Save.dat") == true)
        ///Сначала ищем файл с сохраненными данными, который мы создали в методе SaveGame.
        {
            BinaryFormatter bf = new BinaryFormatter();

            FileStream file =
            File.Open(Application.persistentDataPath + "/SaveGames/Save.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();

            ///Передаем записанные в нем значения в переменные класса SaveSerial (class). 



            #region EventWorld

            EventWorld.Temperature =  data.Temperature ;
             EventWorld.TemperatureMax = data.TemperatureMax;
             EventWorld.ManaPoint = data.ManaPoint;
             EventWorld.wood   = data.wood;
             EventWorld.fireWood = data.fireWood ;
             EventWorld.woodMan  = data.woodMan;
             EventWorld.fireWoodMan = data.fireWoodMan;
            EventWorld.crystalLv = data.crystalLv;

            #endregion


            #region Forest

            //data.ForestPosit.Clear();
            //data.ForestOjb.Clear();
            //if (data.ForestPosit != null)
            //{
            //    for (int i = 0; i < data.ForestOjb.Count; i++)
            //    {
            //        if (data.ForestOjb[i] == 1)
            //        {
            //            var _newObj = Instantiate(objSnowFlake, data.ForestPosit[i], Quaternion.identity);
            //            _newObj.transform.SetParent(objForest.transform);
            //        }
            //        else if (data.ForestOjb[i] == 2)
            //        {
            //            var _newObj = Instantiate(objSnowBoll, data.ForestPosit[i], Quaternion.identity);
            //            _newObj.transform.SetParent(objForest.transform);
            //        }
            //        else if (data.ForestOjb[i] == 10)
            //        {
            //            var _newObj = Instantiate(objWood, data.ForestPosit[i], Quaternion.identity);
            //            _newObj.transform.SetParent(objForest.transform);
            //        }
            //        else
            //        {  }

            //    }


            //    var ChildObj = new List<GameObject>(forestPares.GetComponentsInChildren<GameObject>());
            //    for (int i = 0; i < ChildObj.Count; i++)
            //    {
            //        data.ForestPosit.Add(ChildObj[i].transform.position);
            //        if (ChildObj[i].GetComponent<SnowFlake>())
            //        { data.ForestOjb.Add(1); }


            //    }

            //}
            //else
            //{
            //    data.ForestPosit.Clear();
            //    data.ForestOjb.Clear();

            //}



            // Vector3
            //if (data.Forest != null)
            //{
            //    for (int i = 0; i < data.Forest.Count; i++)
            //    {

            //        forestPares.GetComponent<Transform>().SetParent(data.Forest[i]);
            //    }
            //}

            #endregion


            /// 
            var _deltaTime = data.TimeSave;
            _deltaTime.AddSeconds(5);
            if (_deltaTime <= System.DateTime.Now)
            {
                timeAbsent.gameObject.SetActive(true);  
                timeAbsent.timeStartGames = System.DateTime.Now;
                timeAbsent.timeExitGames = data.TimeSave;

                    /// LoadUpdate(System.DateTime.Now, data.TimeSave);
            }

            Debug.Log("Загрузка завершена");

        }
        else
        {
            Debug.Log("Нет сохранения!");

        }

    }



    //private void LoadUpdate(System.DateTime timeStart, System.DateTime timeExit)
    //{
    //    int passedSeconds =
    //        timeStart.Second - timeExit.Second +
    //        (timeStart.Minute - timeExit.Minute) * 60 +
    //        (timeStart.Hour - timeExit.Hour) * 60 * 60 +
    //        (timeStart.Day - timeExit.Day) * 60 * 60 * 24;

    //    EventWorld.wood += EventWorld.woodMan * passedSeconds;
    //    EventWorld.fireWood += EventWorld.fireWoodMan * passedSeconds;
    //}


}














[System.Serializable]
public class SaveData
{
    public System.DateTime TimeSave;
    public float Temperature;
    public float TemperatureMax;
    public float ManaPoint;
    public float wood;
    public float fireWood;
    public float woodMan;
    public float fireWoodMan;
    public int crystalLv;

    #region 
    // public List<Transform> Forest;
    public List<Vector3> ForestPosit;
    //public List<> ForestObj;
    public List<int> ForestOjb;
    #endregion

}

