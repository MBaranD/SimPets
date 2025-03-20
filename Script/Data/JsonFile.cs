using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Data
{
    public string name;
}

public class Scene
{
    public int scene;
}

public class Pet_Name
{
    public string dog_name;
    public string cat_name;
}

public class User
{
    public string email;
    public string password;
}

public class JsonFile : MonoBehaviour
{
    private static bool tf = false;

    void Awake()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "data.json");
        string filePath2 = Path.Combine(Application.persistentDataPath, "data2.json");
        string filePath3 = Path.Combine(Application.persistentDataPath, "currscene.json");
        string filepath4 = Path.Combine(Application.persistentDataPath, "petdata.json");
        string filepath5 = Path.Combine(Application.persistentDataPath, "petdata2.json");
        string filepath6 = Path.Combine(Application.persistentDataPath, "userdata.json");
        string filepath7 = Path.Combine(Application.persistentDataPath, "lastscene.json");

        Debug.Log("filePath: " + filePath);
        Debug.Log("filePath: " + filePath2);
        Debug.Log("filePath: " + filePath3);
        Debug.Log("filePath: " + filepath4);
        Debug.Log("filePath: " + filepath5);
        Debug.Log("filePath: " + filepath6);
        Debug.Log("filePath: " + filepath7);

        if (!tf)
        {
            tf = true;

            // Ensure all files are created
            CreateFileIfNotExists(filePath, "{\"name\":\"\"}");
            CreateFileIfNotExists(filePath2, "{\"name\":\"\"}");
            CreateFileIfNotExists(filePath3, "{\"scene\": 4}");
            CreateFileIfNotExists(filepath4, "{\"food\": 100, \"mood\": 100, \"energy\": 100}");
            CreateFileIfNotExists(filepath5, "{\"food\": 100, \"mood\": 100, \"energy\": 100}");
            CreateFileIfNotExists(filepath6, "{\"email\":\"\", \"password\":\"\"}");
            CreateFileIfNotExists(filepath7, "{\"scene\": -1}");
        }
    }

    void CreateFileIfNotExists(string path, string jsonString)
    {
        if (!File.Exists(path))
        {
            Debug.Log("Creating file: " + path);
            using (StreamWriter streamWriter = File.CreateText(path))
            {
                streamWriter.Write(jsonString);
            }
        }
        else
        {
            Debug.Log("File already exists: " + path);
        }
    }
}