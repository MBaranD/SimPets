using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class TempScene : MonoBehaviour
{
    public void setCurrentScene()
    {
        int currScene = SceneManager.GetActiveScene().buildIndex;
        string filePath = Path.Combine(Application.persistentDataPath, "currscene.json");

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

            Debug.Log("Current Scene: " + sceneData.scene);
        }
    }
}
