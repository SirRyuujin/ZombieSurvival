using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTracker : MonoBehaviour
{
    public FloatVariable Timer;
    public BoolVariable IsGamePaused;

    private void Awake()
    {
        Timer.Value = 0;
    }

    private void Update()
    {
        TrackPlaytime();
    }

    private void TrackPlaytime()
    {
        if (IsGamePaused.Value)
            return;

        Timer.Value += Time.deltaTime;
    }
}