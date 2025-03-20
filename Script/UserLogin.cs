using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class UserLogin : MonoBehaviour
{
    private string emailInput;
    private string passwordInput;

    public InputField emailInputField;
    public InputField passwordInputField;

    // Login butonuna tıklandığında çağrılır
    public void Login()
    {
        // E-posta ve şifre alanları boş mu kontrol edilir
        if (string.IsNullOrEmpty(emailInput))
        {
            Debug.Log("Please enter your email.");
            return;
        }

        if (string.IsNullOrEmpty(passwordInput))
        {
            Debug.Log("Please enter your password.");
            return;
        }

        string filePath = Path.Combine(Application.persistentDataPath, "userdata.json");
        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);

            User jsonData = JsonUtility.FromJson<User>(dataAsJson);
            Debug.Log("Email in Data: " + jsonData.email);
            Debug.Log("Password in Data: " + jsonData.password);


            if (emailInput != jsonData.email && passwordInput != jsonData.password)
            {
                Debug.Log("Click the Register");
            }
            if (emailInput == jsonData.email && passwordInput == jsonData.password)
            {
                int last_scene;

                string filePath2 = Path.Combine(Application.persistentDataPath, "currscene.json");
                if (!File.Exists(filePath2))
                {
                    Debug.LogError("File not found: " + filePath2);
                    Debug.LogError("Listing contents of: " + Application.persistentDataPath);
                    string[] files = Directory.GetFiles(Application.persistentDataPath);
                    foreach (string file in files)
                    {
                        Debug.Log(file);
                    }
                    return;
                }

                string jsonString;
                using (StreamReader streamReader = new StreamReader(filePath2))
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
            }
        }
        else
        {
            Debug.Log("PATH YOK BAK BURAYA KARDESIM: " + filePath);
        }

        string loginInfo = "Logged in, E-mail: " + emailInput + ", Password: " + passwordInput;
        Debug.Log(loginInfo);

        // Giriş yaptıktan sonra giriş bilgilerini sıfırla
        emailInput = "";
        passwordInput = "";
    }

    // RegisterAndLogin butonuna tıklandığında çağrılır
    public void RegisterAndLogin()
    {
        // E-posta ve şifre alanları boş mu kontrol edilir
        if (string.IsNullOrEmpty(emailInput))
        {
            Debug.Log("Please enter your email.");
            return;
        }

        if (string.IsNullOrEmpty(passwordInput))
        {
            Debug.Log("Please enter your password.");
            return;
        }

        string filePath = Path.Combine(Application.persistentDataPath, "userdata.json");

        User user = new User();

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            user = JsonUtility.FromJson<User>(dataAsJson);
        }

        user.email = emailInput;
        user.password = passwordInput;

        string newDataAsJson = JsonUtility.ToJson(user);
        File.WriteAllText(filePath, newDataAsJson);

        Debug.Log("Registered and logged in. E-mail: " + user.email + ", Password: " + user.password);

        // İkinci tıklamada sahneyi değiştir
        SceneManager.LoadScene("PetSelection"); // Burada doğru sahne adını veya ID'sini kullanın
    }

    // AboutSimpets butonuna tıklandığında çağrılır
    public void AboutSimpets()
    {
        // 'AboutSimpets' sahnesine geçiş yap
        SceneManager.LoadScene("AboutSimpets");
    }

    // E-posta input alanından gelen verileri okur
    public void ReadEmailInput(string email)
    {
        emailInput = email;
    }

    // Şifre input alanından gelen verileri okur
    public void ReadPasswordInput(string password)
    {
        passwordInput = password;
    }
}