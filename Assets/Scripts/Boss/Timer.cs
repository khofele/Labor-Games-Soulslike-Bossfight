using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timerLength = 60.0f;
    private bool timerOver = true;

    public bool TimerOver { get => timerOver; }

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

    public void TimerEnd()
    {
        timerOver = true;
    }

    public void StartTimer()
    {
        timerLength = 0;
        timerLength = 60.0f;
        timerOver = false;
    }

    public void StartTimer(float duration)
    {
        timerLength = 0;
        timerLength = duration;
        timerOver = false;
    }
}
