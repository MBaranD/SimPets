using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class GettingName : MonoBehaviour
{
    public Text nameFromJSON;

    void Start()
    {
        Debug.Log("Normal: " + Application.dataPath);
        Debug.Log("Streaming: " + Application.streamingAssetsPath);
        Debug.Log("Persistent: "  + Application.persistentDataPath);

        // Path to the JSON file
        string filePath = Path.Combine(Application.persistentDataPath, "data.json");

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);

            Data jsonData = JsonUtility.FromJson<Data>(dataAsJson);
            
            nameFromJSON.text = jsonData.name;
        }
        else
        {
            Debug.LogError("GETTING DE JSON YOK: " + filePath);
        }
    }
}
