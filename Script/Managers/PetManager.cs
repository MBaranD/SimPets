using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetManager : MonoBehaviour
{
    public PetController Pet;
    public NeedsController NeedsController;
    public static PetManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Debug.LogWarning("More  than one PetManager in the scene!");
    }

    void Update()
    {

    }

    public void Die()
    {
        Debug.Log("Dead");
    }
}
