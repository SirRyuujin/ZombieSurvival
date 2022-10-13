using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    public IntVariable TotalScore;
    
    [Header("Events")]
    public GameEvent OnChangeScoreEvent;
    public GameEvent OnNormalZobieDieEvent;

    [Header("Scoring")]
    public IntVariable NormalZombieScoreValue;

    private void Start()
    {
        // later on change it to a loaded value
        SetScore(0);
    }

    private void SetScore(int value)
    {
        TotalScore.Value = value;
        OnChangeScoreEvent.Raise();
    }

    public void ChangeScore(EnemyBaseStats enemy)
    {
        TotalScore.Value += enemy.Score;
        OnChangeScoreEvent.Raise();
    }
}