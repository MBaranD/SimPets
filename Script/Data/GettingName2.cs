using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class GettingName2 : MonoBehaviour
{
    public Text nameFromJSON;

    void Start()
    {
        // Path to the JSON file
        string filePath = Path.Combine(Application.persistentDataPath, "data2.json");

        if (File.Exists(filePath))
        {
            // Read the JSON file
            string dataAsJson = File.ReadAllText(filePath);

            // Deserialize the JSON into a Data object
            Data jsonData = JsonUtility.FromJson<Data>(dataAsJson);

            // Extract the name field from the Data object
            //nameFromJSON = jsonData.name;
            
            nameFromJSON.text = jsonData.name;

            // Display the name
            //Debug.Log("Name from JSON: " + nameFromJSON);
        }
        else
        {
            Debug.LogError("Cannot find JSON file at: " + filePath);
        }
    }
}
