using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float timerLength = 60.0f;
    private bool timerOver = true;

    public bool TimerOver { get => timerOver; }
    public float TimerLength { get => timerLength; }

    private void Update()
    {
        if(timerOver == false)
        {
            timerLength -= Time.deltaTime;
        }

        if(timerLength < 0)
        {
            TimerEnd();
        }
    }

    // end timer
    public void TimerEnd()
    {
        timerOver = true;
    }

    // start timer with set duration
    public void StartTimer()
    {
        timerLength = 0;
        timerLength = 60.0f;
        timerOver = false;
    }

    // start timer without set duration
    public void StartTimer(float duration)
    {
        timerLength = 0;
        timerLength = duration;
        timerOver = false;
    }
}
