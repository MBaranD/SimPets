using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetController : MonoBehaviour
{   
    public Animator petAnimator; 

    private void Awake()
    {
        
    }

    

    public void HappyMood()
    {
        petAnimator.SetTrigger("Happy");
    }

    public void SadMood()
    {
        petAnimator.SetTrigger("Sad");
    }

    public void HungryMood()
    {
        petAnimator.SetTrigger("Hungry");
    }

    public void Eat()
    {
        petAnimator.SetTrigger("Eat");
    }

}
