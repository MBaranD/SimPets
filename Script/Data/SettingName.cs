using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SettingName : MonoBehaviour
{
    public Text new_name;
    public InputField userInput;

    [System.Serializable]
    public class Data
    {
        public string name;
    }

    public void ChangeName()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "data.json");
        string userInp = userInput.text;

        Data nameData = new Data();
        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            nameData = JsonUtility.FromJson<Data>(dataAsJson);
        }

        nameData.name = userInp;
        string newDataAsJson = JsonUtility.ToJson(nameData);
        File.WriteAllText(filePath, newDataAsJson);

        Debug.Log("New Dog name: " + nameData.name);
        new_name.text = nameData.name;
    }
}
