using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedsController : MonoBehaviour
{
    public int food, mood, energy;
    public int FoodTickRate, MoodTickRate, EnergyTickRate;
    public DateTime LastTimeFed, LastTimeMood, LastTimeEnergy;

    private void Awake()
    {
        Initialize(100, 100, 100, 10, 10, 10);
    }

    public void Initialize(int food, int mood, int energy, int FoodTickRate, int MoodTickRate, int EnergyTickRate)
    {
        LastTimeFed = DateTime.Now;
        LastTimeMood = DateTime.Now;
        LastTimeEnergy = DateTime.Now;
        this.food = food;
        this.mood = mood;
        this.energy = energy;
        this.FoodTickRate = FoodTickRate;
        this.MoodTickRate = MoodTickRate;
        this.EnergyTickRate = EnergyTickRate;
        PetUIController.instance.UpdateImages(food,mood,energy);
    }

    private void Update()
    {
        if (TimingManager.GameHourTimer < 0)
        {
            ChangeFood(-FoodTickRate);
            ChangeMood(-MoodTickRate);
            ChangeEnergy(-EnergyTickRate);
            PetUIController.instance.UpdateImages(food,mood,energy);
        }
    }

    public void ChangeFood(int amount)
    {
        food += amount;

        if (amount > 0)
        {
            LastTimeFed = DateTime.Now;
        }
        if (food < 0)
        {
            PetManager.instance.Die();
        }

        else if (food > 100)
        {
            food = 100;
        }

        else if (food < 0)
        {
            food = 0;
        }
    }

    public void ChangeMood(int amount)
    {
        mood += amount;

        if (amount > 0)
        {
            LastTimeMood = DateTime.Now;
        }

        if (mood < 0)
        {
            PetManager.instance.Die();
        }

        else if (mood > 100)
        {
            mood = 100;
        }

        else if (mood < 0)
        {
            mood = 0;
        }
    }

    public void ChangeEnergy(int amount)
    {
        energy += amount;

        if (amount > 0)
        {
            LastTimeEnergy = DateTime.Now;
        }

        if (energy < 0)
        {
            PetManager.instance.Die();
        }

        else if (energy > 100)
        {
            energy = 100;
        }

        else if (energy < 0)
        {
            energy = 0;
        }
    }
}
