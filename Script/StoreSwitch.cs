using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class StoreSwitch : MonoBehaviour
{
    public void setScene()
    {
        int currScene = SceneManager.GetActiveScene().buildIndex;
        string filePath = Path.Combine(Application.persistentDataPath, "lastscene.json");

        if(File.Exists(filePath))
        {
            string jsonString;
            using(StreamReader streamReader = new StreamReader(filePath))
            {
                jsonString = streamReader.ReadToEnd();
            }

            Scene sceneData = JsonUtility.FromJson<Scene>(jsonString);
            sceneData.scene = currScene;

            string updatedJsonString = JsonUtility.ToJson(sceneData);
            using(StreamWriter streamWriter = new StreamWriter(filePath))
            {
                streamWriter.Write(updatedJsonString);
            }

            Debug.Log("Store Scene: " + sceneData.scene);
        }
    }

    public void getScene()
    {
        int last_scene;

        string filePath = Path.Combine(Application.persistentDataPath, "lastscene.json");
        if (!File.Exists(filePath))
        {
            Debug.LogError("File not found: " + filePath);
            Debug.LogError("Listing contents of: " + Application.persistentDataPath);
            string[] files = Directory.GetFiles(Application.persistentDataPath);
            foreach (string file in files)
            {
                Debug.Log(file);
            }
            return;
        }

        string jsonString;
        using (StreamReader streamReader = new StreamReader(filePath))
        {
            jsonString = streamReader.ReadToEnd();
        }

        Scene sceneData = JsonUtility.FromJson<Scene>(jsonString);
        last_scene = sceneData.scene;

        if (last_scene == 4)
        {
            SceneManager.LoadScene(4);
        }
        else if (last_scene == 6)
        {
            SceneManager.LoadScene(6);
        }
        else
        {
            Debug.LogError("Unknown scene index: " + last_scene);
        }
    }
}
