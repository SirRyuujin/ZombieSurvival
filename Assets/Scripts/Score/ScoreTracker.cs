using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    public IntVariable SessionsScore;
    
    [Header("Events")]
    public GameEvent OnChangeScoreEvent;
    public GameEvent OnNormalZobieDieEvent;

    private void Start()
    {
        SetScore(0);
    }

    private void SetScore(int value)
    {
        SessionsScore.Value = value;
        OnChangeScoreEvent.Raise();
    }

    public void ChangeScore(EnemyBaseStats enemy)
    {
        SessionsScore.Value += enemy.Score;
        OnChangeScoreEvent.Raise();
    }
}