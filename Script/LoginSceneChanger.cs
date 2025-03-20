using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginSceneChanger : MonoBehaviour
{
    private int nextSceneID; // Bir sonraki sahnenin ID'sini tutmak i�in
    private bool isFirstClick = true; // �lk t�klamay� izlemek i�in bir bayrak

    // �leri bir sahneye ge�mek i�in �a�r�lacak olan fonksiyon
    public void ChangeScene(int scene_id)
    {
        SceneManager.LoadScene(scene_id);
    }

    // "Login" butonuna t�kland���nda �a�r�lacak olan fonksiyon
    public void OnLoginButtonClicked(int nextSceneID)
    {
        if (isFirstClick)
        {
            this.nextSceneID = nextSceneID; // Bir sonraki sahnenin ID'sini ayarla
            isFirstClick = false; // �lk t�klama ger�ekle�ti�inde bayra�� kapat
        }
    }

    // "Register&Login" butonuna t�kland���nda direkt olarak bir sonraki sahneye ge�mek i�in �a�r�lacak olan fonksiyon
    public void OnRegisterAndLoginButtonClicked(int nextSceneID)
    {
        if (isFirstClick)
        {
            this.nextSceneID = nextSceneID; // Bir sonraki sahnenin ID'sini ayarla
            isFirstClick = false; // �lk t�klama ger�ekle�ti�inde bayra�� kapat
        }
        else
        {
            SceneManager.LoadScene(nextSceneID); // �kinci t�klamada sahneyi de�i�tir
        }
    }
}
