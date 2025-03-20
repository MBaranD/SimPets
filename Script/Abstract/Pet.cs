using System;
[Serializable]
public class Pet
{
    public DateTime LastTimeFed, LastTimeMood, LastTimeEnergy;
    public int food, mood, energy;


    public Pet(DateTime LastTimeFed,
    DateTime LastTimeMood,
    DateTime LastTimeEnergy,
    int food,
    int mood,
    int energy)

    {
        this.LastTimeFed = LastTimeFed;
        this.LastTimeMood = LastTimeMood;
        this.LastTimeEnergy = LastTimeEnergy;
        this.food = food;
        this.mood = mood;
        this.energy = energy;
    }
}