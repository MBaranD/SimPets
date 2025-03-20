using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{
    void Start()
    {
        Invoke("LoadLastScene", 5f);
    }

    public void LoadLastScene()
    {
        /*
        int last_scene;

        string filePath = Path.Combine(Application.persistentDataPath, "currscene.json");
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
            SceneManager.LoadScene("SecondScene");
        }
        else if (last_scene == 6)
        {
            SceneManager.LoadScene("FirstScene");
        }
        else
        {
            Debug.LogError("Unknown scene index: " + last_scene);
        }
        */

        SceneManager.LoadScene("LoginScene");
    }
}