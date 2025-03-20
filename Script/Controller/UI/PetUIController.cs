using UnityEngine;
using UnityEngine.UI;

public class PetUIController : MonoBehaviour
{
    public Image FoodBar, MoodBar, EnergyBar;

    public static PetUIController instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("More than one PetUIController in yhe Scene");
        }
    }

    public void UpdateImages(int Food, int Mood, int Energy)
    {
        FoodBar.fillAmount =(float) Food / 100;
        MoodBar.fillAmount =(float) Mood / 100;
        EnergyBar.fillAmount =(float) Energy / 100;
    }
}
