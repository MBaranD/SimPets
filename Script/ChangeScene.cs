using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int x;

    public void MoveToScene(int sceneID){
        SceneManager.LoadScene(sceneID);
    }

    public void SwitchPet(){
        int currScane = SceneManager.GetActiveScene().buildIndex;

        if(currScane == 4){
            SceneManager.LoadScene(5);
        }

        if(currScane == 6){
            SceneManager.LoadScene(3);
        }
    }
}
