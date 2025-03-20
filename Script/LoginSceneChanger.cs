using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginSceneChanger : MonoBehaviour
{
    private int nextSceneID; // Bir sonraki sahnenin ID'sini tutmak için
    private bool isFirstClick = true; // Ýlk týklamayý izlemek için bir bayrak

    // Ýleri bir sahneye geçmek için çaðrýlacak olan fonksiyon
    public void ChangeScene(int scene_id)
    {
        SceneManager.LoadScene(scene_id);
    }

    // "Login" butonuna týklandýðýnda çaðrýlacak olan fonksiyon
    public void OnLoginButtonClicked(int nextSceneID)
    {
        if (isFirstClick)
        {
            this.nextSceneID = nextSceneID; // Bir sonraki sahnenin ID'sini ayarla
            isFirstClick = false; // Ýlk týklama gerçekleþtiðinde bayraðý kapat
        }
    }

    // "Register&Login" butonuna týklandýðýnda direkt olarak bir sonraki sahneye geçmek için çaðrýlacak olan fonksiyon
    public void OnRegisterAndLoginButtonClicked(int nextSceneID)
    {
        if (isFirstClick)
        {
            this.nextSceneID = nextSceneID; // Bir sonraki sahnenin ID'sini ayarla
            isFirstClick = false; // Ýlk týklama gerçekleþtiðinde bayraðý kapat
        }
        else
        {
            SceneManager.LoadScene(nextSceneID); // Ýkinci týklamada sahneyi deðiþtir
        }
    }
}
