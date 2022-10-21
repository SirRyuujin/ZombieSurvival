using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    [Header("Customization")]
    public int ScoreAmountForOneSurvivalPoint = 20;
    public float ScoreMultiplierPerMinuteSurvived = 0.1f;

    [Header("References")]
    public IntVariable SessionsScore;
    public IntVariable HighScore;
    public IntVariable SurvivalPoints;
    
    [Header("Events")]
    public GameEvent OnChangeScoreEvent;
    public GameEvent OnNormalZobieDieEvent;

    [Header("Preview")]
    [SerializeField] private float _scoreMultiplier = 0;
    [SerializeField] private SaveLoadSystem _saveLoadSystem;

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

    private int CalculateSurvivalPoints()
    {
        return SessionsScore.Value / ScoreAmountForOneSurvivalPoint;
    }

    private void SetScoreMultiplier()
    {
        _scoreMultiplier = 1 + (int)(SessionsScore.Value / 60 * ScoreMultiplierPerMinuteSurvived);
    }

    public void SetSurvivalPoints()
    {
        SetScoreMultiplier();
        SetScore((int)(SessionsScore.Value * _scoreMultiplier));
        SurvivalPoints.Value = CalculateSurvivalPoints();
        if (_saveLoadSystem == null)
            _saveLoadSystem = FindObjectOfType<SaveLoadSystem>();

        TrySetNewHighScore();
        _saveLoadSystem.SaveData();
    }

    private void TrySetNewHighScore()
    {
        if (HighScore.Value < SessionsScore.Value)
            HighScore.Value = SessionsScore.Value;
    }
}