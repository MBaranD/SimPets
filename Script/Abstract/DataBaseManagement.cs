using System;
using System.IO;
using UnityEngine;

public class DataBaseManagement
{
    private string path = Application.dataPath + "/Resources/Saves/";

    public void SaveData<T>(string SaveName, T SaveData)
    {
        string JsonToSave = JsonUtility.ToJson(SaveData);
        File.WriteAllText(path + SaveName + ".json", JsonToSave);
    }

    public void LoadData<T>(string SaveName, System.Action<T> CallBack)
    {
        if (File.Exists(path + SaveName + ".json"))
        {
            string loadedJson = File.ReadAllText(path + SaveName + ".json");
            CallBack(JsonUtility.FromJson<T>(loadedJson));
        }
        else
        {
            Debug.Log("File doesn't exist");
        }
    }
}
