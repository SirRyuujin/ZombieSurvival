using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyController : MonoBehaviour
{
    public GameEvent OnStartNewWaveEvent;
    public WaveSettings[] WaveSettings;

    public IntVariable SettingsID;
    public IntVariable CurrentWaveID;
    public float CurrentWaveTimer = 0;
    public float WaveTimer;

    private void Awake()
    {
        CurrentWaveID.Value = 0;
        SettingsID.Value = 0;
        StartNextWave();
    }

    public void StartNextWave()
    {
        CurrentWaveID.Value++;

        if (CurrentWaveID.Value > WaveSettings[SettingsID.Value].HighestLevelToCover)
            SettingsID.Value++;

        OnStartNewWaveEvent.Raise();
        StartCoroutine(TrackWaveTimerCoroutine());
    }

    private IEnumerator TrackWaveTimerCoroutine()
    {
        CurrentWaveTimer = 0;
        WaveTimer = Random.Range(WaveSettings[SettingsID.Value].MinWaveDuration, WaveSettings[SettingsID.Value].MaxWaveDuration);
        while (CurrentWaveTimer < WaveTimer)
        {
            CurrentWaveTimer += Time.deltaTime;
            yield return null;
        }

        StartNextWave();
    }
}