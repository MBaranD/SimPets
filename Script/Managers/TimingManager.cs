using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public static float GameHourTimer;
    public float HourLength;

    private void Update()
    {
        if (GameHourTimer <= 0)
        {
            GameHourTimer = HourLength;
        }

        else
        {
            GameHourTimer -= Time.deltaTime;
        }
    }
}
