using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBaseManager : MonoBehaviour
{
    public static DataBaseManager instance;
    private DataBaseManagement DataBaseManagement;
    public NeedsController NeedsController;

    private void Awake()
    {
        DataBaseManagement = new DataBaseManagement();
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("More than one DataBaseManagement in yhe Scene");
        }
    }

    private void Update()
    {
        if (TimingManager.GameHourTimer < 0)
        {
            Pet Pet = new Pet(NeedsController.LastTimeFed, 
            NeedsController.LastTimeMood, 
            NeedsController.LastTimeEnergy,
            NeedsController.food,
            NeedsController.mood,
            NeedsController.energy);

            SavePet(Pet);
        }
    }

    private void Start()
    {
        Pet pet = LoadPet();
        if (pet != null)
        {
            Debug.Log(LoadPet().energy);
        }
    }

    public void SavePet(Pet Pet)
    {
        DataBaseManagement.SaveData("pet", Pet);
    }

    public Pet LoadPet()
    {
        Pet returnValue = null;
        DataBaseManagement.LoadData<Pet>("pet", (Pet) =>
        {
            returnValue = Pet;
        });
        return returnValue;
    }

}
